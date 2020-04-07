<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeeDrive.aspx.cs" Inherits="Minerva.EmployeeDrive" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <nav aria-label="breadcrumb" >
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="EmployeeHomePage.aspx">Employee Homepage</a></li>
            <li class="breadcrumb-item active">Employee Drive</li>
        </ol>
    </nav>

    <h3>
        <asp:Label ID="headerDrive" runat="server"></asp:Label>
    </h3>
    <asp:Button runat="server" CssClass="btn btn-default" ID="btnAddFiles" OnClick="btnAddFiles_Click" Text="Edit Files"/>

    <asp:TreeView ID="TreeView1" runat="server" ImageSet="XPFileExplorer" NodeIndent="15">
        <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
        <NodeStyle Font-Names="Tahoma" Font-Size="12pt" ForeColor="Black" HorizontalPadding="4px"
            NodeSpacing="0px" VerticalPadding="4px"></NodeStyle>
        <ParentNodeStyle Font-Bold="False" />
        <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="0px"
            VerticalPadding="0px" />
    </asp:TreeView>



</asp:Content>
