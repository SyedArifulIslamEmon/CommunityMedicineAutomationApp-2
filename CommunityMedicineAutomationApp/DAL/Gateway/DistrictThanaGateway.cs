using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CommunityMedicineAutomationApp.DAL.DAO;

namespace CommunityMedicineAutomationApp.DAL.Gateway
{
    public class DistrictThanaGateway:SqlConnectionGateway
    {
        public List<District> GetAllDistrict()
        {
            string query = "SELECT * FROM tbl_destrict ORDER BY District ASC";
            sqlConnection.Open();
            sqlCommand.CommandText = query;
            SqlDataReader aReader = sqlCommand.ExecuteReader();
            List<District> districtList = new List<District>();


            while (aReader.Read())
            {
                District aDistrict = new District();

                aDistrict.Id = (int)aReader["id"];
                aDistrict.Name = aReader["District"].ToString();
                aDistrict.Population = Convert.ToDouble(aReader["Population"].ToString());
                aDistrict.LoctLat = aReader["loclat"].ToString();
                aDistrict.LoctLong = aReader["loclong"].ToString();
                districtList.Add(aDistrict);

            }
            aReader.Close();
            sqlConnection.Close();
            return districtList;
        }

        public List<Thana> GetAllThana(int id)
        {
            string query = "SELECT * FROM tbl_thana WHERE DistrictId='" + id + "'";
            sqlConnection.Open();
            sqlCommand.CommandText = query;
            SqlDataReader aReader = sqlCommand.ExecuteReader();
            List<Thana> thanaList = new List<Thana>();


            while (aReader.Read())
            {
                Thana aThana = new Thana();

                aThana.Id = (int)aReader["id"];
                aThana.Name = aReader["Thana"].ToString();
                aThana.DistrictId = (int)aReader["DistrictId"];

                thanaList.Add(aThana);

            }
            aReader.Close();
            sqlConnection.Close();
            return thanaList;
        }
    }
}