<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditEmployee.aspx.cs" Inherits="Minerva.EditEmployee" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <nav aria-label="breadcrumb" >
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="Default.aspx">Home</a></li>
            <li class="breadcrumb-item"><a href="Login.aspx">Login</a></li>
            <li class="breadcrumb-item"><a href="AdminHomePage.aspx">Administrator Homepage</a></li>
            <li class="breadcrumb-item active">Add/Remove Employee</li>
        </ol>
    </nav>
    <nav>
         <h2>What would you like to do?</h2><h4>
        <asp:RadioButtonList AutoPostBack="true" Width="25%" runat="server" ID="RadioButtonListEdit" RepeatDirection="Horizontal" OnSelectedIndexChanged="RadioButtonListEdit_SelectedIndexChanged" >
            <asp:ListItem Selected="True" Text="Add" Value="1"></asp:ListItem>
            <asp:ListItem Text="Edit" Value="2"></asp:ListItem>
            <asp:ListItem Text="Delete" Value="3"></asp:ListItem>
        </asp:RadioButtonList></h4>
    </nav>

    <nav>
        <asp:Label ID="labelUserId" runat="server" Text="User ID:"></asp:Label>
        <asp:TextBox ID="textBoxUserId" runat="server"></asp:TextBox>
        <asp:Button ID="btnUserIdSearch" runat="server" Text="Search" OnClick="btnUserIdSearch_Click" />
        <asp:Label ID="labelFoundUser" runat="server"></asp:Label>
        <br />
        <asp:Label ID="labelFirstName" runat="server" Text="First Name:"></asp:Label>
        <asp:TextBox ID="textBoxFirstName" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="labelLastName" runat="server" Text="Last Name:"></asp:Label>
        <asp:TextBox ID="textBoxLastName" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="labelEmail" runat="server" Text="Email:"></asp:Label>
        <asp:TextBox ID="textBoxEmail" runat="server" TextMode="Email"></asp:TextBox>
        <br />
        <asp:Label ID="labelPhone" runat="server" Text="Phone Number:"></asp:Label>
        <asp:TextBox ID="textBoxPhone" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="labelEditPassword" runat="server" Text="Password:"></asp:Label>
        <asp:TextBox ID="textBoxEditPassword" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="labelSSN" runat="server" Text="Social Security Number:"></asp:Label>
        <asp:TextBox ID="textBoxSSN" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="labelDOB" runat="server" Text="Date of Birth:"></asp:Label>
        <asp:TextBox ID="textBoxDOB" runat="server" TextMode="Date"></asp:TextBox>
        <br />
        <asp:Label ID="labelAddress" runat="server" Text="Address:"></asp:Label>
        <asp:TextBox ID="textBoxAddress" runat="server" style="margin-top: 21"></asp:TextBox>
        <br />
        <asp:Label ID="labelAdminRights" runat="server" Text="Admin Privileges?"></asp:Label>
        <asp:CheckBox ID="checkBoxAdmin" runat="server" Text="Yes" />
        <br />
        <asp:Button ID="btnSubmitEditEmployee" runat="server" Text="Submit" />
        <asp:Label ID="labelUserExists" runat="server"></asp:Label>
    </nav>
</asp:Content>