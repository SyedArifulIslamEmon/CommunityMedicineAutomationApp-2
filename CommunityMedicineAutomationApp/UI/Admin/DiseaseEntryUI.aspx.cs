using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CommunityMedicineAutomationApp.BLL;
using CommunityMedicineAutomationApp.DAL.DAO;

namespace CommunityMedicineAutomationApp.UI.Admin
{
    public partial class DiseaseEntryUi : System.Web.UI.Page
    {
        DiseasesManager diseasesManager = new DiseasesManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAllDiseases();
            }
        }

        protected void saveDiseasesButton_Click(object sender, EventArgs e)
        {
            Diseases aDiseases = new Diseases();
            aDiseases.Name = diseasesNameTextBox.Text;
            aDiseases.Discription = discriptionTextBox.Text;
            aDiseases.TreatmentProcedure = treatmentProcedureTextBox.Text;
            int message = diseasesManager.SaveDiseases(aDiseases);
            if (message > 0)
            {
                messageLabel.Text = "Successfully Saved";
                messageLabel.ForeColor = Color.Green;
                LoadAllDiseases();
               
            }
            else if (message == 0)
            {
                messageLabel.Text = "This Diseases name alresdy saved";
                messageLabel.ForeColor = Color.Red;
            }
            else
            {
                messageLabel.Text = "Saved Failed";
                messageLabel.ForeColor = Color.Red;
            }
        }

        public void LoadAllDiseases()
        {
            viewDiseasesGridView.DataSource = diseasesManager.GetAllDiseases();
            viewDiseasesGridView.DataBind();
        }

        protected void viewDiseasesGridView_PreRender(object sender, EventArgs e)
        {
            LoadAllDiseases();
            if (viewDiseasesGridView.Rows.Count > 0)
            {
                viewDiseasesGridView.UseAccessibleHeader = true;
                viewDiseasesGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                viewDiseasesGridView.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
      
    }
}