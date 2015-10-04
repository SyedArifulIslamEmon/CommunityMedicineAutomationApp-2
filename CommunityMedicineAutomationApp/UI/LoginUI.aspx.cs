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
    public partial class Login : System.Web.UI.Page
    {
        CenterManager centerManager = new CenterManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
        }

        protected void logInButton_Click(object sender, EventArgs e)
        {
            LogIn userLogIn = new LogIn();
            userLogIn.CenterCode = centerCodeTextBox.Text;
            userLogIn.Password = passwordTextBox.Text;
            int msg = centerManager.CompareCenterCodeAndPassword(userLogIn);
            if (msg==1)
            {
                Session["User"] = userLogIn;
                Response.Redirect("~/UI/index.aspx");
            }
            else if (msg==0)
            {
                messageLabel.Text = "Center code does not found";
            }
            else if (msg==-1)
            {
                messageLabel.Text = "Password does not match";
            }
            else
            {
                messageLabel.Text = "Enter Center code & Password Correctly";
            }
        }
    }
}