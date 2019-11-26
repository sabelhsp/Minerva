<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Minerva._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item active">Home</li>
        </ol>
    </nav>

    <h1 class="text-center">Welcome to Minerva</h1>

    <h3 class="text-center text-primary">Minerva is an all-inclusive website for a company’s new hire needs!<br />22% of turnover happens in the first 45 days from the start of employment. 
       <br />The goal of Minerva is to decrease this turnover rate by providing new employees with access to job information before they even start. 
        <br />Employers also benefit from Minerva by cutting down on emails or meetings with new hires, and simply granting them access to Minerva.</h3>
    <div class="row">
        <div class="col-lg-6">
            <h2>New Hire Benefits</h2>
            <h3 class="text-primary">
                New employees can enter a new job easily by: <br /><br /> 
                -Receiving their own personal account and space on the company network.
                <br /><br />-Logging in with their new credentials before their first day to access learning objectives, such as safety documents, dress codes, and schedule.
                <br /><br />-Viewing the company's wiki or knowledge library to get a head-start on learning their new job requirements.
                <br /><br />-Accessing forms that need to be completed beforethe first day on the job.
            </h3>
        </div>
        <div class="col-lg-6">
            <h2>Administrator Abilities</h2>
            <h3 class="text-primary">
                Administrative users can edit information on Minerva with ease by:<br /><br />
                -Adding or removing employees with a few simple steps-Editing learning objectives and wiki articles.<br /><br />
                -Importing these from the company's specific knowledge library.<br /><br />
                -Providing forms and documents that need to be completed before entering the job field.<br /><br />
                -Sharing safety requirements and instructive videos with new hires.<br /><br />
            </h3>
        </div>
        <h3 class="text-center">Browse the Minerva website to get started! <br /><br />
        <a class="text-success" href="Login.aspx">Click Here to be re-directed to our login page.</a></h3>

    </div>
</asp:Content>
