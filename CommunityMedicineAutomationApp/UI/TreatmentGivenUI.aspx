<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TreatmentGivenUI.aspx.cs" Inherits="CommunityMedicineAutomationApp.UI.TreatmentGivenUi" %>


<!DOCTYPE html>
<html lang="en">

<head>

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">

    <title>Center Office</title>


    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/sb-admin.css" rel="stylesheet" />
    <link href="../css/plugins/morris.css" rel="stylesheet" />
    <link href="../font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../css/datepicker.css" rel="stylesheet" />
    <link href="../css/jquery.dataTables.css" rel="stylesheet" />

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->

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
                <a class="navbar-brand" href="index.aspx">Center</a>

            </div>
            <!-- Top Menu Items -->
            <ul class="nav navbar-right top-nav">
                <li class="dropdown">
                    <a href="#" class="dropdown-toggle" data-toggle="dropdown"><i class="fa fa-user"></i>
                        <asp:Label ID="centerName" runat="server" Text="Label"></asp:Label><b class="caret"></b></a>
                    <ul class="dropdown-menu">
                        
                        <li class="divider"></li>
                        <li>
                            <a href="LoginUI.aspx"><i class="fa fa-fw fa-power-off"></i>Log Out</a>
                        </li>
                    </ul>
                </li>
            </ul>

            <div class="collapse navbar-collapse navbar-ex1-collapse">
                <ul class="nav navbar-nav side-nav">
                    <li class="active">
                        <a href="index.aspx"><i class="fa fa-fw fa-home"></i> Home</a>
                    </li>
                    <li>
                        <a href="DoctorEntruUi.aspx"><i class="fa fa-fw fa-user-md"></i> Doctor Entry</a>
                    </li>
                    <li>
                        <a href="MedicineStockReportUI.aspx"><i class="fa fa-fw fa-medkit"></i> Medicine Stock Report</a>
                    </li>
                    <li>
                        <a href="TreatmentGivenUI.aspx"><i class="fa fa-fw fa-stethoscope"></i> Treatment Given</a>
                    </li>
                    <li>
                        <a href="ShowAllHistoryOfaPatientUI.aspx"><i class="fa fa-fw fa-history"></i> Show All History</a>
                    </li>

                </ul>
            </div>
            <!-- /.navbar-collapse -->
        </nav>

        <div id="page-wrapper">

            <div class="container-fluid">
                <div class="row">
                    <div class="col-lg-12">
                        <h1 class="page-header fa fa-stethoscope fa-2x">Treatment Given
                        </h1>
                        <ol class="breadcrumb">
                            <li>
                                <i class="fa fa-home"></i><a href="index.aspx"> Home</a>
                            </li>
                            <li class="active">
                                <i class="fa fa-stethoscope"></i>Treatment Given
                            </li>
                        </ol>
                    </div>
                </div>

                <div class="row">
                    <form role="form" id="treatmentForm" runat="server" method="POST">
                        <div class="col-lg-12 ">

                            <div class="form-group col-sm-3">
                                <label class="col-sm-5">Voter Id:</label>
                                <asp:TextBox ID="patientVoterIdTextBox" runat="server" class="form-control col-sm-6"></asp:TextBox>
                            </div>
                            <div class="form-group col-sm-3">
                                <label class="col-sm-5">Name:</label>
                                <asp:TextBox ID="patientNameTextBox" runat="server"  class="form-control col-sm-6"></asp:TextBox>
                            </div>
                            <div class="form-group col-sm-3">
                                <label class="col-sm-5">Address:</label>
                                <asp:TextBox ID="patientAddressTextBox" runat="server" class="form-control col-sm-6"></asp:TextBox>
                            </div>
                            <div class="form-group col-sm-3">
                                <label class="col-sm-5">Age:</label>
                                <asp:TextBox ID="patientAgeTextBox" runat="server" class="form-control col-sm-6"></asp:TextBox>
                            </div>
                             <div class="form-group col-sm-3">
                                <asp:Label ID="alartLabel" runat="server" Text=""></asp:Label>
                            </div>

                        </div>
                        <div class="col-sm-12">
                            <div class="form-group col-sm-3">
                                <asp:Button ID="showDetailsButton" class="btn btn-default" runat="server" Text="Show Details" OnClick="showDetailsButton_Click1" />
                            </div>
                        </div>
                        <div class="col-lg-12">
                            <div class="form-group col-sm-3">
                                <label class="col-sm-7">Service Given :</label>
                                <asp:TextBox ID="serviceTimeTextBox" runat="server" class="form-control col-sm-3"></asp:TextBox><span>Times</span>
                            </div>
                        </div>
                        <div class="col-lg-12">
                             <div class="form-group col-sm-3">
                                <asp:Button ID="showAllHistoryButton" class="btn btn-default" runat="server" Text="Show All History" OnClick="showAllHistoryButton_Click" />
                          <%--  <label class="col-sm-7"><a href="ShowAllHistoryOfaPatientUI.aspx">Show All History</a></label>--%>
                             </div>
                        </div>
                        <div class="col-lg-12">
                            <div class="form-group col-sm-3">
                                <label class="col-sm-7">Observation :</label>
                                <asp:TextBox ID="observationTextBox" runat="server" class="form-control col-sm-6" TextMode="MultiLine"></asp:TextBox>
                            </div>
                            <div class="form-group col-sm-3">
                                <label class="col-sm-7">Date :</label>
                                <asp:TextBox ID="dateTextBox" runat="server" class="form-control col-sm-6"></asp:TextBox>
                            </div>
                            <div class="form-group col-sm-3 input-append date">
                                <label class="col-sm-7">Doctor :</label>
                                <asp:DropDownList ID="doctorDropDownList" class="form-control col-sm-6" runat="server"></asp:DropDownList>
                            </div>
                            <div class="form-group col-sm-3">
                                <label class="col-sm-7">Diseases :</label>
                                <asp:DropDownList ID="diseaseDropDownList" class="form-control col-sm-6" runat="server"></asp:DropDownList>
                            </div>

                        </div>
                        <div class="col-sm-12">
                            <div class="form-group col-sm-3">
                                <label class="col-sm-7">Medicine :</label>
                                <asp:DropDownList ID="medicineDropDownList" class="form-control col-sm-6" runat="server" AutoPostBack="True" OnSelectedIndexChanged="medicineDropDownList_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <div class="form-group col-sm-2">
                                <label class="col-sm-7">Stock :</label>
                                <asp:TextBox ID="stockTextBox" ReadOnly="True" runat="server" class="form-control col-sm-6 "></asp:TextBox>
                            </div>
                            <div class="form-group col-sm-3">
                                <label class="col-sm-7">Dose :</label>
                                <asp:DropDownList ID="doesDropDownList" class="form-control col-sm-6" runat="server">
                                    <asp:ListItem Value="1">Only Day</asp:ListItem>
                                    <asp:ListItem Value="6">Only Noon</asp:ListItem>
                                    <asp:ListItem Value="7">Only Night</asp:ListItem>
                                    <asp:ListItem Value="2">Day and Noon</asp:ListItem>
                                    <asp:ListItem Value="3">Day and Night</asp:ListItem>
                                    <asp:ListItem Value="4">Noon and Night</asp:ListItem>
                                    <asp:ListItem Value="5">Day,Noon and Night</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group col-sm-2" style="padding-top: 18px;">
                                <label class="checkbox-inline">
                                    <asp:RadioButton ID="afterMealRadioButton" runat="server" GroupName="WhenTakeMedicine" />
                                    After Meal</label><br />
                                <label class="checkbox-inline">
                                    <asp:RadioButton ID="beforeMealRadioButton" runat="server" GroupName="WhenTakeMedicine" />
                                    Before Meal</label>

                            </div>

                        </div>
                        <div class="col-sm-12">
                            <div class="form-group col-sm-3">
                                <label class="col-sm-8">Quantity Given :</label>
                                <asp:TextBox ID="quantityTextBox"  class="form-control col-sm-6" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group col-sm-3">
                                <label class="col-sm-7">Note :</label>
                                <asp:TextBox ID="noteTextBox" class="form-control col-sm-6" runat="server"></asp:TextBox>
                            </div>
                            <div class="form-group col-sm-3" style="padding-top: 25px;">
                                <asp:Button ID="addButton" CssClass="btn btn-default" runat="server" Text="ADD" OnClick="addButton_Click" />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-11">

                                <asp:GridView ID="addTreatmentGridView" runat="server" CssClass="gvdatatable" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:BoundField HeaderText="Diseases" DataField="DiseaseName" />
                                        <asp:BoundField HeaderText="Medicine" DataField="MedicineName" />
                                        <asp:BoundField HeaderText="Dose" DataField="Does" />
                                        <asp:BoundField HeaderText="Befor / After Meal" DataField="MealTime" />
                                        <asp:BoundField HeaderText="Quantity Given" DataField="Quantity" />
                                        <asp:BoundField HeaderText="Note" DataField="Note" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>

                        <div class="col-sm-12">
                            <div class="form-group col-sm-3" style="padding-top: 25px;">
                                <asp:Button ID="saveTreatmentButton" CssClass="btn btn-default" runat="server" Text="Save Treatment" OnClick="saveTreatmentButton_Click" />
                            </div>
                        </div>
                        <asp:Label ID="messageLabel" runat="server" Text=""></asp:Label>
                    </form>

                </div>
            </div>

        </div>

    </div>
    <script src="../js/jquery.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <script src="../js/jquery.validate.min.js"></script>
    <script src="../js/jquery.dataTables.min.js"></script>
    <script src="../js/plugins/bootstrap-datepicker.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#treatmentForm").validate({
                rules: {
                    patientVoterIdTextBox: {
                        required: true,
                        number: true,
                    }
                },

                messages: {
                    patientVoterIdTextBox: {
                        required: "Please provide a Voter ID",
                        number: "Please enter number only",
                    }
                },
            });
            $('.gvdatatable').dataTable({});
            $('#dateTextBox').datepicker({
                format: "yyyy/mm/dd"
            });
        });
    </script>


</body>

</html>
