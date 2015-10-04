using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CommunityMedicineAutomationApp.DAL.DAO;
using CommunityMedicineAutomationApp.DAL.Gateway;

namespace CommunityMedicineAutomationApp.BLL
{
    public class DiseasesManager
    {
        DiseasesGateway diseasesGateway = new DiseasesGateway();

        public int SaveDiseases(Diseases aDiseases)
        {
            if (diseasesGateway.IsThisDiseasesNameExists(aDiseases.Name))
            {
                return 0;
            }
            else
            {
                if (diseasesGateway.SaveDiseases(aDiseases))
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
           
            }
        }

        public List<Diseases> GetAllDiseases()
        {
            return diseasesGateway.GetAllDiseases();
        }

     
    }
}