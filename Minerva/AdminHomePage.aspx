<%@ Page Title="Admin Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminHomePage.aspx.cs" Inherits="Minerva.AdminHomePage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <nav aria-label="breadcrumb" >
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="Default.aspx">Home</a></li>
            <li class="breadcrumb-item"><a href="Login.aspx">Login</a></li>
            <li class="breadcrumb-item active">Admin Homepage</li>
        </ol>
    </nav>

    <h1>Welcome to Minerva - Admin</h1>

    <div class="row">
        <a href="EditEmployee.aspx">
        <div class="col-lg-4">
            <h2>Add/Remove Employee</h2>
            <asp:Image ImageUrl="~/images/NewHire.png" runat="server"/>
        </div>
        </a>
        <a href="EditLearning.aspx">
        <div class="col-lg-4">
            <h2>Add Learning/Objectives</h2>
            <asp:Image ImageUrl="~/images/Learning.jpg" runat="server"/>
        </div>
        </a>
        <a href="EditWiki.aspx">
        <div class="col-lg-4">
            <h2>Edit Company Wiki</h2>
            <asp:Image ImageUrl="~/images/Wiki.jpg" runat="server"/>
        </div>
        </a>
    </div>
</asp:Content>
