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
        <asp:RadioButtonList runat="server" ID="radioWiki" AutoPostBack="true" Width="25%" RepeatDirection="Horizontal" OnSelectedIndexChanged="radioWiki_SelectedIndexChanged">
            <asp:ListItem Selected="True" Text="Add" Value="add"></asp:ListItem>
            <asp:ListItem Text="Delete" Value="delete"></asp:ListItem>
        </asp:RadioButtonList>
        <div>
        <asp:Label runat="server" ID="lblTitle">Title:</asp:Label>
        <asp:TextBox runat="server" ID="txtTitle"></asp:TextBox>
        </div>
        <div>
        <asp:Label runat="server" ID="lblDesc">Description:</asp:Label>
        <asp:TextBox runat="server" ID="txtDesc" TextMode="MultiLine"></asp:TextBox>
        </div>
        <asp:Label runat="server" ID="lblTags">Tags:</asp:Label>
        <asp:ListBox runat="server" ID="listTags" SelectionMode="Multiple" OnPreRender="listTags_PreRender"></asp:ListBox>
        <div>
        <asp:Label runat="server" ID="lblLink">Link:</asp:Label>
        <asp:TextBox runat="server" ID="txtLink"></asp:TextBox>
        </div>
        <asp:Button runat="server" ID="btnWiki" Text="Add" OnClick="btnWiki_Click" />
    </div>
    <div>
        <h3>Add/Remove Tags</h3>
        <asp:RadioButtonList runat="server" ID="radioTag" AutoPostBack="true" Width="25%" RepeatDirection="Horizontal" OnSelectedIndexChanged="radioTag_SelectedIndexChanged">
            <asp:ListItem Selected="True" Text="Add" Value="add"></asp:ListItem>
            <asp:ListItem Text="Delete" Value="delete"></asp:ListItem>
        </asp:RadioButtonList>
        <asp:Label runat="server" ID="lblTagName">Tag Name:</asp:Label>
        <asp:TextBox runat="server" ID="txtTagName"></asp:TextBox><br />
        <asp:Button runat="server" ID="btnTags" Text="Add" OnClick="btnTags_Click" />
    </div>
</asp:Content>