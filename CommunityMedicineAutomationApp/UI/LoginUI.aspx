<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginUI.aspx.cs" Inherits="CommunityMedicineAutomationApp.UI.Login" %>

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
    <link href="../css/jquery.dataTables.css" rel="stylesheet" />
    <link href="../css/form-elements.css" rel="stylesheet" />
    <link href="../css/style.css" rel="stylesheet" />

</head>

<body>

    <div id="wrapper">

        <nav class="navbar navbar-inverse navbar-fixed-top" role="navigation">

            <div class="navbar-header">

                <a class="navbar-brand" href="LoginUI.aspx">User Log In</a>
            </div>


        </nav>
        <div class="top-content">
            <div class="container">
                <div class="row">
                    <div class="col-sm-6 col-sm-offset-3 form-box">
                        <div class="form-top">
                            <div class="form-top-left">
                                <h3>Login to our site</h3>
                                <p>Enter Center Code and Password to log on:</p>
                            </div>
                            <div class="form-top-right">
                                <i class="fa fa-lock"></i>
                            </div>
                        </div>
                        <div class="form-bottom">
                            <form role="form"  id="logInForm" runat="server" method="post">
                                <div class="form-group">
                                    <label class="sr-only">Username</label>
                                    <asp:TextBox ID="centerCodeTextBox" runat="server" placeholder="Center code..." class=" form-control" ></asp:TextBox>
                                    
                                </div>
                                <div class="form-group">
                                    <label class="sr-only"s>Password</label>
                                    <asp:TextBox ID="passwordTextBox" runat="server" TextMode="Password" placeholder="Password..." class=" form-control"></asp:TextBox>
                                    
                                </div>
                                <div class="form-group">
                                    <asp:Button ID="logInButton" runat="server" class="btn button " Text="Log In" OnClick="logInButton_Click" />
                                </div>
                                 <div class="form-group">
                                    <asp:Label ID="messageLabel" runat="server" Text=""></asp:Label>
                                </div>
                            </form>
                        </div>
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
            $("#logInForm").validate({
                rules: {
                    centerCodeTextBox: "required",
                    passwordTextBox: "required",
                },
                messages: {
                    centerCodeTextBox: "Please enter Center code",
                    passwordTextBox: "Please enter Password",
                },
            });
            $('.gvdatatable').dataTable({});
        });
    </script>
</body>

</html>


