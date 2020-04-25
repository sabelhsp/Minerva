<%@ Page Title="Admin Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminHomePage.aspx.cs" Inherits="Minerva.AdminHomePage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item active">Administrator Homepage</li>
        </ol>
    </nav>

    <h1>Welcome to Minerva - Administrator</h1>

    <div class="row">
        <a href="EditEmployee.aspx">
            <div class="col-lg-4">
                <h2>Add/Remove Employee</h2>
                <asp:Image ImageUrl="~/images/NewHire.png" Height="200px" runat="server" />
            </div>
        </a>
        <a href="EditLearning.aspx">
            <div class="col-lg-4">
                <h2>Add Learning/Objectives</h2>
                <asp:Image ImageUrl="~/images/Learning.jpg" Height="200px" runat="server" />
            </div>
        </a>
        <a href="EditWiki.aspx">
            <div class="col-lg-4">
                <h2>Edit Company Wiki</h2>
                <asp:Image ImageUrl="~/images/Wiki.jpg" Height="200px" runat="server" />
            </div>
        </a>
    </div>
</asp:Content>
