<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditEmployee.aspx.cs" Inherits="Minerva.EditEmployee" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <nav aria-label="breadcrumb" >
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="AdminHomePage.aspx">Administrator Homepage</a></li>
            <li class="breadcrumb-item active">Add/Remove Employee</li>
        </ol>
    </nav>
    <nav>
         <h2>What would you like to do?</h2><h4>
        <asp:RadioButtonList AutoPostBack="true" runat="server" ID="RadioButtonListEdit" Width="25%" RepeatDirection="Horizontal" OnSelectedIndexChanged="RadioButtonListEdit_SelectedIndexChanged" >
            <asp:ListItem Selected="True" Text="Add" Value="add"></asp:ListItem>
            <asp:ListItem Text="Edit" Value="edit"></asp:ListItem>
            <asp:ListItem Text="Delete" Value="delete"></asp:ListItem>
        </asp:RadioButtonList></h4>
    </nav>

    <div class="form-group col-lg-12">
        <asp:Label ID="labelUserId" runat="server" Text="User ID:"></asp:Label>
        <asp:TextBox ID="textBoxUserId" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:Button ID="btnUserIdSearch" runat="server" Text="Search" OnClick="btnUserIdSearch_Click" CssClass="btn btn-primary" />
        <asp:Label ID="labelFoundUser" runat="server"></asp:Label><br />
        <asp:Label ID="labelFirstName" runat="server" Text="First Name:"></asp:Label>
        <asp:TextBox ID="textBoxFirstName" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:Label ID="labelLastName" runat="server" Text="Last Name:"></asp:Label>
        <asp:TextBox ID="textBoxLastName" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:Label ID="labelEmail" runat="server" Text="Email:"></asp:Label>
        <asp:TextBox ID="textBoxEmail" runat="server" TextMode="Email" CssClass="form-control"></asp:TextBox>
        <asp:Label ID="labelPhone" runat="server" Text="Phone Number:"></asp:Label>
        <asp:TextBox ID="textBoxPhone" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:Label ID="labelEditPassword" runat="server" Text="Password:"></asp:Label>
        <asp:TextBox ID="textBoxEditPassword" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:Label ID="labelSSN" runat="server" Text="Social Security Number:"></asp:Label>
        <asp:TextBox ID="textBoxSSN" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:Label ID="labelDOB" runat="server" Text="Date of Birth:"></asp:Label>
        <asp:TextBox ID="textBoxDOB" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:Label ID="labelAddress" runat="server" Text="Address:"></asp:Label>
        <asp:TextBox ID="textBoxAddress" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:Label ID="labelAdminRights" runat="server" Text="Admin Privileges?"></asp:Label>
        <asp:CheckBox ID="checkBoxAdmin" runat="server" Text="Yes" /><br />
        <asp:Button ID="btnSubmitEditEmployee" runat="server" Text="Submit" OnClick="btnSubmitEditEmployee_Click" CssClass="btn btn-success" />
        <asp:Label ID="labelUserExists" runat="server"></asp:Label>
    </div>
</asp:Content>