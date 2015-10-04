using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityMedicineAutomationApp.DAL.DAO
{
    [Serializable]
    public class Treatment
    {
        public int Id { get; set; }
        public string Observation { get; set; }
        public DateTime Date { get; set; }
        public string PatientVoterId { get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public int DiseaseId { get; set; }
        public string DiseaseName { get; set; }
        public int MedicineId { get; set; }
        public string MedicineName { get; set; }
        public string Does { get; set; }
        public string MealTime { get; set; }
        public int Quantity { get; set; }
        public string Note { get; set; }
        public int CenterId { get; set; }
        public string CenterName { get; set; }
       
    }
}