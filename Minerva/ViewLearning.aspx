<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewLearning.aspx.cs" Inherits="Minerva.ViewLearning" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="Default.aspx">Home</a></li>
            <li class="breadcrumb-item"><a href="Login.aspx">Login</a></li>
            <li class="breadcrumb-item"><a href="EmployeeHomePage.aspx">Employee Homepage</a></li>
            <li class="breadcrumb-item active">View Learning</li>
        </ol>
    </nav>

    <h1>View Your Learning Assignments</h1>
    <h3 class ="container">Assigned Learning</h3>
    <div class ="container">
    <asp:GridView ID="gridAssigned" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:HyperLinkField DataTextField="CourseName" DataNavigateUrlFields="CourseLink" HeaderText="Name"  />
            <asp:BoundField DataField="CourseDesc" HeaderText="Description" />
            <asp:BoundField DataField="CourseDuration" HeaderText="Duration" />
            <asp:BoundField DataField="DateDue" HeaderText="Date Due" />
        </Columns>

    </asp:GridView>
    </div>
    <h3 class ="container">Completed Learning</h3>
    <div class="container">
    <asp:GridView ID="gridCompleted" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="CourseName" HeaderText="Name" />
            <asp:BoundField DataField="CourseDesc" HeaderText="Description" />
            <asp:BoundField DataField="CourseDuration" HeaderText="Duration" />
            <asp:BoundField DataField="DateAssigned" HeaderText="Date Assigned" />
        </Columns>

    </asp:GridView>
    </div>

</asp:Content>
