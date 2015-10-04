using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityMedicineAutomationApp.DAL.DAO
{
    public class Voter
    {
        public string id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public DateTime date_of_birth { get; set; }
    }
    public class RootObject
    {
        public List<Voter> Voters { get; set; }
    }
}