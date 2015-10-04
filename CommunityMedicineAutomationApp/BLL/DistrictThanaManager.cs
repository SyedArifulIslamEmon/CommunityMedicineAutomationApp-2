using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CommunityMedicineAutomationApp.DAL.DAO;
using CommunityMedicineAutomationApp.DAL.Gateway;

namespace CommunityMedicineAutomationApp.BLL
{
    public class DistrictThanaManager
    {
        DistrictThanaGateway districtThanaGateway = new DistrictThanaGateway();
        CenterGateway centerGateway = new CenterGateway();
        DiseasesGateway diseasesGateway = new DiseasesGateway();
        public List<Report> GetReport(int diseasesId)
        {
            List<Report> reportList = new List<Report>();
            List<District> aDistricts = districtThanaGateway.GetAllDistrict();

            foreach (var district in aDistricts)
            {
                List<Thana> aThanaList = districtThanaGateway.GetAllThana(district.Id);
                Report aReport = new Report();
                int totalPatient = 0;
                double population = 1;
                foreach (var thana in aThanaList)
                {
                    List<Center> centersList = centerGateway.GetAllCenter(district.Id, thana.Id);


                    foreach (var center in centersList)
                    {

                        int patient = +centerGateway.GetTotalPatient(center.Id, diseasesId);
                        totalPatient += patient;
                    }

                }
                aReport.DistrictName = district.Name;
                population = district.Population;
                aReport.TotalPatient = totalPatient;
                aReport.PopulationPercent = ((totalPatient * 100) / population);
                aReport.DistrictLoclot = district.LoctLat;
                aReport.DistrictLocLong = district.LoctLong;
               
                reportList.Add(aReport);
            }
            return reportList;

        }

        public List<Report> GetReportDatewise(int desaiseId, string fdateTime, string tdateTime)
        {
            List<Report> reportList = new List<Report>();
            List<District> aDistricts = districtThanaGateway.GetAllDistrict();

            foreach (var district in aDistricts)
            {
                List<Thana> aThanaList = districtThanaGateway.GetAllThana(district.Id);
                Report aReport = new Report();
                int totalPatient = 0;
                double population = 1;
                foreach (var thana in aThanaList)
                {
                    List<Center> centersList = centerGateway.GetAllCenter(district.Id, thana.Id);


                    foreach (var center in centersList)
                    {

                        int patient = +centerGateway.GetDateWiseTotalPatientf(center.Id, desaiseId, fdateTime, tdateTime);
                        totalPatient += patient;
                    }

                }
                aReport.DistrictName = district.Name;
                population = district.Population;
                aReport.TotalPatient = totalPatient;
                aReport.PopulationPercent = ((totalPatient * 100) / population);
                aReport.DistrictLoclot = district.LoctLat;
                aReport.DistrictLocLong = district.LoctLong;
                reportList.Add(aReport);
            }
            return reportList;
        }

        public List<Report> GetReportforBarChart(int districtId)
        {
            List<Report> repotList = new List<Report>();
            List<Diseases> diseaseList = diseasesGateway.GetAllDiseases();
            foreach (var disease in diseaseList)
            {
                int totalPatient = 0;
                List<Center> centerList = centerGateway.GetAllCenterbyDistrictId(districtId);
                foreach (var center in centerList)
                {
                    totalPatient += centerGateway.GetTotalPatient(center.Id, disease.Id);
                }
                Report aReport = new Report();
                aReport.DiseasesName = disease.Name;
                aReport.TotalPatient = totalPatient;
                repotList.Add(aReport);
            }


            return repotList;
        }

        public List<Report> GetDiseasesWiseReport()
        {
            int totalPatient = 0;
            List<Report> repotList = new List<Report>();
            List<Diseases> diseaseList = diseasesGateway.GetAllDiseases();
            foreach (var disease in diseaseList)
            {
                totalPatient += centerGateway.GetDiseasesWiseTotalPatient(disease.Id);
               
                Report aReport = new Report();
                aReport.DiseasesName = disease.Name;
                aReport.TotalPatient = totalPatient;
                repotList.Add(aReport);
                totalPatient = 0;
            }


            return repotList;
        }

        public List<Report> GetReportDatewiseInaDistrict(int districtId, string fdateTime, string tdateTime)
        {
            List<Report> repotList = new List<Report>();
            List<Diseases> diseaseList = diseasesGateway.GetAllDiseases();
            foreach (var disease in diseaseList)
            {
                int totalPatient = 0;
                List<Center> centerList = centerGateway.GetAllCenterbyDistrictId(districtId);
                foreach (var center in centerList)
                {
                    totalPatient += centerGateway.GetTotalPatientByDate(center.Id, disease.Id,fdateTime,tdateTime);
                }
                Report aReport = new Report();
                aReport.DiseasesName = disease.Name;
                aReport.TotalPatient = totalPatient;
                repotList.Add(aReport);
            }

            return repotList;
        }
    }
}