using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web.UI.WebControls;
using CommunityMedicineAutomationApp.BLL;
using CommunityMedicineAutomationApp.DAL.DAO;
using EGIS.Web.Controls;
using Subgurim.Controles;
using Subgurim.Controles.GoogleChartIconMaker;

namespace CommunityMedicineAutomationApp.UI.Admin
{
    public partial class DiseaseDemographicReportUi : System.Web.UI.Page
    {
        DiseasesManager diseasesManager = new DiseasesManager();
        DistrictThanaManager districtThanaManager=new DistrictThanaManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                diseaseDropDownList.DataSource = diseasesManager.GetAllDiseases();
                diseaseDropDownList.DataTextField = "Name";
                diseaseDropDownList.DataValueField = "Id";
                diseaseDropDownList.DataBind();

                ListItem desiaseItem = new ListItem("Select Desiase", "-1");
                diseaseDropDownList.Items.Insert(0, desiaseItem);

                GLatLng mainLocation = new GLatLng(23.684994, 90.356331);
                GMap1.setCenter(mainLocation, 7);
            }
        }


       
        protected void showButton_Click(object sender, EventArgs e)
        {
            string fdateTime = Convert.ToDateTime(fromDateTextBox.Text).ToString("yyyy-MM-dd");
            string tdateTime = Convert.ToDateTime(toDateTextBox.Text).ToString("yyyy-MM-dd");

            if (fdateTime != string.Empty && tdateTime != string.Empty)
            {
                int desaiseId = Convert.ToInt32(diseaseDropDownList.SelectedValue);
                List<Report> reports = districtThanaManager.GetReportDatewise(desaiseId, fdateTime, tdateTime);
                ShowinMap(reports);
                
            }
            else
            {
                int desaiseId = Convert.ToInt32(diseaseDropDownList.SelectedValue);
                List<Report> reports = districtThanaManager.GetReport(desaiseId);

                ShowinMap(reports);

            }
           
        }

        private void ShowinMap(List<Report> reports)
        {
            GLatLng mainLocation = new GLatLng(23.684994, 90.356331);
            GMap1.setCenter(mainLocation, 8);

            XPinLetter xPinLetter = new XPinLetter(PinShapes.pin_star, "H", Color.Blue, Color.White, Color.Chocolate);
            GMap1.Add(new GMarker(mainLocation, new GMarkerOptions(new GIcon(xPinLetter.ToString(), xPinLetter.Shadow()))));

            PinIcon p;
            GMarker gm;
            GInfoWindow win;
            foreach (var report in reports)
            {
                if (report.TotalPatient > 1)
                {
                    p = new PinIcon(PinIcons.home, Color.Red);
                    gm =
                        new GMarker(
                            new GLatLng(Convert.ToDouble(report.DistrictLoclot), Convert.ToDouble(report.DistrictLocLong)),
                            new GMarkerOptions(new GIcon(p.ToString(), p.Shadow())));
                    win = new GInfoWindow(gm,
                        "  District Name: " + report.DistrictName + "   Total Patient: " + report.TotalPatient,
                        GListener.Event.mouseover);

                    GMap1.Add(win);
                }
                else
                {
                    p = new PinIcon(PinIcons.home, Color.Cyan);
                    gm =
                        new GMarker(
                            new GLatLng(Convert.ToDouble(report.DistrictLoclot), Convert.ToDouble(report.DistrictLocLong)),
                            new GMarkerOptions(new GIcon(p.ToString(), p.Shadow())));
                    win = new GInfoWindow(gm,
                        "  District Name: " + report.DistrictName + "   Total Patient: " + report.TotalPatient,
                        GListener.Event.mouseover);

                    GMap1.Add(win);
                }
            }
        }
    }
}