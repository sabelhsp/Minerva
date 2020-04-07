<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditLearning.aspx.cs" Inherits="Minerva.AddLearning" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <nav aria-label="breadcrumb" >
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="AdminHomePage.aspx">Administrator Homepage</a></li>
            <li class="breadcrumb-item active">Edit Learning</li>
        </ol>
    </nav>

    <h4>Hold CTRL + left click to select multiple courses/employees</h4>

    <div class="col-sm-6 form-group">
        <asp:ListBox runat="server" ID="listCourses" SelectionMode="Multiple" CssClass="form-control"></asp:ListBox>
    </div>
    <div class="col-sm-6 form-group">
        <asp:ListBox runat="server" ID="listUsers" SelectionMode="Multiple" CssClass="form-control"></asp:ListBox>
    </div>
    <br />
    <asp:Button runat="server" ID="btnAddCourses" Text="Add Courses" class="btn btn-success" OnClick="btnAddCourses_Click" />
    <asp:Label runat="server" ID="testTxt"></asp:Label>

</asp:Content>
