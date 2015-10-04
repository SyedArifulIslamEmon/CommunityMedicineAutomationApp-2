using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityMedicineAutomationApp.DAL.DAO
{
    public class Report
    {
        public int Id { get; set; }
        public string DistrictName { get; set; }
        public string DistrictLoclot { get; set; }
        public string DistrictLocLong { get; set; }
        public double TotalPatient { get; set; }
        public double PopulationPercent { get; set; }
        public string DiseasesName { get; set; }
    }
}