using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CommunityMedicineAutomationApp.DAL.Gateway
{
    public class SqlConnectionGateway
    {
        protected SqlConnection sqlConnection;
        public SqlCommand sqlCommand;

        public SqlConnectionGateway()
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["CommunityMedicineAutomationDBConnString"].ConnectionString);
            sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
        }
    }
}