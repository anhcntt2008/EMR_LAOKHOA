using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml;
using CHBase.SDK;
using CHBase.SDK.ItemTypes;
using CHBase.SDK.PatientConnect;
using Microsoft.Win32.SafeHandles;
using File = CHBase.SDK.ItemTypes.File;
using BOSCommon;
using System.Threading;
using System.Web;

namespace Clas.CHBase
{
    public class CHBaseFunctions
    {
        private HealthRecordSearcher _searcher;
        private HealthRecordAccessor _accessor;
        private HealthRecordFilter _filter;

        public string ApplicationId
        {
            get
            {
                //if (ConfigurationManager.AppSettings["ApplicationId"] != null)
                //    return ConfigurationManager.AppSettings["ApplicationId"];
                return "";
            }
        }

        /// <summary>
        ///     Create a participant code. A participant can authorize this application by entering this code
        ///     on CHBase and answering the security question
        /// </summary>
        /// <param name="friendlyName">Participant's Name</param>
        /// <param name="securityQuestion">Security question</param>
        /// <param name="securityAnswer">Security Answer</param>
        /// <param name="applicationPatientId">Application Specific ID for Participant</param>
        /// <returns>Returns 20 digit identity code</returns>
        public string CreateParticipantIdentityCode(string friendlyName,
            string securityQuestion,
            string securityAnswer,
            string applicationPatientId)
        {
            var applicationId = new Guid(ApplicationId);
            var offlineConnection = CHBaseConnectionManager.CreateConnection(applicationId);
            var identityCode = PatientConnection.Create(offlineConnection, friendlyName, securityQuestion, securityAnswer,
                null, applicationPatientId);
            return identityCode;
        }

        /// <summary>
        ///     Get all the application authorizatons that happend in last n days as specified by the pastDays parameter.
        ///     pastDays is set to 0, this function gets ALL the validatations that has happend to date.
        /// </summary>
        /// <param name="pastDays">
        ///     Specify the last number of days since when the validations needs to be fetched. Specify 0 to
        ///     fetch all validations
        /// </param>
        /// <returns></returns>
        public Collection<ValidatedPatientConnection> GetValidatedConnectionsInPastDays(int pastDays)
        {
            var appId = new Guid(ApplicationId);
            var offlineConnection = CHBaseConnectionManager.CreateConnection(appId);


            if (pastDays > 0)
            {
                var dtSince = DateTime.Now.AddDays(-1 * pastDays);
                return PatientConnection.GetValidatedConnections(offlineConnection, dtSince);
            }

            return PatientConnection.GetValidatedConnections(offlineConnection);
        }

        public List<Guid> CheckvalidateInPastDays(string participantId, int pastDays = 90)
        {
            var appId = new Guid(ApplicationId);
            var offlineConnection = CHBaseConnectionManager.CreateConnection(appId);
            var list = pastDays > 0 ? PatientConnection.GetValidatedConnections(offlineConnection, DateTime.Now.AddDays(-1 * pastDays)) : PatientConnection.GetValidatedConnections(offlineConnection);
            var obj = list.FirstOrDefault(x => x.ApplicationPatientId == participantId);
            if (obj == null)
            {
                return null;
            }
            return new List<Guid>()
            {
                obj.RecordId,
                obj.PersonId
            };
        }

        #region  Xml
        /// <summary>
        ///     Generates an XML Document containing the blood pressure data of participants specified.
        ///     Depending on number of participants and date since paramenter, this request could take some time to complete.
        /// </summary>
        /// <param name="dtDateTimeAfter">Specify the date since when blood pressure data is to be downloaded</param>
        /// <param name="participantList">
        ///     The list of ParticipantConnectionDetails whose blood pressure details need to be
        ///     downloaded
        /// </param>
        /// <returns>XmlDocument containg the participant's data</returns>
        public XmlDocument GetParticipantData(DateTime dtDateTimeAfter,
            List<ParticipantConnectionDetails> participantList)
        {
            return ConstructXmlDocument(dtDateTimeAfter, participantList);
        }



