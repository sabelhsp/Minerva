using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Minerva
{
    public partial class ViewWiki : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookieName = new HttpCookie("UserName");
            cookieName = Request.Cookies["UserName"];

            if (cookieName == null)
            {
                Response.Redirect("Login.aspx");
            }

        }

        private void FillTags()
        {
            ddlTags.Items.Clear();
            string cmdText = "Select TagName From Tags";
            SqlConnection cnn;
            SqlCommand cmd;
            SqlDataAdapter adapter = new SqlDataAdapter();

            cnn = new SqlConnection(@"server=LAPTOP-LKVILIHC\MSSQLSERVER01;Trusted_Connection=True;database=Minerva");
            cnn.Open();
            cmd = new SqlCommand(cmdText, cnn);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {
                ddlTags.Items.Add(Convert.ToString(dr["TagName"]));
            }
            cmd.Dispose();
            cnn.Dispose();
            cnn.Close();
        }

        
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ClearResults();
            List<int> wikiIds = new List<int>();
            SqlConnection cnn;
            SqlCommand cmd;
            string cmdText;
            SqlDataAdapter adapter = new SqlDataAdapter();
            if (txtTitle.Text!="")
            {
                cmdText = "Select WikiId from WikiPage where Title like '%"+txtTitle.Text+"%';";
                cnn = new SqlConnection(@"server=LAPTOP-LKVILIHC\MSSQLSERVER01;Trusted_Connection=True;database=Minerva");
                cnn.Open();
                cmd = new SqlCommand(cmdText, cnn);
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    wikiIds.Add(Convert.ToInt32(dr.GetValue(0)));
                }
                cmd.Dispose();
                cnn.Dispose();
                cnn.Close();
            }
            if (txtDesc.Text!="")
            {
                cmdText = "Select WikiId from WikiPage where Description like '%" + txtDesc.Text + "%'";
                cnn = new SqlConnection(@"server=LAPTOP-LKVILIHC\MSSQLSERVER01;Trusted_Connection=True;database=Minerva");
                cnn.Open();
                cmd = new SqlCommand(cmdText, cnn);
                SqlDataReader dreader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dreader.Read())
                {
                    wikiIds.Add(Convert.ToInt32(dreader.GetValue(0)));
                }
                cmd.Dispose();
                cnn.Dispose();
                cnn.Close();
            }
            for (int i = 0; i < ddlTags.Items.Count; i++)
            {
                if (ddlTags.Items[i].Selected)
                {
                    cmdText = "Select WikiTags.WikiId from WikiTags join Tags on WikiTags.TagId = Tags.TagId Where Tags.TagName = '"+ddlTags.Items[i].Value.TrimEnd()+"'; ";
                    cnn = new SqlConnection(@"server=LAPTOP-LKVILIHC\MSSQLSERVER01;Trusted_Connection=True;database=Minerva");
                    cnn.Open();
                    cmd = new SqlCommand(cmdText, cnn);
                    SqlDataReader datar = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (datar.Read())
                    {
                        wikiIds.Add(Convert.ToInt32(datar.GetValue(0)));
                    }
                    cmd.Dispose();
                    cnn.Dispose();
                    cnn.Close();
                }
            }

            wikiIds = wikiIds.Distinct().ToList();

            if (wikiIds.Count > 0)
            {
                cmdText = "Select Title From WikiPage Where WikiId = " + wikiIds[0];
                for (int i = 1; i < wikiIds.Count; i++)
                {
                    cmdText = cmdText + " or WikiId = " + wikiIds[i];
                }
                cmdText = cmdText + ";";
                cnn = new SqlConnection(@"server=LAPTOP-LKVILIHC\MSSQLSERVER01;Trusted_Connection=True;database=Minerva");
                cnn.Open();
                cmd = new SqlCommand(cmdText, cnn);
                SqlDataReader data = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (data.Read())
                {
                    listPages.Items.Add(Convert.ToString(data.GetValue(0)));
                }
                cmd.Dispose();
                cnn.Dispose();
                cnn.Close();
            }
            else
            {
                lblTest.Visible = true;
            }

            
            
        }

        protected void ddlTags_PreRender(object sender, EventArgs e)
        {
            FillTags();
        }

        private void ClearSearch()
        {
            ddlTags.Items.Clear();
            txtDesc.Text = "";
            txtTitle.Text = "";
            FillTags();
        }
        private void ClearResults()
        {
            listPages.Items.Clear();
            lblTest.Visible = false;
        }

        string link;
        protected void listPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            string title = listPages.SelectedItem.Value;
            
            SqlConnection cnn;
            SqlCommand cmd;
            string cmdText;
            cmdText = "Select Link From WikiPage Where Title = '"+title+"';";
            cnn = new SqlConnection(@"server=LAPTOP-LKVILIHC\MSSQLSERVER01;Trusted_Connection=True;database=Minerva");
            cnn.Open();
            cmd = new SqlCommand(cmdText, cnn);
            SqlDataReader datar = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (datar.Read())
            {
                link = Convert.ToString(datar.GetValue(0));
            }
            cmd.Dispose();
            cnn.Dispose();
            cnn.Close();

            wikiFrame.Src = link;
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearSearch();
            ClearResults();
        }
    }
}