<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Minerva.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <nav aria-label="breadcrumb" >
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="Default.aspx">Home</a></li>
            <li class="breadcrumb-item active">Login</li>
        </ol>
    </nav>

    <h2><%: Title %></h2>
    <h3>Please log in here.</h3>
    <p>If you are a new employee you will use the account information that has been assigned to you to log in.<br />
        If you are an admin change the dropdown box to sign in.</p>
    
    
    <div>
        <asp:label runat="server" for="username">Username:</asp:label>
        <asp:textbox runat="server" type="text" name="username" id="username"></asp:textbox>
    </div>

    <div>
        <asp:label runat="server" for="password">Password: </asp:label>
        <asp:textbox runat="server" type="password" name="password" id="password"></asp:textbox>
    </div>
    <br />
    <div>
        <select runat="server" id="user" name="User">
            <option value="employee">Employee</option>
            <option value="admin">Admin</option>
        </select>
    </div>
    <br />
    <div>
        <asp:button runat="server" type="submit" Text="Submit" OnClick="Submit_Click"></asp:button>
    </div>
    
</asp:Content>
