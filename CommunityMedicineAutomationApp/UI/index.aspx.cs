using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CommunityMedicineAutomationApp.BLL;
using CommunityMedicineAutomationApp.DAL.DAO;

namespace CommunityMedicineAutomationApp.UI
{
    public partial class index : System.Web.UI.Page
    {
        
        DoctorManager doctorManager = new DoctorManager();
        CenterManager centerManager = new CenterManager();
        LogIn logIn = new LogIn();
        public string centercode = null;
        public int CenterId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                logIn = (LogIn)Session["User"];
                centercode = logIn.CenterCode;
                Center aCenter = centerManager.GetCenterIdbyCenterCode(centercode);
                CenterId = aCenter.Id;
                centerName.Text = aCenter.Name;
                centerName1.Text = aCenter.Name;
                countDoctorLabel.Text = doctorManager.CountDoctor(CenterId).ToString();
                countPatientLabel.Text = centerManager.CountPatient(CenterId).ToString();
            }
            
        }

    }
}