<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Minerva._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <nav aria-label="breadcrumb" >
        <ol class="breadcrumb">
            <li class="breadcrumb-item active">Home</li>
        </ol>
    </nav>

    <h1>Welcome to Minerva</h1>

    <form action="main.html">
        <div class="col-form-group">
            <label class="col-form-label" for="username">Username:</label>
            <input class="col-form-control" type="text" name="username" id="username">
        </div>

        <div class="col-form-group">
            <label class="col-form-label" for="password">Password:</label>
            <input class="col-form-control" type="password" name="password" id="password">
        </div>

        <div class="col-form-group">
            <input type="submit" value="Submit" >
        </div>
    </form>
    

</asp:Content>
