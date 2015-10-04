using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CommunityMedicineAutomationApp.DAL.DAO;
using CommunityMedicineAutomationApp.DAL.Gateway;

namespace CommunityMedicineAutomationApp.BLL
{
    public class DropDownManager
    {
        DropDownGateway dropDownGateway = new DropDownGateway();
        public List<District> GetAllDistrict()
        {
            return dropDownGateway.GetAllDistrict();
        }

        public List<Thana> GetAllThana(int id)
        {
            return dropDownGateway.GetAllThana(id);
        }

        public string GetDistrict(int districtId)
        {
            return dropDownGateway.GetDistrict(districtId);
        }

        public string GetThana(int thanaId)
        {
            return dropDownGateway.GetThana(thanaId);
        }


        public List<Center> GetAllCenter(int id)
        {
            return dropDownGateway.GetAllCenter(id);
        }
    }
}