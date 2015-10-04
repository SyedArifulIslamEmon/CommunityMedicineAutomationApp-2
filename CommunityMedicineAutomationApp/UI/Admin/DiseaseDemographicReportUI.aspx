<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DiseaseDemographicReportUI.aspx.cs" Inherits="CommunityMedicineAutomationApp.UI.Admin.DiseaseDemographicReportUi" %>

<%@ Register TagPrefix="cc1" Namespace="EGIS.Web.Controls" Assembly="EGIS.Web.Controls, Version=4.3.0.0, Culture=neutral, PublicKeyToken=05b98c869b5ffe6a" %>

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
    <link href="../../css/plugins/morris.css" rel="stylesheet" />
    <link href="../../font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../../css/datepicker.css" rel="stylesheet" />

    
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
                <a class="navbar-brand" href="index.aspx"> Head Office</a>

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
            <!-- /.navbar-collapse -->
        </nav>

        <div id="page-wrapper">

            <div class="container-fluid">

                <div class="row">
                    <div class="col-lg-12">
                        <h1 class="page-header fa fa-map-marker fa-2x"> Diseases Demographic Report
                        </h1>
                        <ol class="breadcrumb">
                            <li>
                                <i class="fa fa-home"></i><a href="index.aspx"> Home</a>
                            </li>
                            <li class="active">
                                <i class="fa fa-map-marker"></i> Demographic Report
                            </li>
                        </ol>
                    </div>
                </div>

                <div class="row">
                    <div class="col-lg-12">
                        <form id="form1" runat="server">
                             <div class="form-group">
                                    <label class="form-group col-sm-12">Date Between</label>
                                    <div class=" col-sm-3">
                                        <asp:TextBox ID="fromDateTextBox" class="form-control " runat="server"></asp:TextBox>
                                    </div>
                                    <div class="form-group col-sm-1">
                                        <label>AND</label>
                                    </div>
                                    <div class=" col-sm-3">
                                        <asp:TextBox ID="toDateTextBox" class="form-control " runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            <br/>
                            <div class="form-inline">
                                <asp:DropDownList ID="diseaseDropDownList" CssClass="form-control" runat="server"></asp:DropDownList>
                                <asp:Button ID="showButton" CssClass="btn btn-default" runat="server" Text="Show" OnClick="showButton_Click"  />
                            </div>
                            <div>
                                <gmaps:GMap ID="GMap1" runat="server" Width="800px" Height="800px" />
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
