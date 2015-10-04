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
    public partial class CreateNewCenterUi : System.Web.UI.Page
    {
        DropDownManager dropDownManager = new DropDownManager();
        CenterManager centerManager =new CenterManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                districtDropDownList.DataSource = dropDownManager.GetAllDistrict();
                districtDropDownList.DataTextField = "Name";
                districtDropDownList.DataValueField = "Id";
                districtDropDownList.DataBind();
                ListItem liDistrict = new ListItem("Select District","-1");
                districtDropDownList.Items.Insert(0,liDistrict);
                ListItem liThana = new ListItem("Select Thana", "-1");
                thanaDropDownList.Items.Insert(0, liThana);
            }
        }

        protected void districtDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (districtDropDownList.SelectedValue!="-1")
            {
                int id = Convert.ToInt32(districtDropDownList.SelectedValue);
                thanaDropDownList.DataSource = dropDownManager.GetAllThana(id);
                thanaDropDownList.DataTextField = "Name";
                thanaDropDownList.DataValueField = "Id";
                thanaDropDownList.DataBind();
                ListItem liThana = new ListItem("Select Thana", "-1");
                thanaDropDownList.Items.Insert(0, liThana);
            }
        }

        protected void creatCenterButton_Click(object sender, EventArgs e)
        {
            Center aCenter = new Center();

            aCenter.Name = centerNameTextBox.Text;
            aCenter.DistrictId = Convert.ToInt32(districtDropDownList.SelectedValue);
            aCenter.ThanaId = Convert.ToInt32(thanaDropDownList.SelectedValue);
            aCenter.CenterCode = aCenter.Name+centerManager.RandomCode();
            aCenter.Password = centerManager.Encryptdata(centerManager.RandomPassword());

            int num = centerManager.CreateCenter(aCenter);
            if (num==0)
            {

                Session["CENTER"] = aCenter;
                Response.Redirect("~/UI/Admin/MessageUI.aspx");
            }
            else if (num==1)
            {
                messageLabel.Text = "Sorry this Tenter Name already exists in" + thanaDropDownList.SelectedValue;
            }
            else if (num==2)
            {
                messageLabel.Text = "Sorry this center code already exists. Please try again";
                Server.TransferRequest(Request.Url.AbsolutePath, false);
                messageLabel.ForeColor = Color.Red;
            }
            else
            {
                messageLabel.Text = "Sorry save failed";
                messageLabel.ForeColor = Color.Red;
            }
        }

    }
}