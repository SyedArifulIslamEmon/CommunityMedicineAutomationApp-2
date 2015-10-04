using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityMedicineAutomationApp.DAL.DAO
{
    public class Diseases
    {
        public int  Id { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public string TreatmentProcedure { get; set; }
    }
}