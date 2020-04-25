<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Minerva._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

	<nav aria-label="breadcrumb">
    	<ol class="breadcrumb">
        	<li class="breadcrumb-item active">Home</li>
    	</ol>
	</nav>

	<h1 class="text-center">Welcome to Minerva</h1>

   



	<style>
* {
  box-sizing: border-box;
}

/* Create three equal columns that floats next to each other */
.column {
 
  width: 80%;
  padding: 10px;
  height: auto; /* Should be removed. Only for demonstration */
  margin-left:auto;
  margin-right:auto;
}

/* Clear floats after the columns */
.row:after {
  content: "";
  display: table;
  clear: both;
}

.logoplacement {
	margin-left: auto;
	margin-right: auto;


}
</style>

<img src="Minerva.png" style="display: block;
  margin-left: auto;
  margin-right: auto;
  width: 25%;" />
<div class="row">
  <div class="column" style="background-color:#7AD7F0;">
	<b><h2>The Facts</h2></b>
	<h3><p>Minerva is an all-inclusive website for a company’s new hire needs!
22% of turnover happens in the first 45 days from the start of employment. </p></h3>
  </div>
  <div class="column" style="background-color:#92DFF3;">
	<h2>Our Mission</h2>
	<h3><p>New employees can enter a new job easily by:</p>

<p>-Receiving their own personal account and space on the company network.</p>

<p>-Logging in with their new credentials before their first day to access learning objectives, such as safety documents, dress codes, and schedule.</p>

<p>-Viewing the company's wiki or knowledge library to get a head-start on learning their new job requirements.</p>

<p>-Accessing forms that need to be completed beforethe first day on the job. </p></h3>
  </div>
  <div class="column" style="background-color:#B7E9F7;">
	<h2>Our Features</h2>
	<p><h3><p>Administrative users can edit information on Minerva with ease by:</p>

<p>-Adding or removing employees with a few simple steps-Editing learning objectives and wiki articles.</p>

<p>-Importing these from the company's specific knowledge library.</p>

<p>-Providing forms and documents that need to be completed before entering the job field.</p>

<p>-Sharing safety requirements and instructive videos with new hires.</p></h3>
  </div>
</div>
</asp:Content>
