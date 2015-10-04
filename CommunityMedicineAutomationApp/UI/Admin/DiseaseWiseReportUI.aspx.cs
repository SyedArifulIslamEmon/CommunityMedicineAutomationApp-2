using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using CommunityMedicineAutomationApp.BLL;
using CommunityMedicineAutomationApp.DAL.DAO;

namespace CommunityMedicineAutomationApp.UI.Admin
{
    public partial class DiseaseWiseReportUi : System.Web.UI.Page
    {
        DiseasesManager diseasesManager = new DiseasesManager();
        DistrictThanaManager districtThanaManager = new DistrictThanaManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                desiaseDropDownList.DataSource = diseasesManager.GetAllDiseases();
                desiaseDropDownList.DataTextField = "Name";
                desiaseDropDownList.DataValueField = "Id";
                desiaseDropDownList.DataBind();

                ListItem desiaseItem = new ListItem("Select Desiase", "-1");
                desiaseDropDownList.Items.Insert(0, desiaseItem);
            }
        }

        protected void showButton_Click(object sender, EventArgs e)
        {
            string fdateTime = Convert.ToDateTime(fromDateTextBox.Text).ToString("yyyy-MM-dd");
            string tdateTime = Convert.ToDateTime(toDateTextBox.Text).ToString("yyyy-MM-dd");
            if (fdateTime!=string.Empty&&tdateTime!=string.Empty)
            {
                int desaiseId = Convert.ToInt32(desiaseDropDownList.SelectedValue);
                List<Report> reports = districtThanaManager.GetReportDatewise(desaiseId, fdateTime, tdateTime);

                diseasesReportGridView.DataSource = reports;
                diseasesReportGridView.DataBind();
            }
            else
            {
                int desaiseId = Convert.ToInt32(desiaseDropDownList.SelectedValue);
                List<Report> reports = districtThanaManager.GetReport(desaiseId);

                diseasesReportGridView.DataSource = reports;
                diseasesReportGridView.DataBind();
               
            }
        }

        protected void diseasesReportGridView_PreRender(object sender, EventArgs e)
        {

            if (diseasesReportGridView.Rows.Count > 0)
            {
                diseasesReportGridView.UseAccessibleHeader = true;
                diseasesReportGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
                diseasesReportGridView.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }
}