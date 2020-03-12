<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewWiki.aspx.cs" Inherits="Minerva.ViewWiki" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <nav aria-label="breadcrumb" >
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="Default.aspx">Home</a></li>
            <li class="breadcrumb-item"><a href="Login.aspx">Login</a></li>
            <li class="breadcrumb-item"><a href="EmployeeHomePage.aspx">Employee Homepage</a></li>
            <li class="breadcrumb-item active">View Wiki</li>
        </ol>
    </nav>
    <div runat="server" class=" row">
    <nav class="sidenav fixed col-lg-2" runat="server">
        <asp:Label runat="server" ID="lblKnowId">KnowledgeID</asp:Label>
        <asp:TextBox runat="server" ID="txtKnowId"></asp:TextBox>
        <asp:Label runat="server" ID="lblTitle">Title</asp:Label>
        <asp:TextBox runat="server" ID="txtTitle"></asp:TextBox>
        <asp:Label runat="server" ID="lblDesc">Description</asp:Label>
        <asp:TextBox runat="server" ID="txtDesc"></asp:TextBox>
        <asp:Label runat="server" ID="lblTags">Tags</asp:Label>
        <asp:DropDownList runat="server" ID="ddlTags"></asp:DropDownList>   
    </nav>
    
    <div class="embed-responsive embed-responsive-16by9 col-lg-10">
  <iframe class="embed-responsive-item" src="https://www.wikipedia.org" id="wikiFrame" runat="server"></iframe>
    </div>
    </div>
</asp:Content>