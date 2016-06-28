<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BooksForAll.Default" %>

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

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">

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
                            <asp:LinkButton runat="server" CssClass="navbar-brand" OnClick="BrandName_Click" ID="BrandName" PostBackUrl="~/Default.aspx">Books for All</asp:LinkButton>
                            <!--<a class="navbar-brand" href="http://booksandall.azurewebsites.net/Default.aspx">Books For All</a>-->
                        </div>
                        <!-- Collect the nav links, forms, and other content for toggling -->
                        <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                            <ul class="nav navbar-nav">
                                <li>
                                    <a href="Admin/Login.aspx">Admin</a>
                                </li>
                                <li>
                                    <asp:LinkButton runat="server" Text="Contact" OnClick="Contact_Click"></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton runat="server" Text="About" OnClick="About_Click"></asp:LinkButton>
                                </li>
                            </ul>
                            <ul class="nav navbar-nav navbar-right">
                                <li>
                                    <a href="Orders.aspx">View your Past Orders</a>
                                </li>
                                <li>
                                    <asp:Button runat="server" ID="CartButton" OnClick="Cart_Clicked" CssClass="btn btn-primary" Style="margin-top: 9px;" Text="Cart [ 0 ]" />
                                </li>
                                <li>
                                    <asp:LinkButton runat="server" Text="Clear Cart" OnClick="ClearCart_Click" ID="CartClearButton"></asp:LinkButton>
                                </li>

                            </ul>
                        </div>
                        <!-- /.navbar-collapse -->
                    </div>
                    <!-- /.container -->
                </nav>

                <!-- Page Content -->

                <div class="container">

                    <div class="row" style="height: 1px;">

                        <!-- Shop/Sort By DataLists Below -->

                        <div class="col-md-3">
                            <asp:Label runat="server" CssClass="lead" Text="Shop By Genre" ID="GenreHeading"></asp:Label>

                            <div class="list-group">
                                <asp:DataList ID="DataList1" runat="server">
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" CssClass="list-group-item" Text='<%# Eval("GenreName") %>'
                                            CommandArgument='<%# Eval("GenreID") %>' OnClick="Genre_Click" Width="262px"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:DataList>
                            </div>

                            <asp:Label runat="server" CssClass="lead" Text="Shop By Price" ID="ByPriceLabel"></asp:Label>

                            <asp:Panel runat="server" ID="ByPricePanel">
                                <div class="list-group">
                                    <asp:LinkButton runat="server" CssClass="list-group-item" Text="Low to High" OnClick="LowtoHigh_Click"></asp:LinkButton>
                                    <asp:LinkButton runat="server" CssClass="list-group-item" Text="High to Low" OnClick="HightoLow_Click"></asp:LinkButton>
                                </div>

                            </asp:Panel>

                        </div>

                        <!-- Empty Cart Panel Below -->

                        <div class="col-md-12" id="emptycart" runat="server" visible="false">
                            <div style="text-align: center;">
                                <asp:Image runat="server" src="Images/shopping-cart.jpg" />
                                <h2><span class="label label-warning">Your Cart is Empty ! </span></h2>
                            </div>
                        </div>


                        <!-- Order Successfully Placed Panel Below -->

                        <asp:Panel runat="server" ID="OrderPlacedPanel" Visible="false">
                            <div style="text-align: center;" class="panel">
                                <div>
                                    <h3><span class="glyphicon glyphicon-thumbs-up"></span></h3>
                                </div>
                                <h3>Thank you!</h3>
                                <h4>Order placed successfully!</h4>
                                <h4>Transaction details will be emailed to you momentarily.</h4>
                                <asp:Label ID="TransactionNumberLabel" runat="server"></asp:Label>
                                <asp:Label ID="orderMessage" runat="server"></asp:Label>
                                <asp:Label ID="TrackingInfo" runat="server"></asp:Label>
                                <br />
                                <asp:LinkButton runat="server" CssClass="btn btn-primary" Text="Back to Home"
                                    href="http://booksforall.azurewebsites.net/" />
                            </div>
                        </asp:Panel>


                        <!-- Contact & About Panels Below -->


                        <asp:Panel runat="server" ID="ContactPanel" Visible="false">
                            <div style="text-align: center; height: 100%;">
                                <br />
                                <br />
                                <h2><span class="label label-warning">- Contact Us - </span></h2>
                                <h4>
                                    <div>
                                        If you have any questions or concerns, please shoot us an email at
                                        <h3>booksforall2015@gmail.com</h3>
                                        <br />
                                        We appreciate your business!
                                    </div>
                                </h4>
                            </div>

                        </asp:Panel>

                        <asp:Panel runat="server" ID="AboutPanel" Visible="false">
                            <br />
                            <br />
                            <div style="text-align: center; height: 100%;">
                                <img src="Images/stewart.jpg" style="text-align: center; width: 240px; height: 320px;" />
                                <br />
                                <h3>We sell books. All kinds!
                                </h3>
                            </div>

                        </asp:Panel>


                    </div>







                    <!-- Checkout Form Panel Below -->

                    <asp:Panel runat="server" ID="CheckoutPanel" Visible="false">

                        <div class="col-md-3" title="Checkout Form" style="float: right;">
                            <h3>
                                <label class="label label-primary" style="text-align: center; margin-left: 45px;">Checkout Form</label></h3>

                            <span class="input-group-addon" id="NameAddOn2">Name
                                    <asp:TextBox runat="server" CssClass="form-control" Text="First" ID="FirstNameBox"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="FirstNameBox" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:TextBox runat="server" CssClass="form-control" Text="Last" ID="LastNameBox"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="LastNameBox" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            </span>
                            <br />
                            <span class="input-group-addon" id="NameAddOn3">Email Address
                                        <asp:TextBox runat="server" CssClass="form-control" ID="EmailBox"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="EmailBox" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="EmailBox" ErrorMessage="Invalid Email Format" ForeColor="Red"></asp:RegularExpressionValidator>
                            </span>
                            <br />
                            <span class="input-group-addon" id="NameAddOn4">Billing Zipcode
                                         <asp:TextBox runat="server" CssClass="form-control" ID="ZipcodeBox"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="ZipcodeBox" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                            </span>
                            <br />
                            <span class="input-group-addon" id="NameAddOn5">Total Titles
                                       <asp:TextBox runat="server" ID="TotalTitlesBox" ReadOnly="true" CssClass="input-group" Width="238px"> </asp:TextBox>
                            </span>
                            <br />
                            <span class="input-group-addon" id="NameAddOn6">Total Price
                                        <asp:TextBox runat="server" ID="TotalPriceBox" ReadOnly="true" CssClass="input-group" Width="238px"></asp:TextBox>
                            </span>
                            <br />
                            <span class="input-group-addon">
                                <asp:Button runat="server" CssClass="btn btn-primary" Text="Place Order" OnClick="PlaceOrder_Click" />
                            </span>

                        </div>
                    </asp:Panel>


                    <!-- Shopping Cart Panel Below -->


                    <asp:Panel runat="server" ID="CartPanel" CssClass="col-md-8" Visible="false">
                        <div style="text-align: center; float: left;">
                            <asp:DataList runat="server" ID="CartDataList" RepeatColumns="3" CellPadding="50">
                                <ItemTemplate>
                                    <div class="panel panel-default" style="width: 250px; height: 410px;">
                                        <div class="panel-heading" style="height: 250px;">
                                            <img src='<%# Eval("ImageURL") %>' style="width: 150px; height: 180px;" />
                                            <h4 style="margin-bottom: 30px;"><%# Eval("Title") %></h4>
                                        </div>
                                        <div class="panel panel-body">
                                            <h4>Price: $<asp:Label runat="server" ID="CartPriceLabel" Text='<%# Eval("Price") %>'></asp:Label></h4>
                                            <h5><%# Eval("Description") %></h5>
                                            <h5>1 X
                                                    <asp:TextBox runat="server" Text='<%# Eval("Quantity") %>' ID="TitleQuantity" MaxLength="1" AutoPostBack="true"
                                                        OnTextChanged="TitleQuantityBox_TextChanged"></asp:TextBox></h5>
                                            <asp:Button runat="server" ID="RemoveFromCartButton" CommandArgument='<%# Eval("TitleID") %>'
                                                Text="Remove From Cart" Width="100%" CausesValidation="false" OnClick="RemoveFromCart_Click" />
                                        </div>
                                        <asp:HiddenField ID="hfTitleID" runat="server" Value='<%# Eval("TitleID") %>' />
                                        <asp:HiddenField ID="TitleID" runat="server" Value='<%# Eval("TitleID") %>' />
                                    </div>
                                </ItemTemplate>
                            </asp:DataList>
                        </div>
                    </asp:Panel>


                    <!-- Home Page Titles List Panel -->


                    <div class="col-md-9">
                        <div id="heading1">
                            <h4 style="margin-left: 18px;">
                                <asp:Label runat="server" ID="CartLabel"> Popular Books Below -  </asp:Label>
                            </h4>
                        </div>

                        <div class="row">
                            <div class="col-sm-4 col-lg-4 col-md-4">
                                <asp:DataList runat="server" ID="titleDataList" RepeatColumns="3" CellPadding="5">
                                    <ItemTemplate>

                                        <div class="panel panel-default" style="width: 250px; height: 385px; margin: 20px; text-align: center;">
                                            <div class="panel-heading" style="height: 250px;">
                                                <img src='<%# Eval("ImageURL") %>' alt="" style="width: 130px; height: 165px; margin-top: 8px;">
                                                <h4 style="margin-bottom: 30px;"><a href="#">'<%# Eval("Title") %>'</a></h4>
                                            </div>
                                            <div class="panel panel-body">
                                                "<%# Eval("Description") %>"
                                             <br />
                                            </div>
                                            <div>
                                                <asp:Label runat="server" ID="PriceLabel"><h4 style="float:left; padding-left:20px;">Price: $<%# Eval("Price") %></h4></asp:Label>
                                                <asp:Button ID="buyNow" runat="server" Text="Add to Cart"
                                                    CssClass="btn btn-primary" Style="margin-bottom: 5px; padding-right: 40px; width: 120px; text-indent: 0.9em;"
                                                    OnClick="AddToCart_Clicked" CausesValidation="false" CommandArgument='<%#Eval("TitleID") %>' />
                                            </div>
                                            <asp:HiddenField ID="hfTitleID" runat="server" Value='<%#Eval("TitleID") %>' />

                                        </div>

                                    </ItemTemplate>
                                </asp:DataList>
                            </div>


                        </div>

                    </div>
                </div>

                <!-- /.container -->

                <div class="container">

                    <hr>

                    <!-- Footer -->
                    <footer>
                        <div class="row" style="margin-top: 500px;">
                            <div class="col-lg-12">
                                <p>Copyright &copy; Books for All 2015</p>
                            </div>
                        </div>
                    </footer>

                </div>
                <!-- /.container -->

                <!-- jQuery -->
                <script src="js/jquery.js"></script>

                <!-- Bootstrap Core JavaScript -->
                <script src="js/bootstrap.min.js"></script>


                </div>
            </ContentTemplate>

            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="BrandName" />
            </Triggers>
        </asp:UpdatePanel>
    </form>
</body>
</html>
