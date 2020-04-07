<%@ Page Title="Employee Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeeHomePage.aspx.cs" Inherits="Minerva.EmployeeHomePage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <nav aria-label="breadcrumb" >
        <ol class="breadcrumb">
            <li class="breadcrumb-item active">Employee Homepage</li>
        </ol>
    </nav>

    <h1>Welcome to Minerva - Employee</h1>

    <div class="row">
        <a href="EmployeeDrive.aspx">
        <div class="col-lg-4">
            <h2>View Files - Your Drive</h2>
            <asp:Image ImageUrl="~/images/File.png" runat="server"/>
        </div>
        </a>
        <a href="ViewLearning.aspx">
        <div class="col-lg-4">
            <h2>View Learning/Objectives</h2>
            <asp:Image ImageUrl="~/images/Learning.jpg" runat="server"/>
        </div>
        </a>
        <a href="ViewWiki.aspx">
        <div class="col-lg-4">
            <h2>Search Company Wiki</h2>
            <asp:Image ImageUrl="~/images/Wiki.jpg" runat="server"/>
        </div>
        </a>
    </div>
        

</asp:Content>
