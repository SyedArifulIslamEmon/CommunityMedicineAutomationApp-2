<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendMedicineUI.aspx.cs" Inherits="CommunityMedicineAutomationApp.UI.Admin.SendMedicineUi" %>

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

                <!-- Page Heading -->
                <div class="row">
                    <div class="col-lg-12">
                        <h1 class="page-header fa fa-send-o fa-2x"> Send Medicine
                        </h1>
                        <ol class="breadcrumb">
                            <li>
                                <i class="fa fa-home"></i><a href="index.aspx"> Home</a>
                            </li>
                            <li class="active">
                                <i class="fa fa-send"></i> Send Medicine
                            </li>
                        </ol>
                    </div>
                </div>
                <!-- /.row -->

                <div class="row">
                    <div class="col-lg-12">

                        <form role="form" runat="server">

                            <div class="col-sm-5">
                                <div class="form-group col-sm-8">
                                    <label>District</label>
                                    <asp:DropDownList ID="districtDropDownList" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="districtDropDownList_SelectedIndexChanged"></asp:DropDownList>
                                </div>

                                <div class="form-group col-sm-8">
                                    <label>Thana</label>
                                    <asp:DropDownList ID="thanaDropDownList" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="thanaDropDownList_SelectedIndexChanged"></asp:DropDownList>

                                </div>
                                <div class="form-group col-sm-8">
                                    <label>Center</label>
                                    <asp:DropDownList ID="centerDropDownList" runat="server" class="form-control"></asp:DropDownList>

                                </div>
                            </div>

                            <fieldset class="col-sm-12">
                                <legend>Add Medicine</legend>

                                <div class="form-group col-sm-5">
                                    <label class="control-label col-sm-5">Select Medicine</label>
                                    <div class="col-sm-6">
                                        <asp:DropDownList ID="medicineDropDownList" runat="server" class="form-control"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group col-sm-3">
                                    <label class="control-label col-sm-4">Quantity</label>
                                    <div class="col-sm-6">
                                        <asp:TextBox class="form-control" ID="quantityTextBox" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <asp:Button ID="addButton" runat="server" Text="Add" class="btn btn-default" OnClick="addButton_Click" />
                            </fieldset>
                            <div class="col-sm-6 ">
                                <asp:GridView ID="showMedicineGridView" runat="server" AutoGenerateColumns="False" class="gvdatatable">
                                    <Columns>
                                        <asp:BoundField HeaderText=" Medicine Name" DataField="MedicineName" />
                                        <asp:BoundField HeaderText="Quantity" DataField="Quantity" />
                                    </Columns>

                                </asp:GridView>
                            </div>
                            <div class="col-sm-12">
                                <br/>
                                
                            </div>
                            <div class="form-group col-sm-12">
                                <asp:Button ID="sendMedicineButton" runat="server" Text="Send" class="btn btn-default" OnClick="sendMedicineButton_Click" />
                            </div>
                            <div class="col-sm-12">
                                <asp:Label ID="messageLabel" CssClass="has-error" runat="server" Text=""></asp:Label>
                            </div>                          
                        </form>

                    </div>

                </div>
                <!-- /.row -->

            </div>
            <!-- /.container-fluid -->

        </div>
        <!-- /#page-wrapper -->

    </div>
    <!-- /#wrapper -->

    <script src="../../js/jquery.js"></script>
    <script src="../../js/bootstrap.min.js"></script>
    <script src="../../js/jquery.dataTables.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.gvdatatable').dataTable({});
        });
    </script>
</body>

</html>

