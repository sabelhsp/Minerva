﻿<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Minerva.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="Default.aspx">Home</a></li>
            <li class="breadcrumb-item active">Login</li>
        </ol>
    </nav>

    <h2><%: Title %></h2>
    <h3>Please log in here.</h3>
    <p>
        If you are a new employee you will use the account information that has been assigned to you to log in.<br />
        If you are an admin change the dropdown box to sign in.
    </p>


    <div class="form-group">
        <asp:Label runat="server" for="username">Username:</asp:Label>
        <asp:TextBox runat="server" type="text" name="username" ID="username" CssClass="form-control"></asp:TextBox>
        <br />
        <asp:Label Width="68px" runat="server" for="password">Password:</asp:Label>
        <asp:TextBox runat="server" type="password" name="password" ID="password" CssClass="form-control"></asp:TextBox>
        <br />
        <select runat="server" id="user" name="User" class="form-control">
            <option value="employee">Employee</option>
            <option value="admin">Admin</option>
        </select>
        <asp:Label ID="labelLoginError" runat="server"></asp:Label>
        <br />
        <asp:Button runat="server" type="submit" Text="Submit" OnClick="Submit_Click" CssClass="btn btn-success"></asp:Button>
    </div>

</asp:Content>
