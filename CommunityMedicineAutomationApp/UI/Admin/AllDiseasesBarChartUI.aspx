<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllDiseasesBarChartUI.aspx.cs" Inherits="CommunityMedicineAutomationApp.UI.Admin.AllDiseasesBarChartUi" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI.DataVisualization.Charting" Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>



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
    <link href="../../css/datepicker.css" rel="stylesheet" />
    <link href="../../css/jquery.dataTables.css" rel="stylesheet" />
    

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
                <a class="navbar-brand" href="index.aspx">Head Office</a>
               
            </div>
            
            <div class="collapse navbar-collapse navbar-ex1-collapse">
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
            </div>
 
        </nav>

        <div id="page-wrapper">

            <div class="container-fluid">

                <div class="row">
                    <div class="col-lg-12">
                        <h1 class="page-header fa fa-bar-chart fa-2x"> Diseases Bar Chart
                        </h1>
                        <ol class="breadcrumb">
                            <li>
                                <i class="fa fa-home"></i><a href="index.aspx"> Home</a>
                            </li>
                            <li class="active">
                                <i class="fa fa-bar-chart"></i> Bar Chart
                            </li>
                        </ol>
                    </div>
                </div>
                
                <div class="row">
                    <div class=" col-lg-12">
                        <form runat="server">
                            <div class="well col-sm-7 panel-title">
                                <div class="form-group col-sm-10">
                                    <div class=" col-sm-5">
                                        <label>From :</label>
                                        <asp:TextBox ID="fromDateTextBox" class="form-control " runat="server"></asp:TextBox>
                                    </div>
                                    <div class=" col-sm-5">
                                        <label>To :</label>
                                        <asp:TextBox ID="toDateTextBox" class="form-control " runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            <div class="col-sm-10">
                                <div class="form-group col-sm-7">
                                    <label>Select Disease</label>
                                    <asp:DropDownList ID="districtDropDownList" CssClass="form-control col-sm-6" runat="server"></asp:DropDownList>
                                </div>
                                <div class="form-group" style="margin-top: 25px;">
                                    <asp:Button ID="showButton" runat="server" CssClass="btn btn-default" Text="Show Report" OnClick="showButton_Click" />
                                </div>
                           </div>
                            </div>
                            <div class="col-lg-8">
                                <div class="panel panel-primary">
                                    <div class="panel-heading">
                                        <h3 class="panel-title"><i class="fa fa-long-arrow-right"></i> All diseases bar chart :</h3>
                                    </div>
                                    <div class="panel-body">
                                        <asp:Chart ID="diseaseBarChart" runat="server" AlternateText="Column chart of daily walking time" Height="332" Width="600" Palette="Fire" CssClass="col-lg-12">
                                            <Series>
                                                <asp:Series Name="Series1" Color="Green" XValueMember="DiseasesName" YValueMembers="TotalPatient" YValuesPerPoint="6" IsValueShownAsLabel="true" LabelFormat="{0:N0}" ChartArea="diseasesChartArea"></asp:Series>
                                            </Series>
                                            <ChartAreas>
                                                <asp:ChartArea Name="diseasesChartArea" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="White" ShadowColor="Transparent" BackGradientStyle="TopBottom" >
                                                    <%--<Area3DStyle Enable3D="True" Rotation="10" Perspective="20" LightStyle="Simplistic" Inclination="15" IsRightAngleAxes="True" WallWidth="10" IsClustered="True" />--%>
                                                    <AxisY Interval="10">
                                                    <MajorGrid Enabled="true" LineDashStyle="Dash" LineColor="Blue" />
                                                    </AxisY>
                                                    <AxisX IsLabelAutoFit="False" IsInterlaced="True"  TitleForeColor="black" Interval="1">
                                                    <LabelStyle   Angle="-60" ForeColor="Black" IsEndLabelVisible="false" />
                                                    <MajorGrid Enabled="False" />
                                                    </AxisX>
                                                </asp:ChartArea>
                                            </ChartAreas>
                                        </asp:Chart>
                                    </div>
                                </div>
                            </div>     
                        </form>
                    </div>
                </div>
               
            </div>
         
        </div>
       
    </div>
   
    <script src="../../js/jquery.js"></script>
    <script src="../../js/bootstrap.min.js"></script>
    <script src="../../js/jquery.validate.min.js"></script>
    <script src="../../js/jquery.dataTables.min.js"></script>
    <script src="../../js/plugins/bootstrap-datepicker.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {

            $('.gvdatatable').dataTable({});
            $('#fromDateTextBox').datepicker({
                format: "yyyy/mm/dd"
            });
            $('#toDateTextBox').datepicker({
                format: "yyyy/mm/dd"
            });
        });
    </script>


</body>

</html>
