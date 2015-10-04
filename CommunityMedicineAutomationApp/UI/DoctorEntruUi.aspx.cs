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
    public partial class DoctorEntruUi : System.Web.UI.Page
    {
        LogIn logIn = new LogIn();
        DoctorManager doctorManager = new DoctorManager();
        CenterManager centerManager = new CenterManager();
        public string centercode = null;
        protected void Page_Load(object sender, EventArgs e)
        {

            logIn = (LogIn)Session["User"];
            centercode = logIn.CenterCode;
            Center aCenter = centerManager.GetCenterIdbyCenterCode(centercode);
            centerName.Text = aCenter.Name;
            

        }
        
        protected void saveDoctorButton_Click(object sender, EventArgs e)
        {
            Doctor aDoctor = new Doctor();

            aDoctor.Name = doctorNameTextBox.Text;
            aDoctor.Degree = doctorDegreeTextBox.Text;
            aDoctor.Specialization = doctorSpecializationTextBox.Text;
            Center aCenter = centerManager.GetCenterIdbyCenterCode(centercode);
            aDoctor.CenterId = aCenter.Id;

            messageLabel.Text = doctorManager.SaveDoctor(aDoctor);
        }
    }
}