<%@ Page Title="Employee Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeeHomePage.aspx.cs" Inherits="Minerva.EmployeeHomePage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <nav aria-label="breadcrumb" >
        <ol class="breadcrumb">
            <li class="breadcrumb-item active">Home</li>
        </ol>
    </nav>

    <h1>Welcome to Minerva - Employee</h1>

    <div class="row">
        <div class="col-lg-4">
            <h2>View Files - Your Drive</h2>
        </div>
        <div class="col-lg-4">
            <h2>View Learning/Objectives</h2>
        </div>
        <div class="col-lg-4">
            <h2>Search Company Wiki</h2>
        </div>
    </div>
        

</asp:Content>
