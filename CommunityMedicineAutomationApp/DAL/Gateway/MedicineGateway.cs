using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using CommunityMedicineAutomationApp.DAL.DAO;

namespace CommunityMedicineAutomationApp.DAL.Gateway
{
    public class MedicineGateway:SqlConnectionGateway
    {
       
        public bool SaveMedicine(Medicine aMedicine)
        {
            string saveMedicine = "INSERT INTO tbl_medicine (MedicineName) VALUES(@name)";
            sqlConnection.Open();
            sqlCommand.CommandText = saveMedicine;
            sqlCommand.Parameters.AddWithValue("@name", aMedicine.Name);
            int rowAffected = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            if (rowAffected > 0)
            {
                return true;
            }
            return false;
        }

        public bool IsThisMedicineExists(string medicineName)
        {
            string searchMedicine = "SELECT * FROM tbl_medicine WHERE MedicineName='" + medicineName + "'";
            sqlConnection.Open();
            sqlCommand.CommandText = searchMedicine;
            SqlDataReader reader = sqlCommand.ExecuteReader();
            bool isThisMedicineExists = false;
            while (reader.Read())
            {
                isThisMedicineExists = true;
            }
            reader.Close();
            sqlConnection.Close();
            return isThisMedicineExists;
        }

        public List<Medicine> GetMedicine()
        {
            
            string searchMedicine = "SELECT * FROM tbl_medicine";
            sqlConnection.Open();
            sqlCommand.CommandText = searchMedicine;
            SqlDataReader reader = sqlCommand.ExecuteReader();
            List<Medicine> medicineList = new List<Medicine>();
            while (reader.Read())
            {
                Medicine medicine = new Medicine();
                medicine.Id = Convert.ToInt32(reader["id"].ToString());
                medicine.Name = reader["MedicineName"].ToString();
                medicineList.Add(medicine);
               
            }
            reader.Close();
            sqlConnection.Close();
            return medicineList;

        }

        public bool SaveAllSandMedicine(List<SendMedicine> sendMedicines)
        {
           
            int rowaffected = 0;
            foreach (var saveMedicine in sendMedicines)
            {
                if (IsThisMedicineExistsInThisCenter(saveMedicine.MedicineId,saveMedicine.CenterId))
                {
                    string query = "UPDATE tbl_send_medicine SET Quentity+='"+saveMedicine.Quantity+"' where MedicineId='"+saveMedicine.MedicineId+"' AND CenterId='"+saveMedicine.CenterId+"' ";
                    sqlConnection.Open();
                    sqlCommand.CommandText = query;
                    sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@districtId", saveMedicine.DistrictId);
                    sqlCommand.Parameters.AddWithValue("@thanaId", saveMedicine.ThanaId);
                    sqlCommand.Parameters.AddWithValue("@centerId", saveMedicine.CenterId);
                    sqlCommand.Parameters.AddWithValue("@medicineId", saveMedicine.MedicineId);
                    sqlCommand.Parameters.AddWithValue("@quantity", saveMedicine.Quantity);
                    rowaffected = sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                else
                {
                    string query = "INSERT INTO tbl_send_medicine(DistrictId,ThanaId,CenterId,MedicineId,Quentity) VALUES(@districtId,@thanaId,@centerId,@medicineId,@quantity)";
                    sqlConnection.Open();
                    sqlCommand.CommandText = query;
                    sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@districtId", saveMedicine.DistrictId);
                    sqlCommand.Parameters.AddWithValue("@thanaId", saveMedicine.ThanaId);
                    sqlCommand.Parameters.AddWithValue("@centerId", saveMedicine.CenterId);
                    sqlCommand.Parameters.AddWithValue("@medicineId", saveMedicine.MedicineId);
                    sqlCommand.Parameters.AddWithValue("@quantity", saveMedicine.Quantity);
                    rowaffected = sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                
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

        private bool IsThisMedicineExistsInThisCenter(int medicineId, int centerId)
        {
            string searchMedicine = "SELECT * FROM tbl_send_medicine WHERE MedicineId='" + medicineId + "' AND CenterId='"+centerId+"'";
            sqlConnection.Open();
            sqlCommand.CommandText = searchMedicine;
            SqlDataReader reader = sqlCommand.ExecuteReader();
            bool isThisMedicineExists = false;
            while (reader.Read())
            {
                isThisMedicineExists = true;
            }
            reader.Close();
            sqlConnection.Close();
            return isThisMedicineExists;
        }

        public List<Medicine> Getreport(int centerId)
        {
            sqlConnection.Open();
            string query = "select tbl_medicine.MedicineName, tbl_send_medicine.Quentity from tbl_send_medicine join tbl_medicine on tbl_medicine.id = tbl_send_medicine.MedicineId where CenterId='" + centerId + "' ORDER BY MedicineName ASC ";
            sqlCommand.CommandText = query;
            SqlDataReader reader = sqlCommand.ExecuteReader();
            List<Medicine> medicineReportList = new List<Medicine>();
            while (reader.Read())
            {
                Medicine aMedicine = new Medicine();
                aMedicine.Name = reader["MedicineName"].ToString();
                aMedicine.Quantity = Convert.ToInt32(reader["Quentity"].ToString());

                medicineReportList.Add(aMedicine);
            }
            reader.Close();
            sqlConnection.Close();

            return medicineReportList;
        }


        public List<Medicine> GetAllMedicineInfobyCenterId(object centerId)
        {
            string query = "Select tbl_medicine.MedicineName, tbl_medicine.id from tbl_medicine join tbl_send_medicine ON tbl_medicine.id=tbl_send_medicine.MedicineId Where tbl_send_medicine.CenterId='"+centerId+"' Order By MedicineName ASC";
            sqlConnection.Open();
            sqlCommand.CommandText = query;
            sqlCommand = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            List<Medicine> medicineList = new List<Medicine>();

            while (reader.Read())
            {
                Medicine aMedicine = new Medicine();
                aMedicine.Id = (int) reader["id"];
                aMedicine.Name = reader["MedicineName"].ToString();
                
                medicineList.Add(aMedicine);
            }
            reader.Close();
            sqlConnection.Close();
           return medicineList;
        }

        public int GetStockMedicine(int id, int centerId)
        {
            string query = "SELECT Quentity FROM tbl_send_medicine WHERE MedicineId='" + id + "'AND CenterId='" + centerId + "'";
            sqlConnection.Open();
            sqlCommand.CommandText = query;
            sqlCommand = new SqlCommand(query, sqlConnection);
            SqlDataReader aReader = sqlCommand.ExecuteReader();

            int quantity = 0;
            while (aReader.Read())
            {

                quantity = (int)aReader["Quentity"];

            }
            aReader.Close();
            sqlConnection.Close();
            return quantity;
        }
    }
}