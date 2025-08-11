using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clas.Model.Doctor24x7;
using Clas.Business.Doctor24x7;
using Clas.Business.Logger;
using Clas.Model.Logger;
using Newtonsoft.Json;
using Clas.Business.DrugInfo;
using Clas.Model.DrugInfo;
using Clas.Business.BHYT;

namespace Clas.Test.Dal
{
    class Program
    {
        static void Main(string[] args)
        {


            // Action runAsync = () => Login();


           // Action runAsync = () => Check();

            try
            {
                // runAsync.BeginInvoke(new AsyncCallback(CallBack), null);
                var qr = new QrHelper();
                //var r = qr.QrParse("DN479GA78900007|C4906FC3A06E205068C6B0C6A16E67204E6869|15/09/1993|2|3231332F31204E677579E1BB856E2056C4836E2043E1BBAB202D2070332D205135|79 - 012|01/09/2016|31/12/2016|16/09/2016|791900565855|-|4|-|27ee82624a6f2342-0101|$");
                var r = qr.QrParse("DN479GA78900007|C4906FC3A06Ê8C6B0C6ẤÊ7204Ê869|15/09/1993|2|3231332F31204Ê77579ÉBB856ỆC4836ẺÉBBAB202D2070332D205135|79 - 012|01/09/2016|31/12/2016|16/09/2016|791900565855|-|4|-|27ee82624âf2342-0101|$");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                //runAsync.EndInvoke(null);
            }

            Console.ReadKey();
        }
        private static void CallBack(IAsyncResult ar)
        {
            Action<int> t = ar.AsyncState as Action<int>; //AsyncState is set by passing in the delegate to the BeginInvoke’s method. 
            //t.EndInvoke(ar);//calling EndInvoke - REQUIRED 
            if (!ar.IsCompleted)
            {
                Console.WriteLine("Error");
            }
        }

        #region Doctor24x7
        public static void Login()
        {
            try
            {
                UserManager userManager = new UserManager();

                UserLoginHttpRequest model = new UserLoginHttpRequest();
                var result = userManager.Login("khangcv@lyd.vn", "Abc@123");
                //var result = userManager.Login("vanut111@gmail.com", "abc@123");
                //var result = userManager.Login("mtthieu@sdc.ud.edu.vn", "Sdc123456@");

                Console.WriteLine(result.data.sessionId);
                Console.WriteLine(result.data.userId);


                GetListHopitals(result.data.userId, result.data.sessionId);

                Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
                GetUserDetailsIncludeClinic(result.data.userId, result.data.sessionId);

                Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
                GetAvailableScheduleOfDoctor(result.data.userId, result.data.sessionId);


                Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
                GetListDoctor(result.data.userId, result.data.sessionId);

            }
            catch (Exception ex)
            {
                BizLogger.WriteLog(LoggerLevel.ERROR, ex);
            }

        }


        public static void GetListHopitals(string userId, string sessionId)
        {
            HopitalManager man = new HopitalManager();
            var result = man.GetListHopitals(userId, sessionId, 0, 200, false, "");

            foreach (var item in result.data.hospitals)
            {

                Console.WriteLine(item.name);
            }

            // write file 
            BizLogger.WriteLog(LoggerLevel.INFO, DateTime.Now, JsonConvert.SerializeObject(result));
        }
        public static void GetUserDetailsIncludeClinic(string userId, string sessionId)
        {
            UserManager man = new UserManager();
            var result = man.GetUserDetailsIncludeClinic(userId, userId, sessionId);

            foreach (var item in result.data.user.doctorInfos)
            {
                // user have list hopital
                Console.WriteLine(item.hospital.name);
            }

            // write file 
            BizLogger.WriteLog(LoggerLevel.INFO, DateTime.Now, JsonConvert.SerializeObject(result));
        }
        public static void GetAvailableScheduleOfDoctor(string userId, string sessionId)
        {
            UserManager man = new UserManager();
            var result = man.GetAvailableScheduleOfDoctor(userId, "", null, null, userId, sessionId);

            foreach (var item in result.data.schedules)
            {
                // user have list hopital
                Console.WriteLine(item.hospital.name + " Time Server " + item.startTime + " Time Local " + item.StartTimeLocal.ToString("dd MM yyyy hh:mm:ss"));
            }
            Checkup(userId, sessionId, result.data.schedules.First().id);
            // write file 
            BizLogger.WriteLog(LoggerLevel.INFO, DateTime.Now, JsonConvert.SerializeObject(result));
        }
        public static void GetListDoctor(string userId, string sessionId)
        {
            DoctorManager man = new DoctorManager();
            var result = man.GetListDoctors(userId, sessionId, null, null, 0, 10, null, null, null, null);

            foreach (var item in result.data.doctors)
            {
                // user have list hopital
                Console.WriteLine(item.fullName);
            }

            // write file 
            BizLogger.WriteLog(LoggerLevel.INFO, DateTime.Now, JsonConvert.SerializeObject(result));
        }

