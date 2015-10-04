<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateNewCenterUI.aspx.cs" Inherits="CommunityMedicineAutomationApp.UI.Admin.CreateNewCenterUi" %>

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
    
    
</head>

<body>

    <div id="wrapper">

        <!-- Navigation -->
        <nav class="navbar navbar-inverse navbar-fixed-top" role="navigation">
            <!-- Brand and toggle get grouped for better mobile display -->
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-ex1-collapse">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="index.aspx">Admin</a>
            </div>
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
                        <h1 class="page-header fa fa-plus-square-o fa-2x"> Create New Center
                        </h1>
                        <ol class="breadcrumb">
                            <li>
                                <i class="fa fa-home"></i><a href="index.aspx"> Home</a>
                            </li>
                            <li class="active">
                                <i class="fa fa-plus-square-o"></i>Create Center
                            </li>
                        </ol>
                    </div>
                </div>
               
                <div class="row">
                    <div class="col-lg-4">

                        <form role="form" id="creatCenterForm" runat="server" method="POST">

                            <div class="form-group ">
                                <label>Name</label>
                                <asp:TextBox ID="centerNameTextBox" runat="server" class="form-control"></asp:TextBox>

                            </div>
                            <div class="form-group">
                                <label>District</label>
                                <asp:DropDownList ID="districtDropDownList" runat="server" class="form-control"  AutoPostBack="True" OnSelectedIndexChanged="districtDropDownList_SelectedIndexChanged"></asp:DropDownList>

                            </div>
                            <div class="form-group">
                                <label>Thana</label>
                                <asp:DropDownList ID="thanaDropDownList" runat="server" class="form-control"></asp:DropDownList>

                            </div>
                            <div class="form-group">
                                <asp:Button ID="creatCenterButton" runat="server" class="btn btn-default" Text="Create Center" OnClick="creatCenterButton_Click" />
                            </div>
                            <asp:Label ID="messageLabel" runat="server" Text=""></asp:Label>
                        </form>

                    </div>

                </div>
            
            </div>
           
        </div>
       
    </div>

    <script src="../../js/jquery.js"></script>
    <script src="../../js/bootstrap.min.js"></script>
    <script src="../../js/jquery.validate.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#creatCenterForm").validate({
                rules: {
                    centerNameTextBox: "required",
                   
                },
                messages: {
                    centerNameTextBox: "Required field Medicine Name",
                    
                },
            }),
            $('#creatCenterForm').submit(function (e) {
                var mydropdown = $('#districtDropDownList option:selected');
                if (mydropdown.length == 0 || $(mydropdown).val() == "-1") {
                    alert("Please select District");
                    e.preventDefault();
                    return false;
                }
                mydropdown = $('#thanaDropDownList option:selected');
                if (mydropdown.length == 0 || $(mydropdown).val() == "-1") {
                    alert("Please select Thana");
                    e.preventDefault();
                    return false;
                }
            });
        });
    </script>
     
</body>

</html>


