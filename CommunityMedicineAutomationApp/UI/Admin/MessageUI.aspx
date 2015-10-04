<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MessageUI.aspx.cs" Inherits="CommunityMedicineAutomationApp.UI.Admin.MessageUi" %>

<!DOCTYPE html>
<html lang="en">

<head>

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">

    <title>Head Office</title>

    <link href="../../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../css/sb-admin.css" rel="stylesheet" />
    <link href="../../font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <style>
        .label{
            width: 160px;
            display: inline-block;
            text-align: right;
            margin-right: 20px;
            color: black;
        }
        .col-centered {
            width: 600px;
            margin: 0 auto;
            font-size: 16pt;
           }
        .auto-style1 {
            width: 20px;
            height: 20px;
        }
        
    </style>

</head>

<body>

    <div id="wrapper">

        <nav class="navbar navbar-inverse navbar-fixed-top" role="navigation">

            <ul class="nav navbar-nav side-nav">
                    <li class="active">
                        <a href="index.aspx"><i class="fa fa-fw fa-home"></i> Home</a>
                    </li>
                    <li>
                        <a href="MedicineEntryUI.aspx"><i class="fa fa-fw fa-medkit"></i> Medicine Entry</a>
                    </li>
                    <li>
                        <a href="DiseaseEntryUI.aspx"><i class="fa fa-fw fa-hospital-o"></i> Disease Entry</a>
                    </li>
                    <li>
                        <a href="CreateNewCenterUI.aspx"><i class="fa fa-fw fa-plus-square-o"></i> Create New Center</a>
                    </li>
                    <li>
                        <a href="SendMedicineUI.aspx"><i class="fa fa-fw fa-send-o "></i> Send Medicine</a>
                    </li>
                    <li>
                        <a href="DiseaseWiseReportUI.aspx"><i class="fa fa-fw fa-clipboard "></i> Disease Wise Report</a>
                    </li>
                    <li>
                        <a href="DiseaseDemographicReportUI.aspx"><i class="fa fa-fw fa-map-marker "></i> Disease Demographic </a>
                    </li>
                    <li>
                        <a href="AllDiseasesBarChartUI.aspx"><i class="fa fa-fw fa-bar-chart-o "></i> All Diseases Bar Chart</a>
                    </li>
                </ul>

        </nav>

        <div id="page-wrapper">

            <div class="container-fluid">

                <div class="row">
                    <div class="col-lg-12">
                        <h1 class="page-header">Congratulation
                        </h1>
                        
                        <div class="form-control pull-left ">
                            <p>New center successfully created</p>
                        </div>
                        <div class="breadcrumb pull-right">
                            <span class="print fa fa-print pull-right"> Print Document</span>
                        </div>
                        
                    </div>
                </div>

                <div class="row">
                    <div class="col-lg-4 col-centered">
                        <div class="form-group">
                            <label class="label ">District Name :</label>
                            <asp:Label ID="districtNameLabel" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="form-group">
                            <label class="label ">Thana Name :</label>
                            <asp:Label ID="thanaNameLabel" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="form-group">
                            <label class="label ">Center Name :</label>
                            <asp:Label ID="centerNameLabel" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="form-group">
                            <label class="label ">Center Code :</label>
                            <asp:Label ID="centerCodeLabel" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="form-group">
                            <label class="label ">Password :</label>
                            <asp:Label ID="passwordLabel" runat="server" Text=""></asp:Label>
                        </div>

                    </div>

                </div>

            </div>

        </div>

    </div>

    <script src="../../js/jquery.js"></script>
    <script src="../../js/bootstrap.min.js"></script>
    <script src="../../js/jquery.validate.min.js"></script>
    <script src="../../js/jquery.printpage.js"></script>
    <script>
        $(document).ready(function () {
            $('span.print').printPage();
        });
    </script>
</body>

</html>


