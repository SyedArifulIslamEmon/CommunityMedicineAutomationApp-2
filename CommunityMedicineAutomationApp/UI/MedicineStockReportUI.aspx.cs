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
    public partial class MedicineStockReportUi : System.Web.UI.Page
    {
        
        CenterManager centerManager = new CenterManager();
        MedicineManager medicineManager = new MedicineManager();
        LogIn logIn = new LogIn();
        public string centercode = null;
        public int CenterId;
        protected void Page_Load(object sender, EventArgs e)
        {

            logIn = (LogIn)Session["User"];
            centercode = logIn.CenterCode;
            Center aCenter = centerManager.GetCenterIdbyCenterCode(centercode);
            CenterId = aCenter.Id;
            centerName.Text = aCenter.Name;
            
        }

        private void LoadGridView()
        {
            viewMedicineStockGridView.DataSource = medicineManager.Getreport(CenterId);
            viewMedicineStockGridView.DataBind();
        }

        protected void viewMedicineStockGridView_PreRender(object sender, EventArgs e)
        {
            LoadGridView();
            if (viewMedicineStockGridView.Rows.Count > 0)
            {
                viewMedicineStockGridView.UseAccessibleHeader = true;
                viewMedicineStockGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                viewMedicineStockGridView.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }
}