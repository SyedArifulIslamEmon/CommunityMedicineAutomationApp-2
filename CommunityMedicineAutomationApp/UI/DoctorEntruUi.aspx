<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DoctorEntruUi.aspx.cs" Inherits="CommunityMedicineAutomationApp.UI.DoctorEntruUi" %>

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
    <link href="../font-awesome/css/font-awesome.min.css" rel="stylesheet" />

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
                        <a href="index.aspx"><i class="fa fa-fw fa-home"></i>Home</a>
                    </li>
                    <li>
                        <a href="DoctorEntruUi.aspx"><i class="fa fa-fw fa-user-md"></i>Doctor Entry</a>
                    </li>
                    <li>
                        <a href="MedicineStockReportUI.aspx"><i class="fa fa-fw fa-medkit"></i>Medicine Stock Report</a>
                    </li>
                    <li>
                        <a href="TreatmentGivenUI.aspx"><i class="fa fa-fw fa-stethoscope"></i>Treatment Given</a>
                    </li>
                    <li>
                        <a href="ShowAllHistoryOfaPatientUI.aspx"><i class="fa fa-fw fa-history"></i>Show All History</a>
                    </li>
                   
                </ul>
            </div>
            <!-- /.navbar-collapse -->
        </nav>

        <div id="page-wrapper">

            <div class="container-fluid">

                <!-- Page Heading -->
                <div class="row">
                    <div class="col-lg-12">
                        <h1 class="page-header fa fa-user-md fa-2x"> Doctor Entry</h1>
                        <ol class="breadcrumb">
                            <li>
                                <i class="fa fa-home"></i><a href="index.aspx"> Home</a>
                            </li>
                            <li class="active">
                                <i class="fa fa-user-md"></i> Doctor Entry
                            </li>
                        </ol>
                    </div>
                </div>
                <!-- /.row -->

                <div class="row">
                    <div class="col-lg-4">
                        <form role="form" runat="server" id="doctorForm">

                            <div class="form-group">
                                <label>Name </label>
                                <asp:TextBox ID="doctorNameTextBox" class="form-control" runat="server"></asp:TextBox>

                            </div>
                            <div class="form-group">
                                <label>Degree</label>
                                <asp:TextBox ID="doctorDegreeTextBox" class="form-control" runat="server"></asp:TextBox>

                            </div>
                            <div class="form-group">
                                <label>Specialization</label>
                                <asp:TextBox ID="doctorSpecializationTextBox" class="form-control" runat="server"></asp:TextBox>

                            </div>
                            <div class="form-group">
                                <asp:Button ID="saveDoctorButton" runat="server" class="btn btn-default" Text="Save Doctor" OnClick="saveDoctorButton_Click" />
                            </div>

                            <br />
                            <br />
                            <div class="form-group">
                                 <asp:Label ID="messageLabel" runat="server" Text=""></asp:Label>
                            </div>
                           
                        </form>
                    </div>
                </div>

            </div>

        </div>
      
    </div>

    <script src="../js/jquery.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <script src="../js/jquery.validate.min.js"></script>
    <script src="../js/jquery.dataTables.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#doctorForm").validate({
                rules: {
                    doctorNameTextBox: "required",
                    doctorDegreeTextBox: "required",
                    doctorSpecializationTextBox: "required",
                },
                messages: {
                    doctorNameTextBox: "Please enter Doctor Name",
                    doctorDegreeTextBox: "Please enter Doctor Degree",
                    doctorSpecializationTextBox: "Please enter Specialization",
                },
            });
        });
    </script>

</body>

</html>
