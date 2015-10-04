using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using CommunityMedicineAutomationApp.BLL;
using CommunityMedicineAutomationApp.DAL.DAO;

namespace CommunityMedicineAutomationApp.UI.Admin
{
    public partial class AllDiseasesBarChartUi : System.Web.UI.Page
    {
        DropDownManager dropDownManager = new DropDownManager();
        DistrictThanaManager districtThanaManager = new DistrictThanaManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                districtDropDownList.DataSource = dropDownManager.GetAllDistrict();
                districtDropDownList.DataTextField = "Name";
                districtDropDownList.DataValueField = "Id";
                districtDropDownList.DataBind();

                ListItem liDistrict = new ListItem("Select District","-1");
                districtDropDownList.Items.Insert(0,liDistrict);

                GetDiseasesWiseReport();
            }

        }

       
        protected void showButton_Click(object sender, EventArgs e)
        {
            string fdateTime = Convert.ToDateTime(fromDateTextBox.Text).ToString("yyyy-MM-dd");
            string tdateTime = Convert.ToDateTime(toDateTextBox.Text).ToString("yyyy-MM-dd");
            if (fdateTime != string.Empty && tdateTime != string.Empty)
            {
                int districtId = Convert.ToInt32(districtDropDownList.SelectedValue);
                List<Report> reports = districtThanaManager.GetReportDatewiseInaDistrict(districtId, fdateTime, tdateTime);
                diseaseBarChart.DataSource = reports;
                diseaseBarChart.DataBind();
            }
            else
            {
                int districtId = Convert.ToInt32(districtDropDownList.SelectedValue);
                List<Report> repotList = districtThanaManager.GetReportforBarChart(districtId);
                diseaseBarChart.DataSource = repotList;
                diseaseBarChart.DataBind();
            }
           
        }

        public void GetDiseasesWiseReport()
        {
            List<Report> repotList = districtThanaManager.GetDiseasesWiseReport();
            diseaseBarChart.DataSource = repotList;
            diseaseBarChart.DataBind();
        }
    }
}