using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using CommunityMedicineAutomationApp.DAL.DAO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CommunityMedicineAutomationApp.DAL.Gateway
{
    public class CenterGateway:SqlConnectionGateway
    {
       
        public bool IsThisCenterNameExists(string name, int id)
        {
            string searchMedicine = "SELECT * FROM tbl_center WHERE CenterName='" + name + "' AND ThanaId='"+id+"'";
            sqlConnection.Open();
            sqlCommand.CommandText = searchMedicine;
            SqlDataReader reader = sqlCommand.ExecuteReader();
            bool isThisCenterNameExists = false;
            while (reader.Read())
            {
                isThisCenterNameExists = true;
            }
            reader.Close();
            sqlConnection.Close();
            return isThisCenterNameExists;
        }

        public bool CreateCenter(Center aCenter)
        {
            string saveMedicine = "INSERT INTO tbl_center (CenterName,CenterCode,CenterPassward,DistrictId,ThanaId) VALUES(@name,@CenterCode,@CenterPassward,@DistrictId,@ThanaId)";
            sqlConnection.Open();
            sqlCommand.CommandText = saveMedicine;
            sqlCommand.Parameters.AddWithValue("@name", aCenter.Name);
            sqlCommand.Parameters.AddWithValue("@CenterCode", aCenter.CenterCode);
            sqlCommand.Parameters.AddWithValue("@CenterPassward", aCenter.Password);
            sqlCommand.Parameters.AddWithValue("@DistrictId", aCenter.DistrictId);
            sqlCommand.Parameters.AddWithValue("@ThanaId", aCenter.ThanaId);
            int rowAffected = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            if (rowAffected > 0)
            {
                return true;
            }
            return false;
        }

        public bool IsThisCenterCodeExists(string centerCode)
        {
            string searchMedicine = "SELECT * FROM tbl_center WHERE CenterCode='" + centerCode + "'";
            sqlConnection.Open();
            sqlCommand.CommandText = searchMedicine;
            SqlDataReader reader = sqlCommand.ExecuteReader();
            bool isThisCenterNameExists = false;
            while (reader.Read())
            {
                isThisCenterNameExists = true;
            }
            reader.Close();
            sqlConnection.Close();
            return isThisCenterNameExists;
        }

        public bool Match(string centerCode)
        {
            string searchCentercode = "SELECT * FROM tbl_center WHERE CenterCode='" + centerCode + "'";
            sqlConnection.Open();
            sqlCommand.CommandText = searchCentercode;
            SqlDataReader reader = sqlCommand.ExecuteReader();
            bool isThisCenterNameExists = false;
            while (reader.Read())
            {
                isThisCenterNameExists = true;
            }
            reader.Close();
            sqlConnection.Close();
            return isThisCenterNameExists;
        }

        public string GetPassword(string centerCode)
        {

            string searchCentercode = "SELECT CenterPassward FROM tbl_center WHERE CenterCode='" + centerCode + "'";
            sqlConnection.Open();
            sqlCommand.CommandText = searchCentercode;
            SqlDataReader reader = sqlCommand.ExecuteReader();
            string password = null;
            while (reader.Read())
            {
                password = reader["CenterPassward"].ToString();
            }
            reader.Close();
            sqlConnection.Close();
            return password;
        }

        public Center GetCenterIdbyCenterCode(string centerCode)
        {
            string query = "SELECT * FROM tbl_center WHERE CenterCode ='" + centerCode + "'";
            sqlConnection.Open();
            sqlCommand.CommandText = query;
            SqlDataReader aReader = sqlCommand.ExecuteReader();
            Center aCenter = new Center();
            while (aReader.Read())
            {
                aCenter.Id = (int)aReader["id"];
                aCenter.Name = aReader["CenterName"].ToString();
            }
            aReader.Close();
            sqlConnection.Close();
            return aCenter;
        }

        public List<Voter> GetVoterInformation()
        {

            WebClient client = new WebClient();
            var data = client.DownloadString("http://nerdcastlebd.com/web_service/voterdb/index.php/voters/all/format/json");

            JObject obj = JObject.Parse(data);
            var jsonObjList = JsonConvert.SerializeObject(obj);

            var des = (RootObject)JsonConvert.DeserializeObject(jsonObjList, typeof(RootObject));
            RootObject voters = des;

            List<Voter> voterList = voters.Voters;
            return voterList;
        }

        public List<Treatment> GetNumberofServiceTaken(string voterId)
        {
            
            string query = "SELECT DISTINCT date FROM tbl_treatment WHERE patientVoterId ='" + voterId + "'";
            sqlConnection.Open();
            sqlCommand.CommandText = query;
            SqlDataReader aReader = sqlCommand.ExecuteReader();
            List<Treatment> treatmentList = new List<Treatment>();
            while (aReader.Read())
            {
               Treatment aTreatment = new Treatment();
               aTreatment.Date =  (DateTime) aReader["date"];
               treatmentList.Add(aTreatment);

            }
            aReader.Close();
            sqlConnection.Close();
            return treatmentList;
            
        }

        
        public bool SaveTreatmentInfo(List<Treatment> treatments)
        {
            int rowaffected = 0;
            foreach (var treatmentList in treatments)
            {
                string query ="INSERT INTO tbl_treatment(observation,date,patientVoterId,doctorId,diseaseId,medicineId,does,meal_time,quantity,note,centerId) VALUES(@observation,@date,@patientId,@doctorId,@diseaseId,@medicineId,@does,@mealTime,@quantity,@note,@centerId)";
                sqlConnection.Open();
                sqlCommand.CommandText = query;
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@observation", treatmentList.Observation);
                sqlCommand.Parameters.AddWithValue("@date", treatmentList.Date);
                sqlCommand.Parameters.AddWithValue("@patientId", treatmentList.PatientVoterId);
                sqlCommand.Parameters.AddWithValue("@doctorId", treatmentList.DoctorId);
                sqlCommand.Parameters.AddWithValue("@diseaseId", treatmentList.DiseaseId);
                sqlCommand.Parameters.AddWithValue("@medicineId", treatmentList.MedicineId);
                sqlCommand.Parameters.AddWithValue("@does", treatmentList.Does);
                sqlCommand.Parameters.AddWithValue("@mealTime", treatmentList.MealTime);
                sqlCommand.Parameters.AddWithValue("@quantity", treatmentList.Quantity);
                sqlCommand.Parameters.AddWithValue("@note", treatmentList.Note);
                sqlCommand.Parameters.AddWithValue("@centerId", treatmentList.CenterId);
                rowaffected = sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();

                bool updateStatus = UpdateMedicineStock(treatmentList.CenterId, treatmentList.MedicineId, treatmentList.Quantity);


            }
            if (rowaffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool UpdateMedicineStock(int centerId, int medicineId, int quantity)
        {
            string update = "UPDATE tbl_send_medicine SET quentity-='" + quantity + "' WHERE centerId='" + centerId + "' AND medicineId='" + medicineId + "'";
            sqlConnection.Open();
            sqlCommand.CommandText = update;
            int rowAffected = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            if (rowAffected > 0)
            {
                return true;
            }
            return false;
        }

        public List<Treatment> GetAllTreatmentByDate(DateTime date, string voterId)
        {
            string query =" SELECT DISTINCT tbl_center.CenterName,tbl_treatment.date,tbl_doctor.name,tbl_treatment.observation from tbl_treatment join tbl_center ON tbl_center.id=tbl_treatment.centerId join tbl_doctor ON tbl_doctor.id=tbl_treatment.doctorId Where patientVoterId='"+voterId+"' AND date='"+date+"'";
            sqlConnection.Open();
            sqlCommand.CommandText = query;
            SqlDataReader aReader = sqlCommand.ExecuteReader();
            List<Treatment> treatmentList = new List<Treatment>();
            while (aReader.Read())
            {
                Treatment aTreatment = new Treatment();
                aTreatment.CenterName = aReader["CenterName"].ToString();
                aTreatment.Date = (DateTime) aReader["date"];
                aTreatment.DoctorName = aReader["name"].ToString();
                aTreatment.Observation = aReader["observation"].ToString();
                
                treatmentList.Add(aTreatment);

            }
            aReader.Close();
            sqlConnection.Close();
            return treatmentList;
        }

        public List<Treatment> GetAllTreatmentList(DateTime date, string voterId)
        {
            string query = "select tbl_medicine.MedicineName,tbl_diseases.DiseasesName,tbl_treatment.does,tbl_treatment.note,tbl_treatment.meal_time,tbl_treatment.quantity from tbl_treatment join tbl_diseases ON tbl_treatment.diseaseId=tbl_diseases.id join tbl_medicine ON tbl_treatment.medicineId=tbl_medicine.id Where patientVoterId='" + voterId + "' AND date='" + date + "'";
            sqlConnection.Open();
            sqlCommand.CommandText = query;
            SqlDataReader aReader = sqlCommand.ExecuteReader();
            List<Treatment> treatmentList = new List<Treatment>();
            while (aReader.Read())
            {
                Treatment aTreatment = new Treatment();
                aTreatment.MedicineName = aReader["MedicineName"].ToString();
                aTreatment.DiseaseName = aReader["DiseasesName"].ToString();
                aTreatment.Does = aReader["does"].ToString();
                aTreatment.MealTime = aReader["meal_time"].ToString();
                aTreatment.Quantity = (int)aReader["quantity"];
                aTreatment.Note = aReader["note"].ToString();

                treatmentList.Add(aTreatment);

            }
            aReader.Close();
            sqlConnection.Close();
            return treatmentList;
        }

        public int CountPatient(int centerId)
        {
            string searchMedicine = "SELECT DISTINCT  tbl_treatment.patientVoterId  from tbl_treatment WHere CenterId='" + centerId + "'";
            sqlConnection.Open();
            sqlCommand.CommandText = searchMedicine;
            SqlDataReader reader = sqlCommand.ExecuteReader();
            int totalDoctor = 0;
            while (reader.Read())
            {
                string id = reader["patientVoterId"].ToString();
                totalDoctor++;
            }
            reader.Close();
            sqlConnection.Close();
            return totalDoctor;
        }

        public List<Center> GetAllCenter(int districtId, int thanaId)
        {
            string query = "SELECT * FROM tbl_center WHERE DistrictId='" + districtId + "' AND thanaId='" + thanaId + "' ORDER BY CenterName ASC";
            sqlConnection.Open();
            sqlCommand.CommandText = query;
            SqlDataReader aReader = sqlCommand.ExecuteReader();
            List<Center> centerList = new List<Center>();


            while (aReader.Read())
            {
                Center aCenter = new Center();

                aCenter.Id = (int)aReader["id"];
                aCenter.Name = aReader["CenterName"].ToString();
                aCenter.DistrictId = (int)aReader["DistrictId"];
                aCenter.ThanaId = (int)aReader["ThanaId"];
                aCenter.CenterCode = aReader["CenterCode"].ToString();
                

                centerList.Add(aCenter);

            }
            aReader.Close();
            sqlConnection.Close();
            return centerList;
        }

        public int GetTotalPatient(int centerId, int desaiseId)
        {
            string query = "SELECT  DISTINCT patientVoterId, date FROM tbl_treatment WHERE centerId='" + centerId + "' AND diseaseId='" + desaiseId + "'";

            var count = GetTotalPatientMethod(query);
            return count;
        }
        private int GetTotalPatientMethod(string query)
        {
            sqlConnection.Open();
            sqlCommand.CommandText = query;
            SqlDataReader aReader = sqlCommand.ExecuteReader();

            int count = 0;

            while (aReader.Read())
            {
                count++;
            }
            aReader.Close();
            sqlConnection.Close();
            return count;
        }

        public int GetDateWiseTotalPatientf(int centerId, int desaiseId, string fdateTime, string tdateTime)
        {
            string query = "SELECT  DISTINCT patientVoterId,date FROM tbl_treatment WHERE centerId='" + centerId + "' AND diseaseId='" + desaiseId + "' AND date>='" + fdateTime + "' AND date<='" + tdateTime + "'";

            var count = GetTotalPatientMethod(query);
            return count;
        }

        public List<Center> GetAllCenterbyDistrictId(int districtId)
        {
            string query = "SELECT * FROM tbl_center WHERE DistrictId='" + districtId + "' ORDER BY CenterName ASC";
            sqlConnection.Open();
            sqlCommand.CommandText = query;
            SqlDataReader aReader = sqlCommand.ExecuteReader();
            List<Center> centerList = new List<Center>();


            while (aReader.Read())
            {
                Center aCenter = new Center();

                aCenter.Id = (int)aReader["id"];
                aCenter.Name = aReader["CenterName"].ToString();
                aCenter.DistrictId = (int)aReader["DistrictId"];
                aCenter.ThanaId = (int)aReader["ThanaId"];
                aCenter.CenterCode = aReader["CenterCode"].ToString();


                centerList.Add(aCenter);

            }
            aReader.Close();
            sqlConnection.Close();
            return centerList;
        }

        public int GetDiseasesWiseTotalPatient(int id)
        {
            string query = "SELECT  DISTINCT patientVoterId,date FROM tbl_treatment WHERE diseaseId='" + id + "'";

            var count = GetTotalPatientMethod(query);
            return count;
        }

        public int GetTotalPatientByDate(int centerId, int desaiseId, string fdateTime, string tdateTime)
        {
            string query = "SELECT  DISTINCT patientVoterId,date FROM tbl_treatment WHERE centerId='" + centerId + "' AND diseaseId='" + desaiseId + "' AND date>='" + fdateTime + "' AND date<='" + tdateTime + "'";

            var count = GetTotalPatientMethod(query);
            return count;
        }
    }
}