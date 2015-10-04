using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityMedicineAutomationApp.DAL.DAO
{
    [Serializable]
    public class Center
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CenterCode { get; set; }
        public string Password { get; set; }
        public int DistrictId { get; set; }
        public int ThanaId { get; set; }
    }
}