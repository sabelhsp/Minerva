<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditWiki.aspx.cs" Inherits="Minerva.EditWiki" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <nav aria-label="breadcrumb" >
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="Default.aspx">Home</a></li>
            <li class="breadcrumb-item"><a href="Login.aspx">Login</a></li>
            <li class="breadcrumb-item"><a href="AdminHomePage.aspx">Administrator Homepage</a></li>
            <li class="breadcrumb-item active">Edit Wiki</li>
        </ol>
    </nav>
    
    <div>
        <h3>Add/Remove Wiki Pages</h3>
        <asp:RadioButtonList runat="server" ID="radioWiki" AutoPostBack="true" Width="25%" RepeatDirection="Horizontal">
            <asp:ListItem Selected="True" Text="Add" Value="add"></asp:ListItem>
            <asp:ListItem Text="Delete" Value="delete"></asp:ListItem>
        </asp:RadioButtonList>
        <asp:Label runat="server" ID="lblTitle">Title:</asp:Label>
        <asp:TextBox runat="server" ID="txtTitle"></asp:TextBox><br />
        <asp:Label runat="server" ID="lblDesc">Description:</asp:Label>
        <asp:TextBox runat="server" ID="txtDesc" TextMode="MultiLine"></asp:TextBox><br />
        <asp:Label runat="server" ID="lblTags">Tags:</asp:Label>
        <asp:ListBox runat="server" ID="listTags" SelectionMode="Multiple"></asp:ListBox><br />
        <asp:Label runat="server" ID="Label1">Link:</asp:Label>
        <asp:TextBox runat="server" ID="txtLink"></asp:TextBox>
    </div>
    <div>
        <h3>Add/Remove Tags</h3>
        <asp:RadioButtonList runat="server" ID="radioTag" AutoPostBack="true" Width="25%" RepeatDirection="Horizontal">
            <asp:ListItem Selected="True" Text="Add" Value="add"></asp:ListItem>
            <asp:ListItem Text="Delete" Value="delete"></asp:ListItem>
        </asp:RadioButtonList>
        <asp:Label runat="server" ID="lblTagName">Tag Name:</asp:Label>
        <asp:TextBox runat="server" ID="txtTagName"></asp:TextBox>
    </div>
</asp:Content>