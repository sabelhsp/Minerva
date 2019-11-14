<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Minerva.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <nav aria-label="breadcrumb" >
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="Default.aspx">Home</a></li>
            <li class="breadcrumb-item active">Contact</li>
        </ol>
    </nav>
    <h2><%: Title %></h2>
    <h3>Reach us at</h3>
    <address>
        2600 Clifton Ave<br />
        Cincinnati, OH 45221<br />
        <abbr title="Phone">P:</abbr>
        513.556.6000
    </address>

    <address>
        <strong>Support:</strong>   <a href="mailto:sabelhsp@mail.uc.edu">Software Developer: Scott Sabelhaus</a><br />
        <strong>Support:</strong> <a href="mailto:johns7jh@mail.uc.edu">Hardware/Infrastructure & Security: Jospeh Johnston</a>
    </address>
</asp:Content>
