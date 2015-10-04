using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CommunityMedicineAutomationApp.BLL;
using CommunityMedicineAutomationApp.DAL.DAO;

namespace CommunityMedicineAutomationApp.UI.Admin
{
    public partial class SendMedicineUi : System.Web.UI.Page
    {
        DropDownManager dropDownManager = new DropDownManager();
        MedicineManager medicineManager = new MedicineManager();
        SendMedicine sendMedicine = new SendMedicine();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                districtDropDownList.DataSource = dropDownManager.GetAllDistrict();
                districtDropDownList.DataTextField = "Name";
                districtDropDownList.DataValueField = "Id";
                districtDropDownList.DataBind();

                medicineDropDownList.DataSource = medicineManager.GetMedicine();
                medicineDropDownList.DataTextField = "Name";
                medicineDropDownList.DataValueField = "Id";
                medicineDropDownList.DataBind();

                ListItem liDistrict = new ListItem("Select District", "-1");
                districtDropDownList.Items.Insert(0, liDistrict);
                ListItem liThana = new ListItem("Select Thana", "-1");
                thanaDropDownList.Items.Insert(0, liThana);
                ListItem liCenter = new ListItem("Select Center", "-1");
                centerDropDownList.Items.Insert(0, liCenter);
                ListItem liMedicine = new ListItem("Select Medicine", "-1");
                medicineDropDownList.Items.Insert(0, liMedicine);
            }

        }

        protected void districtDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(districtDropDownList.SelectedValue);
            thanaDropDownList.DataSource = dropDownManager.GetAllThana(id);
            thanaDropDownList.DataTextField = "Name";
            thanaDropDownList.DataValueField = "Id";
            thanaDropDownList.DataBind();

            ListItem liThana = new ListItem("Select Thana", "-1");
            thanaDropDownList.Items.Insert(0, liThana);
            
        }

        protected void thanaDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(thanaDropDownList.SelectedValue);
            centerDropDownList.DataSource = dropDownManager.GetAllCenter(id);
            centerDropDownList.DataTextField = "Name";
            centerDropDownList.DataValueField = "Id";
            centerDropDownList.DataBind();

            ListItem liCenter = new ListItem("Select Center", "-1");
            centerDropDownList.Items.Insert(0, liCenter);
        }

        public List<SendMedicine> SendMedicines
        {
            get
            {
                if (this.ViewState["medicine"] == null)
                {
                    this.ViewState["medicine"] = new List<SendMedicine>();
                }
                return (List<SendMedicine>)(this.ViewState["medicine"]);
            }
            set { this.ViewState["medicine"] = value; }
        }
        protected void addButton_Click(object sender, EventArgs e)
        {
            sendMedicine.DistrictId = Convert.ToInt32(districtDropDownList.SelectedValue);
            sendMedicine.ThanaId = Convert.ToInt32(thanaDropDownList.SelectedValue);
            sendMedicine.CenterId = Convert.ToInt32(centerDropDownList.SelectedValue);
            sendMedicine.MedicineId = Convert.ToInt32(medicineDropDownList.SelectedValue);
            sendMedicine.Quantity = Convert.ToInt32(quantityTextBox.Text);
            sendMedicine.MedicineName = medicineDropDownList.SelectedItem.Text;
            SendMedicines.Add(sendMedicine);
            ViewState["SendMedicines"] = sendMedicine;
            ShowInGridView();
        }

        private void ShowInGridView()
        {
            sendMedicine = (SendMedicine)ViewState["SendMedicines"];
            showMedicineGridView.DataSource = SendMedicines;
            showMedicineGridView.DataBind();
        }

        protected void sendMedicineButton_Click(object sender, EventArgs e)
        {
            sendMedicine = (SendMedicine)ViewState["SendMedicines"];
            messageLabel.Text = medicineManager.SaveAllSandMedicine(SendMedicines);
            ViewState.Clear();
        }

        
        

    }
}