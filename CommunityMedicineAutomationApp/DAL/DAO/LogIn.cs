using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityMedicineAutomationApp.DAL.DAO
{
    [Serializable]
    public class LogIn
    {
        public string CenterCode { get; set; }
        public string Password { get; set; }
    }
}