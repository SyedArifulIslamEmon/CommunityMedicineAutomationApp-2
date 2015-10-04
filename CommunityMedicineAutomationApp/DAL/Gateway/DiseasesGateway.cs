using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CommunityMedicineAutomationApp.DAL.DAO;

namespace CommunityMedicineAutomationApp.DAL.Gateway
{
    public class DiseasesGateway:SqlConnectionGateway
    {
        
        public bool SaveDiseases(Diseases aDiseases)
        {
            string saveMedicine = "INSERT INTO tbl_diseases (DiseasesName,Description,TreatmentProc) VALUES(@name,@discription,@treatmentProc)";
            sqlConnection.Open();
            sqlCommand.CommandText = saveMedicine;
            sqlCommand.Parameters.AddWithValue("@name", aDiseases.Name);
            sqlCommand.Parameters.AddWithValue("@discription", aDiseases.Discription);
            sqlCommand.Parameters.AddWithValue("@treatmentProc", aDiseases.TreatmentProcedure);
            int rowAffected = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            if (rowAffected > 0)
            {
                return true;
            }
            return false;
        }

        public bool IsThisDiseasesNameExists(string name)
        {
            string searchMedicine = "SELECT * FROM tbl_diseases WHERE DiseasesName='" + name + "'";
            sqlConnection.Open();
            sqlCommand.CommandText = searchMedicine;
            SqlDataReader reader = sqlCommand.ExecuteReader();
            bool isThisDiseasesExists = false;
            while (reader.Read())
            {
                isThisDiseasesExists = true;
            }
            reader.Close();
            sqlConnection.Close();
            return isThisDiseasesExists;
        }

        public List<Diseases> GetAllDiseases()
        {
            string searchMedicine = "SELECT * FROM tbl_diseases ORDER BY DiseasesName ASC";
            sqlConnection.Open();
            sqlCommand.CommandText = searchMedicine;
            SqlDataReader reader = sqlCommand.ExecuteReader();
            List<Diseases> diseasesList = new List<Diseases>();
            while (reader.Read())
            {
                Diseases aDiseases = new Diseases();
                aDiseases.Id = (int) reader["id"];
                aDiseases.Name = reader["DiseasesName"].ToString();
                aDiseases.Discription = reader["Description"].ToString();
                aDiseases.TreatmentProcedure = reader["TreatmentProc"].ToString();
                diseasesList.Add(aDiseases);

            }
            reader.Close();
            sqlConnection.Close();
            return diseasesList;
        }
    }
}