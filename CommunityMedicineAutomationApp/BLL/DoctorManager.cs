using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CommunityMedicineAutomationApp.DAL.DAO;
using CommunityMedicineAutomationApp.DAL.Gateway;

namespace CommunityMedicineAutomationApp.BLL
{
    public class DoctorManager
    {
        DoctorGatetway doctorGatetway = new DoctorGatetway();
        public string SaveDoctor(Doctor aDoctor)
        {
            if (doctorGatetway.IsThisDoctorNameExists(aDoctor))
            {
                return "Doctor Name already Saved";
            }
            else
            {
                if (doctorGatetway.SaveDoctor(aDoctor))
                {
                    return "Successfully Saved";
                }
                else
                {
                    return "Save failed";
                }
                
            }
            
        }

        public int CountDoctor(int centerId)
        {
            return doctorGatetway.CountDoctor(centerId);
        }
        public List<Doctor> GetAllDoctor(int centerId)
        {
            return doctorGatetway.GetAllDoctorByCenterId(centerId);
        }
    }
}