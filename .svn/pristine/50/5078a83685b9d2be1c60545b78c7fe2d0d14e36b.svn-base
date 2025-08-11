using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace BOSLib
{
    public class BOSStoredProcedureUtil
    {
        private const String SPXMLFileNamePrefix = "BOSsp";

        #region Export Function
        public void ExportStoredProcedure(String strStoredProcedureName,String strExportPath)
        {            
            //Export Stored Procedure to xml file
            String strXmlExportFileName = SPXMLFileNamePrefix + "_" + strStoredProcedureName + ".xml";
            XmlTextWriter xmlExport = new XmlTextWriter(strExportPath+"\\"+ strXmlExportFileName, null);
            xmlExport.Formatting = Formatting.Indented;
            WriteStoredProcedureToXML(xmlExport, strStoredProcedureName);
        }

        private void WriteStoredProcedureToXML(XmlTextWriter xmlExport, String strStoredProcedureName)
        {
            BOSDbUtil dbUtil = new BOSDbUtil();
            //Get Stored Procedure Text by Name
            String strStoredProcedureText = dbUtil.GetStoredProcedureTextByStoredProcedureName(strStoredProcedureName);

            //Write to XML File
            xmlExport.WriteStartDocument();
            xmlExport.WriteStartElement("BOSSP");            
            //write sp name
            xmlExport.WriteAttributeString("name", strStoredProcedureName);
            //write sp text
            xmlExport.WriteAttributeString("text", strStoredProcedureText.Trim());
            xmlExport.WriteEndElement();            

            xmlExport.WriteEndDocument();
            xmlExport.Flush();
            xmlExport.Close();
        }
        #endregion

        #region Import Functions
        public void ImportStoredProcedure(String strStoredProcedureName,String strStoredProcedureText,bool isOverwrite)
        {
            BOSDbUtil dbUtil = new BOSDbUtil();

            //first Drop Procedure if is overwrite
            if (isOverwrite)
                DropProcedure(strStoredProcedureName);

            //Execute new Stored Procedure
            dbUtil.ExecuteNonQuery(strStoredProcedureText);        
        }

        public void ImportStoredProcedure(String strFileName, bool isOverwrite)
        {
            String strStoredProcedureText = GetStoredProcedureTextFromXMLFile(strFileName);
            String strStoredProcedureName = GetStoredProcedureNameFromXMLFile(strFileName);

            ImportStoredProcedure(strStoredProcedureName, strStoredProcedureText, isOverwrite);
        }

        public void ImportAllStoredProcedures(String strXMLFolder, bool isOverwrite)
        {
            String[] strFileNames = Directory.GetFiles(strXMLFolder);
            if (strFileNames.Length > 0)
            {
                BOSProgressBar.Start("Ready to import");
                foreach (String strFileName in strFileNames)
                {
                    BOSProgressBar.SetText(strFileName.Substring(strFileName.IndexOf("tmp")+4));
                    ImportStoredProcedure(strFileName, isOverwrite);
                }
                BOSProgressBar.Close();
            }
        }        

       
        private String GetStoredProcedureTextFromXMLFile(String strFileName)
        {
            try
            {
                String strStoredProcedureText = String.Empty;
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(strFileName);
                XmlNodeList listNode = xmlDoc.GetElementsByTagName("BOSSP");
                if (listNode != null)
                {

                    XmlElement spElement = (XmlElement)listNode[0];
                    strStoredProcedureText = spElement.GetAttribute("text");
                }
                return strStoredProcedureText;
            }
            catch (Exception)
            {
                return String.Empty;
            }

        }

        public String GetStoredProcedureNameFromXMLFile(String strFileName)
        {
            try
            {
                String strStoredProcedureName = String.Empty;
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(strFileName);
                XmlNodeList listNode = xmlDoc.GetElementsByTagName("BOSSP");
                if (listNode != null)
                {

                    XmlElement spElement = (XmlElement)listNode[0];
                    strStoredProcedureName = spElement.GetAttribute("name");
                }
                return strStoredProcedureName;
            }
            catch (Exception)
            {
                return String.Empty;
            }
        }

        private bool DropProcedure(String strStoredProcedureName)
        {
            try
            {
                BOSDbUtil dbUtil = new BOSDbUtil();
                StringBuilder strDropBuilder = new StringBuilder();

                strDropBuilder.Append(String.Format("IF OBJECT_ID(N'[dbo].[{0}]') IS NOT NULL", strStoredProcedureName));
                strDropBuilder.Append("\n" + "\t"+ String.Format("DROP PROCEDURE [dbo].[{0}]", strStoredProcedureName));
                strDropBuilder.Append("\n");

                dbUtil.ExecuteQuery(strDropBuilder.ToString());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion


        private String GetStoredProcedureFolder()
        {
            String strStoredProcedurePath = Application.StartupPath + "\\tmp";
            if (!Directory.Exists(strStoredProcedurePath))
                Directory.CreateDirectory(strStoredProcedurePath);
            return strStoredProcedurePath;
        }
    }
}
