<%@ Page Title="Admin Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminHomePage.aspx.cs" Inherits="Minerva.AdminHomePage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <nav aria-label="breadcrumb" >
        <ol class="breadcrumb">
            <li class="breadcrumb-item active">Home</li>
        </ol>
    </nav>

    <h1>Welcome to Minerva - Admin</h1>

    <div class="row">
        <div class="col-lg-4">
            <h2>Add/Remove Employee</h2>
        </div>
        <div class="col-lg-4">
            <h2>Add Learning/Objectives for Employees</h2>
        </div>
        <div class="col-lg-4">
            <h2>Edit Company Wiki</h2>
        </div>
    </div>

        

</asp:Content>