        private XmlDocument ConstructXmlDocument(DateTime dtDateAfter,
            List<ParticipantConnectionDetails> participantList)
        {
            var applicationId = new Guid(ApplicationId);

            var xDoc = new XmlDocument();

            var declNode = xDoc.CreateNode(XmlNodeType.XmlDeclaration, "", "");
            xDoc.AppendChild(declNode);


            var xResultNode = xDoc.CreateNode(XmlNodeType.Element, "result", string.Empty);

            //Populate the current query specific attributes 

            var xQueryNode = xDoc.CreateNode(XmlNodeType.Element, "query", string.Empty);

            var xQueryWhenNode = xDoc.CreateNode(XmlNodeType.Element, "when", string.Empty);
            xQueryWhenNode.InnerText = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            xQueryNode.AppendChild(xQueryWhenNode);

            var xQueryCreatedAfterNode = xDoc.CreateNode(XmlNodeType.Element, "created_after", string.Empty);
            xQueryCreatedAfterNode.InnerText = dtDateAfter.ToString(CultureInfo.InvariantCulture);
            xQueryNode.AppendChild(xQueryCreatedAfterNode);


            var xQueryLoggedInAccountNode = xDoc.CreateNode(XmlNodeType.Element, "loggedin_account", string.Empty);
            xQueryLoggedInAccountNode.InnerText = "application-" + ApplicationId;
            xQueryNode.AppendChild(xQueryLoggedInAccountNode);

            var xQueryAuthRecordCountNode = xDoc.CreateNode(XmlNodeType.Element, "num_participant_records_fetched",
                string.Empty);
            xQueryAuthRecordCountNode.InnerText = participantList.Count.ToString();
            xQueryNode.AppendChild(xQueryAuthRecordCountNode);

            xResultNode.AppendChild(xQueryNode);

            var xUsersNode = xDoc.CreateNode(XmlNodeType.Element, "users", string.Empty);


            foreach (var participantDetail in participantList)
            {
                var personId = participantDetail.PersonId;
                var recordId = participantDetail.RecordId;

                var accessor =
                    new HealthRecordAccessor(CHBaseConnectionManager.CreateConnection(applicationId, personId),
                        recordId);

                var xUserNode = xDoc.CreateNode(XmlNodeType.Element, "user", string.Empty);
                var xApplicationSpecificIdAttrib = xDoc.CreateAttribute("application_specific_id");
                xApplicationSpecificIdAttrib.Value = participantDetail.ApplicationSpecificId;
                if (xUserNode.Attributes != null)
                {
                    xUserNode.Attributes.Append(xApplicationSpecificIdAttrib);
                    var xNameAttrib = xDoc.CreateAttribute("healthvault_record_name");


                    //Fetch the Personal and Contact item from CHBase for this user. 
                    //For efficiency, batch the requests 
                    Personal personal = null;
                    Contact contact = null;
                    var searcherUserInfo = new HealthRecordSearcher(accessor);

                    var filterPersonal = new HealthRecordFilter();
                    filterPersonal.TypeIds.Add(Personal.TypeId);
                    filterPersonal.View.Sections = HealthRecordItemSections.Core | HealthRecordItemSections.Xml;
                    searcherUserInfo.Filters.Add(filterPersonal);

                    var filterContact = new HealthRecordFilter();
                    filterContact.TypeIds.Add(Contact.TypeId);
                    filterContact.View.Sections = HealthRecordItemSections.Core | HealthRecordItemSections.Xml;
                    searcherUserInfo.Filters.Add(filterContact);


                    var resultsUserInfo = searcherUserInfo.GetMatchingItems();

                    var itemsPersonal = resultsUserInfo[0];
                    var itemsContact = resultsUserInfo[1];
                    if ((itemsPersonal != null) && (itemsPersonal.Count > 0))
                        personal = (Personal)itemsPersonal[0];

                    if ((itemsContact != null) && (itemsContact.Count > 0))
                        contact = (Contact)itemsContact[0];


                    //Find the name as in CHBase from the Personal Item of the user
                    if ((personal != null) && (personal.Name != null))
                        xNameAttrib.Value = personal.Name.Full;
                    else
                        xNameAttrib.Value = "";

                    xUserNode.Attributes.Append(xNameAttrib);


                    //Find the email as in CHBase from the Contact Item of the user
                    if (contact != null)
                    {
                        var xEmailAttrib = xDoc.CreateAttribute("email");

                        if ((contact.ContactInformation != null) &&
                            (contact.ContactInformation.PrimaryEmail != null) &&
                            (contact.ContactInformation.PrimaryEmail.Address != null))
                        {
                            xEmailAttrib.Value = contact.ContactInformation.PrimaryEmail.Address;
                            xUserNode.Attributes.Append(xEmailAttrib);
                        }
                    }

                    //Finally, Query for the blood pressure readings
                    var searcher = new HealthRecordSearcher(accessor);
                    var filter = new HealthRecordFilter();
                    filter.TypeIds.Add(BloodPressure.TypeId);
                    filter.TypeIds.Add(Medication.TypeId);
                    filter.TypeIds.Add(Height.TypeId);
                    filter.TypeIds.Add(Weight.TypeId);
                    filter.TypeIds.Add(VitalSigns.TypeId);
                    filter.CurrentVersionOnly = true;
                    filter.EffectiveDateMin = dtDateAfter;
                    filter.View.Sections = HealthRecordItemSections.Core | HealthRecordItemSections.Xml;
                    searcher.Filters.Add(filter);
                    var results = searcher.GetMatchingItems();
                    var resultCollection = results[0];

                    var xReadingCountAttrib = xDoc.CreateAttribute("num_blood_pressure_readings");
                    xReadingCountAttrib.Value = resultCollection.Count.ToString();
                    xUserNode.Attributes.Append(xReadingCountAttrib);

                    //Add the item xml of the blood pressure reading to current user node 
                    foreach (var item in resultCollection)
                    {
                        var itemXmlString = item.GetItemXml();
                        xUserNode.InnerXml += itemXmlString;
                    }
                }
                xUsersNode.AppendChild(xUserNode);
            }
            xResultNode.AppendChild(xUsersNode);
            xDoc.AppendChild(xResultNode);
            return xDoc;
        }

