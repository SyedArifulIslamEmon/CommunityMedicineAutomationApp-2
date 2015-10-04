using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CommunityMedicineAutomationApp.DAL.DAO;
using CommunityMedicineAutomationApp.DAL.Gateway;

namespace CommunityMedicineAutomationApp.BLL
{
    public class MedicineManager
    {
        MedicineGateway medicineGateway = new MedicineGateway();
        public int SaveMedicine(Medicine aMedicine)
        {
            if (medicineGateway.IsThisMedicineExists(aMedicine.Name))
            {
                return 0;
            }
            else
            {
                if (medicineGateway.SaveMedicine(aMedicine))
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
           
        }

        public List<Medicine> GetMedicine()
        {
            return medicineGateway.GetMedicine();
        }

        public string SaveAllSandMedicine(List<SendMedicine> sendMedicines)
        {
            if (medicineGateway.SaveAllSandMedicine(sendMedicines))
            {
                return "Medicine Send";
            }
            else
            {
                return "Send Faild";
            }
        }

        public List<Medicine> Getreport(int centerId)
        {
            return medicineGateway.Getreport(centerId);
        }

        public List<Medicine> GetAllMedicineInfobyCenterId(object centerId)
        {
            return medicineGateway.GetAllMedicineInfobyCenterId(centerId);
        }

        public int GetStockMedicine(int id, int centerId)
        {
            return medicineGateway.GetStockMedicine(id, centerId);
        }
    }
}