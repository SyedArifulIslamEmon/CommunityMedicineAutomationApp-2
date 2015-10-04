using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CommunityMedicineAutomationApp.BLL;
using CommunityMedicineAutomationApp.DAL.DAO;

namespace CommunityMedicineAutomationApp.UI.Admin
{
    public partial class MessageUi : System.Web.UI.Page
    {
        Center aCenter = new Center();
        DropDownManager dropDownManager = new DropDownManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            aCenter = (Center) Session["CENTER"];
            string name = aCenter.Name;
            int districtId = aCenter.DistrictId;
            int thanaId = aCenter.ThanaId;
            string centerCode = aCenter.CenterCode;
            string password = aCenter.Password;

            districtNameLabel.Text = dropDownManager.GetDistrict(districtId);
            thanaNameLabel.Text = dropDownManager.GetThana(thanaId);
            centerNameLabel.Text = name;
            centerCodeLabel.Text = centerCode;
            passwordLabel.Text = Decryptdata(password);
        }

        private string Decryptdata(string encryptpwd)
        {
            string decryptpwd = string.Empty;
            UTF8Encoding encodepwd = new UTF8Encoding();
            Decoder Decode = encodepwd.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encryptpwd);
            int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            decryptpwd = new String(decoded_char);
            return decryptpwd;
        }

    }
}