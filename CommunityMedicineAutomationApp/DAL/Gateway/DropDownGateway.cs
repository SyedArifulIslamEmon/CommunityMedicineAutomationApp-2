using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CommunityMedicineAutomationApp.DAL.DAO;

namespace CommunityMedicineAutomationApp.DAL.Gateway
{
    public class DropDownGateway:SqlConnectionGateway
    {
        public List<District> GetAllDistrict()
        {
            string searchMedicine = "SELECT * FROM tbl_destrict Order By District ASC";
            sqlConnection.Open();
            sqlCommand.CommandText = searchMedicine;
            SqlDataReader reader = sqlCommand.ExecuteReader();
            List<District> districtList = new List<District>();
            while (reader.Read())
            {
                District aDistrict = new District();
                aDistrict.Id = Convert.ToInt32(reader["id"].ToString());
                aDistrict.Name = reader["District"].ToString();
                districtList.Add(aDistrict);

            }
            reader.Close();
            sqlConnection.Close();
            return districtList;
        }

        public List<Thana> GetAllThana(int id)
        {
            string searchMedicine = "SELECT * FROM tbl_thana where DistrictId='"+id+"' Order By Thana ASC";
            sqlConnection.Open();
            sqlCommand.CommandText = searchMedicine;
            SqlDataReader reader = sqlCommand.ExecuteReader();
            List<Thana> thanaList = new List<Thana>();
            while (reader.Read())
            {
                Thana aThana = new Thana();
                aThana.Id = Convert.ToInt32(reader["id"].ToString());
                aThana.Name = reader["Thana"].ToString();
                thanaList.Add(aThana);

            }
            reader.Close();
            sqlConnection.Close();
            return thanaList;
        }

        public string GetDistrict(int districtId)
        {
            string searchMedicine = "SELECT * FROM tbl_destrict where id='" + districtId + "' ";
            sqlConnection.Open();
            sqlCommand.CommandText = searchMedicine;
            SqlDataReader reader = sqlCommand.ExecuteReader();
            District aDistrict = new District();
            while (reader.Read())
            {
                aDistrict.Name = reader["District"].ToString();
            }
            reader.Close();
            sqlConnection.Close();
            return aDistrict.Name;
        }

        public string GetThana(int thanaId)
        {
            string searchMedicine = "SELECT * FROM tbl_thana where id='" + thanaId + "'";
            sqlConnection.Open();
            sqlCommand.CommandText = searchMedicine;
            SqlDataReader reader = sqlCommand.ExecuteReader();
            Thana aThana = new Thana();
            while (reader.Read())
            {
                aThana.Name = reader["Thana"].ToString();
            }
            reader.Close();
            sqlConnection.Close();
            return aThana.Name;
        }

        public List<Center> GetAllCenter(int id)
        {
            string searchMedicine = "SELECT * FROM tbl_center where ThanaId='" + id + "' Order By CenterName ASC";
            sqlConnection.Open();
            sqlCommand.CommandText = searchMedicine;
            SqlDataReader reader = sqlCommand.ExecuteReader();
            List<Center> centerList = new List<Center>();
            while (reader.Read())
            {
                Center aCenter = new Center();
                aCenter.Id = Convert.ToInt32(reader["id"].ToString());
                aCenter.Name = reader["CenterName"].ToString();
                centerList.Add(aCenter);

            }
            reader.Close();
            sqlConnection.Close();
            return centerList;
        }
    }
}