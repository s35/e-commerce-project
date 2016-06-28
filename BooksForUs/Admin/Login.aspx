<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BooksForUs.Admin.Login" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" style="width:100%; height:100%;">
<head runat="server">
    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" />

    <!-- jQuery library -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>

    <!-- Latest compiled JavaScript -->
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
    <title>Books for All</title>
    <style>
        body {
            background-image: url('http://res.freestockphotos.biz/pictures/6/6793-a-stack-of-books-isolated-on-a-white-background-pv.jpg');
            background-size: 100% 100%;
            background-repeat: no-repeat;
        }

        form1 {
            float: right;
        }
    </style>
</head>


<body style="height:100%;width:100%;">

    <!-- Ajax functionality below -->


    <form id="form1" runat="server">
        <div id="form">
            <div class="container">
                <div id="loginbox" style="margin-top: 250px; float:right; padding-left:100px;" class="mainbox col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            <div class="panel-title">Admin Sign In</div>
                        </div>

                        <div style="padding-top: 30px" class="panel-body">

                            <div style="display: none" id="login-alert" class="alert alert-danger col-sm-12"></div>

                            <form id="loginform" class="form-horizontal" role="form">

                                <div style="margin-bottom: 25px" class="input-group">
                                    <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                                    <!--<input id="login-username" type="text" class="form-control" name="username" value="" placeholder="username or email">-->
                                    <asp:TextBox ID="TextBox1" runat="server" CssClass ="form-control" placeholder="username"></asp:TextBox>
                                </div>

                                <div style="margin-bottom: 25px" class="input-group">
                                    <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                                    <!--<input id="login-password" type="password" class="form-control" name="password" placeholder="password">-->
                                     <asp:TextBox ID="TextBox2" runat="server" CssClass ="form-control" placeholder="password" type="password"></asp:TextBox>
                                </div>

                                <div style="margin-top: 10px" class="form-group">
                                    <!-- Button -->

                                    <div class="col-md-12 controls">
                                        <!-- <a id="btn-login" href="#" class="btn btn-success" onclick ="Button1_Click">Login  </a> -->
                                        <asp:Button Text = "Login" runat ="server" OnClick="Button1_Click" CssClass="btn btn-success"/>
                                        <asp:Label runat="server" ID="Label2" CssClass="alert alert-danger fade in" style="float:right;">alert</asp:Label>
                                        <br />
                                    </div>
                                </div>
                            </form>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>

</body>
</html>
