using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;
using CommunityMedicineAutomationApp.DAL.DAO;
using CommunityMedicineAutomationApp.DAL.Gateway;

namespace CommunityMedicineAutomationApp.BLL
{
    public class CenterManager
    {
        CenterGateway centerGateway = new CenterGateway();
        public string RandomCode()
        {
            int length = 5;
            const string valid = "ABCDEFGH1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }

        public string RandomPassword()
        {
            int passwordLength = 8;
            string _allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789!@#$%&?";
            Random randNum = new Random();
            char[] chars = new char[passwordLength];
            int allowedCharCount = _allowedChars.Length;

            for (int i = 0; i < passwordLength; i++)
            {
                chars[i] = _allowedChars[(int)((_allowedChars.Length) * randNum.NextDouble())];
            }

            return new string(chars);
        }

        public string Encryptdata(string password)
        {
            string strmsg = string.Empty;
            byte[] encode = new byte[password.Length];
            encode = Encoding.UTF8.GetBytes(password);
            strmsg = Convert.ToBase64String(encode);
            return strmsg;
        }

        public int CreateCenter(Center aCenter)
        {
            if (centerGateway.IsThisCenterNameExists(aCenter.Name,aCenter.ThanaId))
            {
                return 1;
            }
            else if (centerGateway.IsThisCenterCodeExists(aCenter.CenterCode))
            {
                return 2;
            }
            else
            {
                if (centerGateway.CreateCenter(aCenter))
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            
        }

        public int CompareCenterCodeAndPassword(LogIn userLogIn)
        {
            if (centerGateway.Match(userLogIn.CenterCode))
            {
                string pass = userLogIn.Password;
                string password = Decryptdata(centerGateway.GetPassword(userLogIn.CenterCode));
                if (pass==password)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return 0;
            }
            
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

        public Center GetCenterIdbyCenterCode(string centerCode)
        {
            return centerGateway.GetCenterIdbyCenterCode(centerCode);
        }

        public Voter GetVoterInformation(string givenId)
        {
            List<Voter> voterList = centerGateway.GetVoterInformation();
            Voter aVoter = new Voter();
            foreach (var voter in voterList)
            {
                if (voter.id == givenId)
                {
                    aVoter.name = voter.name;
                    aVoter.address = voter.address;
                    aVoter.date_of_birth = voter.date_of_birth;
                }
            }
            return aVoter;

        }

        public int CalculateAge(DateTime dateOfBirth)
        {
            DateTime todayDateTime = DateTime.Today;
            DateTime birthDayDateTime = dateOfBirth;

            int age = todayDateTime.Year -birthDayDateTime.Year;
            
            return age;
        }

        public List<Treatment> GetNumberofServiceTaken(string voterId)
        {
             return  centerGateway.GetNumberofServiceTaken(voterId);
           
        }


        public string SaveTreatmentInfo(List<Treatment> treatments)
        {
            if (centerGateway.SaveTreatmentInfo(treatments))
            {
                return "Save successfull";
            }
            else
            {
                return "Save failed";
            }
            
        }

        public List<Treatment> GetAllTreatmentByDate(DateTime date, string voterId)
        {
            return centerGateway.GetAllTreatmentByDate(date, voterId);
        }


        public List<Treatment> GetAllTreatmentList(DateTime date, string voterId)
        {
            return centerGateway.GetAllTreatmentList(date, voterId);
        }

        public int CountPatient(int centerId)
        {
            return centerGateway.CountPatient(centerId);
        }
    }
}