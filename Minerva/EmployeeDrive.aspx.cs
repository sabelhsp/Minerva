using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Minerva
{
    public partial class EmployeeDrive : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookieName = new HttpCookie("UserName");
            cookieName = Request.Cookies["UserName"];

            if (cookieName == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!this.IsPostBack)
            {
                DirectoryInfo rootInfo = new DirectoryInfo(Server.MapPath("~/Vehicles/"));
                this.PopulateTreeView(rootInfo, null);
            }
        }

        private void PopulateTreeView(DirectoryInfo dirInfo, TreeNode treeNode)
        {
            foreach (DirectoryInfo directory in dirInfo.GetDirectories())
            {
                TreeNode directoryNode = new TreeNode
                {
                    Text = directory.Name,
                    Value = directory.FullName
                };

                if (treeNode == null)
                {
                    //If Root Node, add to TreeView.
                    TreeView1.Nodes.Add(directoryNode);
                }
                else
                {
                    //If Child Node, add to Parent Node.
                    treeNode.ChildNodes.Add(directoryNode);
                }

                //Get all files in the Directory.
                foreach (FileInfo file in directory.GetFiles())
                {
                    //Add each file as Child Node.
                    TreeNode fileNode = new TreeNode
                    {
                        Text = file.Name,
                        Value = file.FullName,
                        Target = "_blank",
                        NavigateUrl = (new Uri(Server.MapPath("~/"))).MakeRelativeUri(new Uri(file.FullName)).ToString()
                    };
                    directoryNode.ChildNodes.Add(fileNode);
                }

                PopulateTreeView(directory, directoryNode);
            }
        }
    }
}