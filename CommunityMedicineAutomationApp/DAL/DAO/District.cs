using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityMedicineAutomationApp.DAL.DAO
{
    public class District
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double  Population { get; set; }
        public string LoctLat { get; set; }
        public string LoctLong { get; set; }

    }

}