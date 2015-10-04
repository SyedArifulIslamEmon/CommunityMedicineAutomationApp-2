using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CommunityMedicineAutomationApp.DAL.DAO;

namespace CommunityMedicineAutomationApp.DAL.Gateway
{
    public class DoctorGatetway:SqlConnectionGateway
    {
        
        public bool SaveDoctor(Doctor aDoctor)
        {
            string saveDoctor = "INSERT INTO tbl_doctor (name,degree,specialization,CenterId) VALUES(@name,@degree,@specialization,@centerId)";
            sqlConnection.Open();
            sqlCommand.CommandText = saveDoctor;
            sqlCommand.Parameters.AddWithValue("@name", aDoctor.Name);
            sqlCommand.Parameters.AddWithValue("@degree", aDoctor.Degree);
            sqlCommand.Parameters.AddWithValue("@specialization", aDoctor.Specialization);
            sqlCommand.Parameters.AddWithValue("@centerId", aDoctor.CenterId);
            int rowAffected = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            if (rowAffected > 0)
            {
                return true;
            }
            return false;
        }

        public bool IsThisDoctorNameExists(Doctor aDoctor)
        {
            string searchMedicine = "SELECT * FROM tbl_doctor WHERE Name='" + aDoctor.Name + "' AND degree='" + aDoctor.Degree + "' AND specialization='" + aDoctor.Specialization + "'";
            sqlConnection.Open();
            sqlCommand.CommandText = searchMedicine;
            SqlDataReader reader = sqlCommand.ExecuteReader();
            bool isThisDOctorNameExists = false;
            while (reader.Read())
            {
                isThisDOctorNameExists = true;
            }
            reader.Close();
            sqlConnection.Close();
            return isThisDOctorNameExists;
        }

        public int CountDoctor(int centerId)
        {
            string searchMedicine = "Select COUNT(*)TotalDoctor From tbl_doctor WHere CenterId='"+centerId+"'";
            sqlConnection.Open();
            sqlCommand.CommandText = searchMedicine;
            SqlDataReader reader = sqlCommand.ExecuteReader();
            int totalDoctor = 0;
            while (reader.Read())
            {
                totalDoctor = (int) reader["TotalDoctor"];
            }
            reader.Close();
            sqlConnection.Close();
            return totalDoctor;
        }
        public List<Doctor> GetAllDoctorByCenterId(int centerId)
        {
            string query = "SELECT * FROM tbl_doctor WHERE CenterId ='" + centerId + "' ORDER BY name ASC";
            sqlConnection.Open();
            sqlCommand.CommandText = query;
            SqlDataReader reader = sqlCommand.ExecuteReader();
            List<Doctor> doctorList = new List<Doctor>();
            string name = "";
            string specia = "";
            while (reader.Read())
            {
                Doctor aDoctor = new Doctor();
                aDoctor.Id = (int)reader["id"];
                name = reader["name"].ToString();
                specia = reader["specialization"].ToString();
                aDoctor.Name = name + " (" + specia + ")";
                doctorList.Add(aDoctor);
            }
            reader.Close();
            sqlConnection.Close();
            return doctorList;
        }
    }
}