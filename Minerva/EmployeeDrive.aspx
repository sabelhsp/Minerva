<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeeDrive.aspx.cs" Inherits="Minerva.EmployeeDrive" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <nav aria-label="breadcrumb" >
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="Default.aspx">Home</a></li>
            <li class="breadcrumb-item"><a href="Login.aspx">Login</a></li>
            <li class="breadcrumb-item"><a href="EmployeeHomePage.aspx">Employee Homepage</a></li>
            <li class="breadcrumb-item active">Employee Drive</li>
        </ol>
    </nav>

    <div class="content-container-fluid">
        <div class="row">
            <div class="cols-sample-area">
                <div id="fileExplorer">
                    <div id="helpDialog" title="Use of FileExplorer">
                        <div class="text-content">
                            <div class="header-content">Need assistance?</div>
                            <div class="header-content">Our help document assists you to know more about FileExplorer control.</div>
                            <div class="header-content">Please refer -> <a href="//help.syncfusion.com/js/fileexplorer/overview" target="_blank">Help Document</a></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        var toolsList = ["layout", "creation", "navigation", "addressBar", "editing", "copyPaste", "getProperties", "customTool", "searchBar"];
        var tools = ej.FileExplorer.prototype.defaults.tools;
        tools.customTool = [{
            name: "Help",
            tooltip: "Help ",
            css: "e-fileExplorer-toolbar-icon Help",
            action: function () {
                $("#helpDialog").ejDialog("open");
            }
        }];

        $(function () {
            var localServ, ajaxDataType;
            localServ = "http://js.syncfusion.com/demos/ejServices/api/FileExplorer/FileOperations";

            if (isRestrictCrossOrigin()) {
                //IE8, IE9 browser restrict CORS, so we set ajax request as JSONP to enable CORS
                ajaxDataType = "jsonp";
                //we have called "PerformJSONPAction" method to handle JSONP AJAX requests
                localServ = "http://js.syncfusion.com/demos/ejServices/api/FileExplorer/FileOperationsCors";
            }

            $("#fileExplorer").ejFileExplorer({
                isResponsive: true,
                width: "100%",
                minWidth: "150px",
                fileTypes: "*.png,*.gif,*.jpg,*.jpeg,*.docx",
                toolsList: toolsList,
                layout: "largeicons",
                tools: tools,
                path: "http://js.syncfusion.com/demos/ejServices/Content/FileBrowser/",
                ajaxAction: localServ,
                ajaxDataType: ajaxDataType
            });

            $("#helpDialog").ejDialog({
                enableResize: true, enableModal: true, showOnInit: false, width: 350, maxWidth: "100%", cssClass: "e-fe-dialog"
            });
        });
        function isRestrictCrossOrigin() {
            browserInfo = ej.browserInfo();
            return (browserInfo.name == 'msie' && browserInfo.version <= 9) ? true : false;
        }
    </script>
</asp:Content>
