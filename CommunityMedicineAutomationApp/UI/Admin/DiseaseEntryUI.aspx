<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DiseaseEntryUI.aspx.cs" Inherits="CommunityMedicineAutomationApp.UI.Admin.DiseaseEntryUi" %>

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

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->

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
                        <h1 class="page-header fa fa-hospital-o fa-2x"> Diseases Entry
                        </h1>
                        <ol class="breadcrumb">
                            <li>
                                <i class="fa fa-home"></i><a href="index.aspx"> Home</a>
                            </li>
                            <li class="active">
                                <i class="fa fa-hospital-o"></i> Diseases Entry
                            </li>
                        </ol>
                    </div>
                </div>


                <div class="row">
                    <div class="col-lg-12">

                        <form role="form" runat="server" id="diseasesForm">

                            <div class="col-sm-6">
                                <div class="form-group col-sm-8">
                                    <label>Name</label>
                                    <asp:TextBox ID="diseasesNameTextBox" runat="server" class="form-control "></asp:TextBox>

                                </div>
                                <div class="form-group col-sm-8">
                                    <label>Discription</label>
                                    <asp:TextBox ID="discriptionTextBox" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                </div>
                                <div class="form-group col-sm-8">
                                    <label>Treatment Procedure</label>
                                    <asp:TextBox ID="treatmentProcedureTextBox" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                </div>
                                <div class="form-group col-sm-8">
                                    <asp:Button ID="saveDiseasesButton" runat="server" class="btn btn-default" Text="Save" OnClick="saveDiseasesButton_Click" />
                                </div>
                                <br />
                                <asp:Label ID="messageLabel" runat="server" Text=""></asp:Label>
                                <br />
                            </div>

                            <div class="row">
                                <div class="col-md-12">

                                    <asp:GridView ID="viewDiseasesGridView" runat="server" CssClass="gvdatatable" AutoGenerateColumns="False" OnPreRender="viewDiseasesGridView_PreRender">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Serial No.">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Diseases Name" DataField="Name" />
                                            <asp:BoundField HeaderText="Discription" DataField="Discription" />
                                            <asp:BoundField HeaderText="Treatment Procedure" DataField="TreatmentProcedure" />
                                        </Columns>
                                    </asp:GridView>
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
    <script type="text/javascript">
        $(document).ready(function () {
            $("#diseasesForm").validate({
                rules: {
                    diseasesNameTextBox: "required",
                    treatmentProcedureTextBox: "required",
                    discriptionTextBox: "required",
                },
                messages: {
                    diseasesNameTextBox: "Required field Medicine Name",
                    treatmentProcedureTextBox: "Required field Treatment Procedure",
                    discriptionTextBox: "Required field Discription",
                },
            });
            $('.gvdatatable').dataTable({});
        });
    </script>
</body>

</html>

