<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="BooksForAll.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet" />

    <!-- Custom CSS -->
    <link href="css/shop-homepage.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
            <ContentTemplate>

                <nav class="navbar navbar-inverse navbar-fixed-top" role="navigation">
                    <div class="container">
                        <!-- Brand and toggle get grouped for better mobile display -->
                        <div class="navbar-header">
                            <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                                <span class="sr-only">Toggle navigation</span>
                                <span class="icon-bar"></span>
                                <span class="icon-bar"></span>
                                <span class="icon-bar"></span>
                                <span class="icon-bar"></span>
                            </button>
                            <asp:LinkButton runat="server" CssClass="navbar-brand" ID="BrandName" PostBackUrl="~/Default.aspx">Books for All</asp:LinkButton>
                            <!--<a class="navbar-brand" href="http://booksforall.azurewebsites.net/Default.aspx">Books For All</a>-->
                        </div>
                        <!-- Collect the nav links, forms, and other content for toggling -->
                        <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                            <ul class="nav navbar-nav">
                                <li>
                                    <a href="Admin/Login.aspx">Admin</a>
                                </li>
                                <li>
                                    <a href="www.sauravm.me">Contact</a>
                                </li>
                                <li>
                                    <a href="#" class="btn dropdown-toggle">About</a>
                                </li>
                            </ul>
                            <ul class="nav navbar-nav navbar-right">
                                <li>
                                    <a href="Orders.aspx">View your Past Orders</a>
                                </li>

                            </ul>
                        </div>
                        <!-- /.navbar-collapse -->
                    </div>
                    <!-- /.container -->
                </nav>

                <asp:Panel runat="server" CssClass="panel">
                    <div style="text-align: center; margin-bottom:15px;">
                        <h3>
                            <asp:Label runat="server" CssClass="label label-primary"> - View + Track your Orders - </asp:Label></h3>
                        <div class="panel-heading">
                            Enter your name and billing zipcode to retreive your orders :-
                        </div>
                        <div class="panel-body">
                            Full Name:
                        <asp:TextBox runat="server" ID="NameSearch"></asp:TextBox>
                            Billing Zipcode:
                        <asp:TextBox runat="server" ID="ZipcodeSearch"></asp:TextBox>
                        </div>
                        <asp:Button runat="server" CssClass="btn btn-primary" Text="Search" ID="SearchOrdersBtn" OnClick="SearchOrdersBtn_Click"  />
                        <br />
                    </div>
                </asp:Panel>

                <asp:Panel runat="server" ID="NotFoundPnl" Visible="false" HorizontalAlign="Center">
                    <div>
                        <h3><span class="glyphicon glyphicon-alert"></span></h3>
                    </div>

                    <h2><asp:Label runat="server" CssClass="label label-warning" ForeColor="Black">No records found... Please try again!</asp:Label></h2>

                </asp:Panel>

                <asp:Panel runat="server" ID="OrderQueryResults" HorizontalAlign="Center" BorderStyle="Solid"
                    BorderColor="Black" Style=" margin-bottom:20px; margin-left:20px; margin-right:20px;" ScrollBars="Vertical" >


                    <div class="panel" id="TitleDetails" style="float:left; margin-left:30px;">
                         <h2><asp:Label runat="server" CssClass="label label-warning" ForeColor="Black"># Order Details </asp:Label></h2>
                        <asp:DataList runat="server" ID="OrderDetailsdl" RepeatColumns="1">
                            <ItemTemplate>

                                <div>
                                    <div class="alert-info">
                                        <h3>Order Placed On -
                                <asp:Label runat="server" Text='<%# Eval("OrderDateTime") %>' ID="TimeLabel"></asp:Label></h3>
                                    </div>
                                    <h4 style="text-align: center;">Name:
                                <asp:Label runat="server" Text='<%# Eval("CustomerName") %>' ID="NameLabel"></asp:Label>
                                        <br />
                                        Email:
                                <asp:Label runat="server" Text='<%# Eval("CustomerEmailID") %>' ID="EmailLabel"></asp:Label>
                                        <br />
                                        Zipcode:
                                <asp:Label runat="server" Text='<%# Eval("CustomerZipcode") %>' ID="ZipcodeLabel"></asp:Label>
                                        <br />

                                        Total Titles Purchased:
                                <asp:Label runat="server" Text='<%# Eval("TotalTitles") %>' ID="TotalTitlesLabel"></asp:Label>
                                        Total Price: $
                                <asp:Label runat="server" Text='<%# Eval("TotalPrice") %>' ID="TotalPriceLabel"></asp:Label></h4>
                                    <hr />

                                </div>
                            </ItemTemplate>
                        </asp:DataList>
                    </div>

                    <div class="panel">
                         <h2 style="padding-bottom:15px;"><asp:Label runat="server" CssClass="label label-warning" ForeColor="Black"> # Title Details </asp:Label></h2>
                        <asp:DataList runat="server" ID="dlTitles" RepeatColumns="5">
                            <ItemTemplate>
                                <div class="panel">
                                    <div class="panel-heading">
                                        
                                        <img src='<%# Eval("ImageURL") %>' runat="server" id="TitlePhoto" style="width: 100px; height: 125px; text-align:center;" /><br />
                                        
                                        <br />
                                        <asp:Label runat="server" ID="TitleNameLbl" Text='<%# Eval("Title") %>'></asp:Label><br />
                                        <asp:Label runat="server" Text='<%# Eval("OrderDateTime") %>'></asp:Label>
                                        <br />
                                    </div>
                                    <div class="panel-body">
                                        Price: $<asp:Label runat="server" ID="TitlePriceLabel" Text='<%# Eval("Price") %>'></asp:Label>
                                        Quantity:
                                        <asp:Label runat="server" ID="TitleQuantityLabel" Text='<%# Eval("TotalTitles") %>'></asp:Label>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:DataList>
                    </div>

                </asp:Panel>

                <!-- jQuery -->
                <script src="js/jquery.js"></script>

                <!-- Bootstrap Core JavaScript -->
                <script src="js/bootstrap.min.js"></script>

            </ContentTemplate>
        </asp:UpdatePanel>

    </form>
</body>
</html>
