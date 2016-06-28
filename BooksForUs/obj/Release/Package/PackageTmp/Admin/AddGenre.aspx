<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AddGenre.aspx.cs" Inherits="BooksForUs.Admin.AddGenre" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <div>
        <h3>Add a New Genre</h3>
    </div>

    <div>
        <form role="form" runat="server">
  <div class="form-group">
    <label for="title">Genre</label>
       <asp:TextBox ID="genrebox" runat="server" CssClass ="form-control"></asp:TextBox>
  </div>
            <asp:Button Text = "Add" runat ="server" OnClick="AddGenreButton_Click" CssClass="btn btn-primary"/>
            </form>
            </div>

</asp:Content>
