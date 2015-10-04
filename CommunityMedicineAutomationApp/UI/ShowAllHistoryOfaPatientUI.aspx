<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowAllHistoryOfaPatientUI.aspx.cs" Inherits="CommunityMedicineAutomationApp.UI.ShowAllHistoryOfaPatientUi" %>

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
                        <h1 class="page-header fa fa-history fa-2x"> All History
                        </h1>
                        <div class="breadcrumb pull-right">
                            <span class="print fa fa-print pull-right"> Print Document</span>
                        </div>
                        <ol class="breadcrumb">
                            <li>
                                <i class="fa fa-home"></i><a href="index.aspx"> Home</a>
                            </li>
                            <li class="active">
                                <i class="fa fa-history"></i> Patient History
                            </li>
                        </ol>
                        
                    </div>
                </div>

                <div class="row">
                    <form role="form" id="treatmentForm" runat="server" method="POST">
                        <div class="col-lg-12 ">

                            <div class="form-group col-sm-3">
                                <label class="col-sm-5">Voter Id:</label>
                                <asp:TextBox ID="patientVoterIdTextBox" runat="server" class="form-control col-sm-6 error"  ></asp:TextBox>
                            </div>
                            <div class="form-group col-sm-3">
                                <label class="col-sm-5">Name:</label>
                                <asp:TextBox ID="patientNameTextBox" runat="server" class="form-control col-sm-6"></asp:TextBox>
                            </div>
                            <div class="form-group col-sm-4">
                                <label class="col-sm-5">Address:</label>
                                <asp:TextBox ID="patientAddressTextBox" runat="server" class="form-control col-sm-6" TextMode="MultiLine"></asp:TextBox>
                            </div>
                            
                            <div class="form-group col-sm-3">
                                <asp:Button ID="showDetailsButton" class="btn btn-default" runat="server" Text="Show Details" OnClick="showDetailsButton_Click"   />
                            </div>

                        </div>
                        <div class="col-lg-12">
                            <div class="" id="section" runat="server" >
                                
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
    <script src="../js/jquery.printpage.js"></script>
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
            $('span.print').printPage();
            $('.gvdatatable').dataTable({});
            $('#dateTextBox').datepicker({
                format: "dd/mm/yyyy"
            });
        });
    </script>


</body>

</html>