        #endregion



        public void GenAccessor(ParticipantConnectionDetails participantDetail)
        {
            var personId = participantDetail.PersonId;
            var recordId = participantDetail.RecordId;
            var applicationId = new Guid(ApplicationId);
            _accessor = new HealthRecordAccessor(CHBaseConnectionManager.CreateConnection(applicationId, personId), recordId);
        }

        public Dictionary<Personal, List<Contact>> GetPerson()
        {
            var searcherUserInfo = new HealthRecordSearcher(_accessor);

            var filterPersonal = new HealthRecordFilter();
            filterPersonal.TypeIds.Add(Personal.TypeId);
            filterPersonal.View.Sections = HealthRecordItemSections.Core | HealthRecordItemSections.Xml;
            searcherUserInfo.Filters.Add(filterPersonal);

            var filterContact = new HealthRecordFilter();
            filterContact.TypeIds.Add(Contact.TypeId);
            filterContact.View.Sections = HealthRecordItemSections.Core | HealthRecordItemSections.Xml;
            searcherUserInfo.Filters.Add(filterContact);

            var resultsUserInfo = searcherUserInfo.GetMatchingItems();

            var itemsPersonal = resultsUserInfo[0];
            var itemsContact = resultsUserInfo[1];
            Personal personal = null;
            if (itemsPersonal != null && itemsPersonal.Count > 0)
            {
                personal = (Personal)itemsPersonal[0];
            }
            var contacts = new List<Contact>();
            if (itemsContact != null && itemsContact.Count > 0)
            {
                contacts.AddRange(itemsContact.Cast<Contact>());
            }

            return new Dictionary<Personal, List<Contact>>
            {
               {personal, contacts}
            };

        }

        public List<T> GetHealthRecord<T>(Guid typeId, DateTime startDate, DateTime endDate) where T : HealthRecordItem
        {
            _searcher = new HealthRecordSearcher(_accessor);
            var healthRecordView = new HealthRecordView { Sections = HealthRecordItemSections.All };
            _filter = new HealthRecordFilter(typeId)
            {
                EffectiveDateMin = startDate,
                EffectiveDateMax = endDate,
                CurrentVersionOnly = true,
                View = healthRecordView
            };
            _searcher.Filters.Add(_filter);

            var items = _searcher.GetMatchingItems()[0];

            return items.Cast<T>().ToList();
        }

