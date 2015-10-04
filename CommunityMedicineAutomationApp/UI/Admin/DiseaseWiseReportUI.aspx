<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DiseaseWiseReportUI.aspx.cs" Inherits="CommunityMedicineAutomationApp.UI.Admin.DiseaseWiseReportUi" %>

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

    <style>
        .fieldset {
            border: 1px solid #999;
            margin-bottom: 30px;
            width: 80%;
        }

        legend {
            padding-left: 10px;
        }
    </style>
</head>

<body>

    <div id="wrapper">


        <nav class="navbar navbar-inverse navbar-fixed-top" role="navigation">

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
                        <h1 class="page-header fa fa-clipboard fa-2x"> Diseases Wise Report</h1>
                        <div class="breadcrumb pull-right">
                            <span class="print fa fa-print pull-right"> Print Document</span>
                        </div>
                        <ol class="breadcrumb">
                            <li>
                                <i class="fa fa-home"></i><a href="index.aspx"> Home</a>
                            </li>
                            <li class="active">
                                <i class="fa fa-clipboard"></i> Report
                            </li>
                        </ol>
                    </div>
                </div>
                <div class="row">

                    <form runat="server">
                        <fieldset class="fieldset">
                            <legend>Diseases Wise Report</legend>
                            <div class="col-lg-8">
                                <div class="form-group">
                                    <div class="form-group col-sm-6">
                                        <label>Select Disease</label>
                                        <asp:DropDownList ID="desiaseDropDownList" CssClass="form-control col-sm-4" runat="server"></asp:DropDownList>
                                    </div>
                                    <div class="form-group col-sm-5" style="margin-top: 25px;">
                                        <asp:Button ID="showButton" runat="server" CssClass="btn btn-default" Text="Show Report" OnClick="showButton_Click" />
                                    </div>
                                </div>
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
                            </div>
                        </fieldset>
                        <div class="form-group col-sm-10">
                            <asp:GridView ID="diseasesReportGridView" runat="server" CssClass="gvdatatable" AutoGenerateColumns="False" OnPreRender="diseasesReportGridView_PreRender">
                                <Columns>
                                    <asp:BoundField HeaderText="District Name" DataField="DistrictName" />
                                    <asp:BoundField HeaderText="Total Patient" DataField="TotalPatient" />
                                    <asp:BoundField HeaderText="% Over Population" DataField="PopulationPercent" />
                                </Columns>
                            </asp:GridView>
                        </div>

                    </form>

                </div>

            </div>

        </div>
    </div>

    <script src="../../js/jquery.js"></script>
    <script src="../../js/bootstrap.min.js"></script>
    <script src="../../js/jquery.validate.min.js"></script>
    <script src="../../js/jquery.dataTables.min.js"></script>
    <script src="../../js/plugins/bootstrap-datepicker.js"></script>
    <script src="../../js/jquery.printpage.js"></script>
    
    <script type="text/javascript">
        $(document).ready(function () {

            $('.gvdatatable').dataTable({});
            $('#fromDateTextBox').datepicker({
                format: "yyyy/mm/dd"
            });
            $('#toDateTextBox').datepicker({
                format: "yyyy/mm/dd"
            });
            $('span.print').printPage();
        });
    </script>


</body>

</html>
