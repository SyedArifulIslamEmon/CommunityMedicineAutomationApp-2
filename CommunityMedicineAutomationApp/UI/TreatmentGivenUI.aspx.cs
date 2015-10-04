using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using CommunityMedicineAutomationApp.BLL;
using CommunityMedicineAutomationApp.DAL.DAO;

namespace CommunityMedicineAutomationApp.UI
{
    public partial class TreatmentGivenUi : System.Web.UI.Page
    {
        CenterManager centerManager = new CenterManager();
        MedicineManager medicineManager = new MedicineManager();
        DiseasesManager diseasesManager  = new DiseasesManager();
        DoctorManager doctorManager = new DoctorManager();
        Treatment aTreatment = new Treatment();
        LogIn logIn = new LogIn();
        public string centercode = null;
        public int centerId;
        protected void Page_Load(object sender, EventArgs e)
        {
            logIn = (LogIn)Session["User"];
            centercode = logIn.CenterCode;
            Center aCenter = centerManager.GetCenterIdbyCenterCode(centercode);
            centerName.Text = aCenter.Name;
            centerId = aCenter.Id;
            if (!IsPostBack)
            {
             
                medicineDropDownList.DataSource = medicineManager.GetAllMedicineInfobyCenterId(centerId);
                medicineDropDownList.DataTextField = "Name";
                medicineDropDownList.DataValueField = "Id";
                medicineDropDownList.DataBind();

                diseaseDropDownList.DataSource = diseasesManager.GetAllDiseases();
                diseaseDropDownList.DataTextField = "Name";
                diseaseDropDownList.DataValueField = "Id";
                diseaseDropDownList.DataBind();

                doctorDropDownList.DataSource = doctorManager.GetAllDoctor(centerId);
                doctorDropDownList.DataTextField = "Name";
                doctorDropDownList.DataValueField = "Id";
                doctorDropDownList.DataBind();

                ListItem medicineItem = new ListItem("Select Medicine", "-1");
                medicineDropDownList.Items.Insert(0, medicineItem);

                ListItem diseaseItem = new ListItem("Select Disease", "-1");
                diseaseDropDownList.Items.Insert(0, diseaseItem);

                ListItem doctorItem = new ListItem("Select Doctor", "-1");
                doctorDropDownList.Items.Insert(0, doctorItem);

                ListItem doseItem = new ListItem("Select One", "-1");
                doesDropDownList.Items.Insert(0, doseItem);
            }
            
        }

        public List<Treatment> Treatments
        {
            get
            {
                if (this.ViewState["Treatments"] == null)
                {
                    this.ViewState["Treatments"] = new List<Treatment>();
                }
                return (List<Treatment>)(this.ViewState["Treatments"]);
            }
            set { this.ViewState["Treatments"] = value; }
        }
       
        protected void showDetailsButton_Click1(object sender, EventArgs e)
        {
            Voter aVoter = new Voter();
            string voterId = patientVoterIdTextBox.Text;
            aVoter.id = voterId;
            aVoter = centerManager.GetVoterInformation(aVoter.id);

            patientNameTextBox.Text = aVoter.name;
            patientAddressTextBox.Text = aVoter.address;

            patientAgeTextBox.Text = centerManager.CalculateAge(aVoter.date_of_birth).ToString();

            List<Treatment> treatMent = centerManager.GetNumberofServiceTaken(voterId);
            int serviceGiven = 0;
            foreach (var count in treatMent)
            {
                if (count != null)
                {
                    serviceGiven++;
                }
            }
            serviceTimeTextBox.Text = serviceGiven.ToString();
        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            aTreatment.PatientVoterId = patientVoterIdTextBox.Text;
            aTreatment.Observation = observationTextBox.Text;
            aTreatment.Date = Convert.ToDateTime(dateTextBox.Text);
            aTreatment.DoctorId = Convert.ToInt32(doctorDropDownList.SelectedValue);
            aTreatment.DiseaseId = Convert.ToInt32(diseaseDropDownList.SelectedValue);
            aTreatment.DiseaseName = diseaseDropDownList.SelectedItem.Text;
            aTreatment.MedicineName = medicineDropDownList.SelectedItem.Text;
            aTreatment.MedicineId = Convert.ToInt32(medicineDropDownList.SelectedValue);
            aTreatment.Does = doesDropDownList.SelectedItem.Text;
            aTreatment.CenterId = centerId;
            if (beforeMealRadioButton.Checked)
            {
                aTreatment.MealTime = "Take Before Meal";
            }
            else if (afterMealRadioButton.Checked)
            {
                aTreatment.MealTime = "Take After Meal";
            }
            aTreatment.Quantity = Convert.ToInt32(quantityTextBox.Text);

            int stock = Convert.ToInt32(stockTextBox.Text);
            if (stock > aTreatment.Quantity)
            {
                aTreatment.Note = noteTextBox.Text;

                Treatments.Add(aTreatment);
                ViewState["Treatment"] = aTreatment;
                LoadGridView();
            }
            else
            {
                messageLabel.Text = "Insufficient Stock";
            }
        }

        private void LoadGridView()
        {
            aTreatment = (Treatment)ViewState["Treatment"];
            addTreatmentGridView.DataSource = Treatments;
            addTreatmentGridView.DataBind();

        }
        protected void saveTreatmentButton_Click(object sender, EventArgs e)
        {
            if (addTreatmentGridView.Rows.Count == 0 || patientAgeTextBox.Text == "")
            {

                messageLabel.Text = "Please Add Information First";
            }
            else
            {

                messageLabel.Text = centerManager.SaveTreatmentInfo(Treatments);

                ViewState.Clear();
            }
        }

        protected void medicineDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            stockTextBox.Text = "";
            if (medicineDropDownList.SelectedValue != "-1")
            {
                int id = Convert.ToInt32(medicineDropDownList.SelectedValue);
                stockTextBox.Text = Convert.ToInt32(medicineManager.GetStockMedicine(id, centerId)).ToString();
            }
        }

        protected void showAllHistoryButton_Click(object sender, EventArgs e)
        {
            Session["voterID"] = patientVoterIdTextBox.Text;
            Server.Transfer("ShowAllHistoryOfaPatientUI.aspx");
            //Response.Redirect("ShowAllHistoryOfaPatientUI.aspx");
        }
    }
}