        public ChBaseResult UploadFile(string path, string fileName = null, string codableValue = "text/rtf", string []tag = null)
        {
            
            var fileInfo = new FileInfo(path);
            if (!fileInfo.Exists)
            {
                return new ChBaseResult(false,"File not found");
            }
            try
            {
                var mime = MimeMapping.GetMimeMapping(path);
                if (string.IsNullOrEmpty(codableValue))
                    codableValue = mime;
                using (var stream = fileInfo.OpenRead())
                {
                    var fileUpload = File.CreateFromStream(_accessor, stream,
                        string.IsNullOrEmpty(fileName) ? fileInfo.Name : fileName + fileInfo.Extension,
                        new CodableValue(codableValue));
                    if (tag != null)
                    {
                        foreach (var s in tag)
                        {
                            fileUpload.Tags.Add(s);
                        }
                    }
                   
                    _searcher = new HealthRecordSearcher(_accessor);
                    _searcher.Record.NewItem(fileUpload);
                }
                return new ChBaseResult();
            }
            catch (Exception e)
            {
                return new ChBaseResult(false, e.Message);
            }
        }

        public ChBaseResult UploadNewFileWithStatus(string path, CHBaseFileType type)
        {
            string fileName = null;
            string codableValue = "text/rtf";
            var fileInfo = new FileInfo(path);
            if (!fileInfo.Exists)
            {
                return new ChBaseResult(false, "File not found");
            }
            try
            {
                using (var stream = fileInfo.OpenRead())
                {
                    var fileUpload = File.CreateFromStream(_accessor, stream,
                        string.IsNullOrEmpty(fileName) ? fileInfo.Name : fileName + fileInfo.Extension,
                        new CodableValue(codableValue));
                    _searcher = new HealthRecordSearcher(_accessor);
                    Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                    string tag = DateTime.Now.ToString();
                    fileUpload.Tags.Add(tag);
                    fileUpload.Tags.Add((int)type + "");
                    _searcher.Record.NewItem(fileUpload);
                }
                return new ChBaseResult();
            }
            catch (Exception e)
            {
                return new ChBaseResult(false, e.Message);
            }
        }

        public ChBaseResult UploadFileWithStatus(string path, CHBaseFileType type)
        {
            string fileName = null;
            string codableValue = "text/rtf";
            var fileInfo = new FileInfo(path);
            if (!fileInfo.Exists)
            {
                return new ChBaseResult(false, "File not found");
            }
            try
            {
                using (var stream = fileInfo.OpenRead())
                {
                    var fileUpload = File.CreateFromStream(_accessor, stream,
                        string.IsNullOrEmpty(fileName) ? fileInfo.Name : fileName + fileInfo.Extension,
                        new CodableValue(codableValue));
                    _searcher = new HealthRecordSearcher(_accessor);
                    var listFile = GetHealthRecord<File>(File.TypeId, DateTime.MinValue, DateTime.MaxValue);

                    var file = listFile.FirstOrDefault(x => x.Tags.Count > 1 && x.Tags[1] == (int)CHBaseFileType.MedicalHistory + "");
                    if (file != null)
                    {
                        fileUpload.Tags.Add(file.Tags[0]);
                        fileUpload.Tags.Add(file.Tags[1]);
                        _searcher.Record.RemoveItem(file);
                        _searcher.Record.NewItem(fileUpload);
                    }
                    else
                    {
                        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                        string tag = DateTime.Now.ToString();
                        fileUpload.Tags.Add(tag);
                        fileUpload.Tags.Add((int)type + "");
                        _searcher.Record.NewItem(fileUpload);
                    }



                }
                return new ChBaseResult();
            }
            catch (Exception e)
            {
                return new ChBaseResult(false, e.Message);
            }
        }

        public ChBaseResult DownloadFile(File file, string pathAndFileName, bool openWhenComplete = false)
        {
            try
            {
                System.IO.File.WriteAllBytes(pathAndFileName, file.Content);
                if (!openWhenComplete) return new ChBaseResult();
                var process = new Process {StartInfo = {FileName = pathAndFileName}};
                process.Start();
                return new ChBaseResult();
            }
            catch (Exception e)
            {
                return new ChBaseResult(false, e.Message);
            }
        }
        public ChBaseResult AddRecord(HealthRecordItem item)
        {
            try
            {
                _searcher = new HealthRecordSearcher(_accessor);
                _searcher = new HealthRecordSearcher(_accessor);
                _searcher.Record.NewItem(item);

                return new ChBaseResult();
            }
            catch (Exception e)
            {
                return new ChBaseResult(false, e.Message);
            }
        }
    }
    public class ChBaseResult
    {
        public bool Success;
        public string Message;

        public ChBaseResult(bool success = true, string message = null)
        {
            Success = success;
            Message = message;
        }
    }
}