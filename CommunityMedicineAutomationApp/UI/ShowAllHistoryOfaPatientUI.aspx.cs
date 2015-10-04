using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using CommunityMedicineAutomationApp.BLL;
using CommunityMedicineAutomationApp.DAL.DAO;

namespace CommunityMedicineAutomationApp.UI
{
    public partial class ShowAllHistoryOfaPatientUi : System.Web.UI.Page
    {
       
        
        CenterManager centerManager = new CenterManager();
        public List<Treatment> treatments;
        public int CenterId;
        public string VoterId;
        public int ServiceTime = 0;

        LogIn logIn = new LogIn();
        public string centercode = null;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            logIn = (LogIn)Session["User"];
            centercode = logIn.CenterCode;
            Center aCenter = centerManager.GetCenterIdbyCenterCode(centercode);
            CenterId = aCenter.Id;
            centerName.Text = aCenter.Name;
            
        }

        protected override void CreateChildControls()
        {
            treatments = centerManager.GetNumberofServiceTaken(VoterId);
            ServiceTime = treatments.Count;
            int i = 1;
            foreach (var treatment in treatments)
            {
                List<Treatment> allTreatments = centerManager.GetAllTreatmentByDate(treatment.Date, VoterId);
                
                foreach (var service in allTreatments)
                {
                    var div = new HtmlGenericControl("div");
                    div.Attributes.Add("class", "form-inline col-sm-5");
                    div.Controls.Add(new Label() { CssClass = "btn btn-md btn-primary col-sm-12", ID = "treatment" + i, Text = "Treatment " + i });
                    div.Controls.Add(new LiteralControl("<br/>"));
                    div.Controls.Add(new Label() { CssClass = "col-sm-4", Text = "Center Name " });
                    div.Controls.Add(new TextBox() { CssClass = "form-inline col-sm-8", ID = "centerNameTextBox", Text = service.CenterName });
                    div.Controls.Add(new Label() { CssClass = "col-sm-4", Text = "Date " });
                    div.Controls.Add(new TextBox() { CssClass = "form-inline col-sm-8", ID = "datecTextBox", Text = service.Date.ToShortDateString() });
                    div.Controls.Add(new Label() { CssClass = "col-sm-4", Text = "Doctor Name " });
                    div.Controls.Add(new TextBox() { CssClass = "form-inline col-sm-8", ID = "doctorTextBox", Text = service.DoctorName });
                    div.Controls.Add(new Label() { CssClass = "col-sm-4", Text = "Observation " });
                    div.Controls.Add(new TextBox() { CssClass = "form-inline col-sm-8", ID = "observationTextBox", Text = service.Observation });
                    div.Controls.Add(new LiteralControl("<br/>"));
                    section.Controls.Add(div);
                    ShowGridView(service);
                    var div1 = new HtmlGenericControl("div");
                    div1.Controls.Add(new LiteralControl("<br/>"));
                    section.Controls.Add(div1);
                }
                i++;
            }

        }

        private void ShowGridView(Treatment service)
        {
            var gridView = new GridView();
            gridView.CssClass = "gvdatatable dataTable";
            gridView.AutoGenerateColumns = false;
            BoundField bf = new BoundField();
            bf.DataField = "DiseaseName";
            bf.HeaderText = "Diseases Name";
            gridView.Columns.Add(bf);
            bf = new BoundField();
            bf.DataField = "MedicineName";
            bf.HeaderText = "Medicine Name";
            gridView.Columns.Add(bf);
            bf = new BoundField();
            bf.DataField = "Does";
            bf.HeaderText = "Dose";
            gridView.Columns.Add(bf);
            bf = new BoundField();
            bf.DataField = "MealTime";
            bf.HeaderText = "Before/After Meal";
            gridView.Columns.Add(bf);
            bf = new BoundField();
            bf.DataField = "Quantity";
            bf.HeaderText = "Quantity";
            gridView.Columns.Add(bf);
            bf = new BoundField();
            bf.DataField = "Note";
            bf.HeaderText = "Note";
            gridView.Columns.Add(bf);

            gridView.DataSource = centerManager.GetAllTreatmentList(service.Date, VoterId);
            gridView.DataBind();
            section.Controls.Add(gridView);
        }


        protected void showDetailsButton_Click(object sender, EventArgs e)
        {
            VoterId = patientVoterIdTextBox.Text;
            //GetVoter();
            CreateChildControls();
        }

        public void GetVoter()
        {
            Voter aVoter = new Voter();
            VoterId = patientVoterIdTextBox.Text;
            aVoter.id = VoterId;
            aVoter = centerManager.GetVoterInformation(aVoter.id);

            patientNameTextBox.Text = aVoter.name;
            patientAddressTextBox.Text = aVoter.address;

        }
    }
}