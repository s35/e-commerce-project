<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AddProducts.aspx.cs" Inherits="BooksForUs.Admin.AddProducts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form123" runat="server">
    <div>
        <h3>Add a New Book for Sale</h3>
    </div>

    <div>
  <div class="form-group">
    <label for="title">Title</label>
    <asp:TextBox ID="TitleTextBox" runat="server" CssClass ="form-control"></asp:TextBox>
  </div>

  <div class="form-group">
    <label for="genre">Genre</label>
      <asp:DropDownList ID="ddlGenre" runat="server"></asp:DropDownList>
      <!--<asp:TextBox ID="GenreTextBox" runat="server" CssClass ="form-control"></asp:TextBox>-->
  </div>

                         <div class="form-group">
    <label for="descrip">Description</label>
    <asp:TextBox ID="DescripTextBox" runat="server" CssClass ="form-control"></asp:TextBox> 
    
  </div>

            <!-- Book Image Added -->
                     <div class="form-group">
    <label for="Image">Title Image</label>
                         <asp:FileUpload ID="uploadPhoto" runat="server" CssClass="btn btn-primary"/>
                         <!--<asp:Button  Text="Add Image" ID="AddImageBtn" runat="server" CssClass="btn btn-primary"/>-->
    <!--<asp:TextBox ID="TextBox1" runat="server" CssClass ="form-control"></asp:TextBox>--> 
    
  </div>

              <div class="form-group">
    <label for="price">Price</label>
    <asp:TextBox ID="PriceTextBox3" runat="server" CssClass ="form-control" ></asp:TextBox>
  </div>

             <div class="form-group">
    <label for="quantity">Quantity</label>
    <asp:TextBox ID="QuantityBox" runat="server" CssClass ="form-control" ></asp:TextBox>
  </div>


            <!--<button type="submit" class="btn btn-default">Add!</button>-->
            <asp:Button Text = "Add" runat ="server" ID="add_Button" OnClick="AddTitleButton_Click" CssClass="btn btn-primary"/>
    </div>


</form>
</asp:Content>
