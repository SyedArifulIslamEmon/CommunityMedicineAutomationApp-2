using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using CommunityMedicineAutomationApp.BLL;
using CommunityMedicineAutomationApp.DAL.DAO;

namespace CommunityMedicineAutomationApp.UI.Admin
{
    public partial class MedicineEntryUi : System.Web.UI.Page
    {
        MedicineManager medicineManager = new MedicineManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAllMedicine();
            }
        }

        public void LoadAllMedicine()
        {
            viewMedicineGridView.DataSource = medicineManager.GetMedicine();
            viewMedicineGridView.DataBind();
            
        }
      
        protected void submitButton_Click(object sender, EventArgs e)
        {
            Medicine aMedicine = new Medicine();
            aMedicine.Name = medicineNameTextBox.Text;
            int message = medicineManager.SaveMedicine(aMedicine);
            if (message>0)
            {
                messageLabel.Text = "Successfully Saved";
                messageLabel.ForeColor= Color.Green;
                LoadAllMedicine();
            }
            else if (message==0)
            {
                messageLabel.Text = "This medicine name alresdy saved";
                messageLabel.ForeColor = Color.Red;
            }
            else
            {
                messageLabel.Text = "Saved Failed";
                messageLabel.ForeColor = Color.Red;
            }
        }

        protected void viewMedicineGridView_PreRender(object sender, EventArgs e)
        {
            LoadAllMedicine();
            if (viewMedicineGridView.Rows.Count > 0)
            {
                viewMedicineGridView.UseAccessibleHeader = true;
                viewMedicineGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                viewMedicineGridView.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }

       
    }
}