        public static void Checkup(string userId, string sessionId, string scheduleId)
        {
            CheckupManager man = new CheckupManager();
            var model = new CheckupPostModel()
            {
                scheduleId = scheduleId,
                symptom = "Triệu chứng",
                userId = null,
                dataUser = new CheckupPostDataUser()
                {
                    parentId = "c4a38a66-d3cc-11e6-ba51-d907baaaf53f",
                    firstName = "Khang",
                    lastName = "BenhNhan",
                    phone = "0907990345",
                    email = "chungvinhkhang+his@live.com",
                    idNo = "0951010054456",
                    address = "193 Nguyễn Lương Bằng",
                    cityId = "48",
                    districtId = "491"
                }
            };
            var result = man.Checkup(userId, sessionId, model);

            Console.WriteLine(JsonConvert.SerializeObject(result));
            //foreach (var item in result.data.doctors)
            //{
            //    // user have list hopital
            //    Console.WriteLine(item.fullName);
            //}

            // write file 
            BizLogger.WriteLog(LoggerLevel.INFO, DateTime.Now, JsonConvert.SerializeObject(result));
        }

        #endregion Doctor24x7

        #region DrugInfo
        public static void Check()
        {
            DrugManager man = new DrugManager();
            var model = new DrugCheckRequest()
            {
                date = DateTime.Now,
                doctor_name = "Ut Huynh",
                nurse_name = "",
                owner_id = "VNM-BVPK-HCM-00001",
                code = "16042612",
                drugs = new List<Drug>(),
                diseases = new List<string>(),
                patient = new DrugInfoPatient()
            };
            model.drugs.Add(new Drug()
            {
                drug_id = "VD-21412-14",
                quantity = 10,
                days = 2,
                morning = 1,
                lunch = 1,
                afternoon = 1,
                evening = 1
            });
            model.drugs.Add(new Drug()
            {
                drug_id = "VD-14279-11",
                quantity = 10,
                days = 2,
                morning = 1,
                lunch = 1,
                afternoon = 1,
                evening = 1
            });
            model.drugs.Add(new Drug()
            {
                drug_id = "VD-10951-10",
                quantity = 10,
                days = 2,
                morning = 1,
                lunch = 1,
                afternoon = 1,
                evening = 1
            });
            model.diseases.Add("E10");
            model.diseases.Add("I15");
            model.diseases.Add("K72");
            model.patient = new DrugInfoPatient()
            {
                code = "160512",
                name = "A",
                sex = "F",
                dob = "20/05/2003",
                age = 13,
                weight = 60,
                height = 150,
                pulse = 80,
                pregnant = 1,
                smoking = true,
                alcohol = true,
                breast_feeding = true,
                systolic = 120,
                diastolic = 80,
                base_diseases = new List<string>() { "N17", "I11" },
                allergic_uniis = new List<string>() { "804826J2HU" },
                allergic_drugs = new List<string>() { "VD-17589-12" }

            };

            var result = man.Check(model);
            if (result.result.drug_interactions != null)
                foreach (var item in result.result.drug_interactions)
                {
                    Console.WriteLine(item.ToString());
                }
            if (result.result.contraindications != null)
                foreach (var item in result.result.contraindications)
                {
                    Console.WriteLine(item.ToString());
                }
            if (result.result.alcohol_interaction != null)
                foreach (var item in result.result.alcohol_interaction)
                {
                    Console.WriteLine(item.ToString());
                }
            if (result.result.warnings != null)
                foreach (var item in result.result.warnings)
                {
                    Console.WriteLine(item.ToString());
                }
            if (result.result.allergy != null)
                foreach (var item in result.result.allergy)
                {
                    Console.WriteLine(item.ToString());
                }
            if (result.result.indication_by_disease != null)
                foreach (var item in result.result.indication_by_disease)
                {
                    Console.WriteLine(item.ToString());
                }
            if (result.result.pregnancy != null)
                foreach (var item in result.result.pregnancy)
                {
                    Console.WriteLine(item.ToString());
                }
            if (result.result.tobacco != null)
                foreach (var item in result.result.tobacco)
                {
                    Console.WriteLine(item.ToString());
                }
            // write file 
            //BizLogger.WriteLog(LoggerLevel.INFO, DateTime.Now, JsonConvert.SerializeObject(result));
        }
        #endregion
    }
}
