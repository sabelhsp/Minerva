using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Minerva
{
    public partial class EditWiki : System.Web.UI.Page
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
            listTags.Items.Clear();
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
                listTags.Items.Add(Convert.ToString(dr["TagName"]));
            }
            cmd.Dispose();
            cnn.Dispose();
            cnn.Close();
        }

        Int64 wikiId;
        private Int64 ReadWikiId()
        {
            string cmdText = "Select WikiId From WikiPage Where Title = '"+txtTitle.Text+"';";
            SqlConnection cnn;
            SqlCommand cmd;
            SqlDataAdapter adapter = new SqlDataAdapter();

            cnn = new SqlConnection(@"server=LAPTOP-LKVILIHC\MSSQLSERVER01;Trusted_Connection=True;database=Minerva");
            cnn.Open();
            cmd = new SqlCommand(cmdText, cnn);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {
                wikiId = Convert.ToInt64(dr.GetValue(0));
            }
            cmd.Dispose();
            cnn.Dispose();
            cnn.Close();
            return wikiId;
        }

        Int64 TagId;
        private Int64 ReadTagId(string TagName)
        {
            string cmdText = "Select TagId From Tags Where TagName = '" + TagName + "';";
            SqlConnection cnn;
            SqlCommand cmd;
            SqlDataAdapter adapter = new SqlDataAdapter();

            cnn = new SqlConnection(@"server=LAPTOP-LKVILIHC\MSSQLSERVER01;Trusted_Connection=True;database=Minerva");
            cnn.Open();
            cmd = new SqlCommand(cmdText, cnn);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {
                TagId = Convert.ToInt64(dr.GetValue(0));
            }
            cmd.Dispose();
            cnn.Dispose();
            cnn.Close();
            return TagId;
        }

        protected void radioWiki_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioWiki.SelectedValue == "add")
            {
                lblTitle.Visible = true;
                txtTitle.Visible = true;
                lblTags.Visible = true;
                listTags.Visible = true;
                lblDesc.Visible = true;
                txtDesc.Visible = true;
                btnWiki.Text = "Add";
                FillTags();
            }
            if (radioWiki.SelectedValue == "delete")
            {
                lblTitle.Visible = false;
                txtTitle.Visible = false;
                lblTags.Visible = false;
                listTags.Visible = false;
                lblDesc.Visible = false;
                txtDesc.Visible = false;
                btnWiki.Text = "Delete";
            }
            ClearWiki();
        }

        protected void radioTag_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioTag.SelectedValue == "add")
            {
                btnTags.Text = "Add";
            }
            if (radioTag.SelectedValue == "delete")
            {
                btnTags.Text = "Delete";
            }

            listTags.Items.Clear();
        }

        protected void btnWiki_Click(object sender, EventArgs e)
        {
            if (radioWiki.SelectedValue == "add")
            {
                string cmdText = "Insert into WikiPage(Title,Description,Link) Values ('" + txtTitle.Text + "','" + txtDesc.Text + "','" + txtLink.Text + "');";
                SqlConnection cnn;
                SqlCommand cmd;
                SqlCommand command;
                SqlDataAdapter adapter = new SqlDataAdapter();
                cnn = new SqlConnection(@"server=LAPTOP-LKVILIHC\MSSQLSERVER01;Trusted_Connection=True;database=Minerva");
                cnn.Open();
                cmd = new SqlCommand(cmdText, cnn);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                for (int i = 0; i < listTags.Items.Count; i++)
                {
                    if (listTags.Items[i].Selected)
                    {
                        string commandText = "Insert into WikiTags(WikiId, TagId) Values (" + ReadWikiId() + "," + ReadTagId(listTags.Items[i].Value) + ");";
                        command = new SqlCommand(commandText, cnn);
                        command.ExecuteNonQuery();
                    }
                }
                
                cnn.Dispose();
                cnn.Close();
            }
            if (radioWiki.SelectedValue == "delete")
            {
                string cmdText = "Delete From WikiPage Where Link = '" + txtLink.Text + "';";
                SqlConnection cnn;
                SqlCommand cmd;
                SqlDataAdapter adapter = new SqlDataAdapter();
                cnn = new SqlConnection(@"server=LAPTOP-LKVILIHC\MSSQLSERVER01;Trusted_Connection=True;database=Minerva");
                cnn.Open();
                cmd = new SqlCommand(cmdText, cnn);
                cmd.ExecuteNonQuery();

                cmd.Dispose();
                cnn.Dispose();
                cnn.Close();
            }
            ClearWiki();

        }

        protected void btnTags_Click(object sender, EventArgs e)
        {
            if (radioTag.SelectedValue == "add")
            {

                string cmdText = "insert into Tags(TagName) Values('" + txtTagName.Text + "');";
                SqlConnection cnn;
                SqlCommand cmd;
                SqlDataAdapter adapter = new SqlDataAdapter();
                cnn = new SqlConnection(@"server=LAPTOP-LKVILIHC\MSSQLSERVER01;Trusted_Connection=True;database=Minerva");
                cnn.Open();
                cmd = new SqlCommand(cmdText, cnn);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cnn.Dispose();
                cnn.Close();
            }
            if (radioTag.SelectedValue == "delete")
            {
                string cmdText = "delete from Tags Where TagName = '" + txtTagName.Text + "';";
                SqlConnection cnn;
                SqlCommand cmd;
                SqlDataAdapter adapter = new SqlDataAdapter();
                cnn = new SqlConnection(@"server=LAPTOP-LKVILIHC\MSSQLSERVER01;Trusted_Connection=True;database=Minerva");
                cnn.Open();
                cmd = new SqlCommand(cmdText, cnn);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cnn.Dispose();
                cnn.Close();
            }
            ClearTag();
            listTags.Items.Clear();
        }

        private void ClearTag()
        {
            txtTagName.Text = "";
            listTags.Items.Clear();
        }

        private void ClearWiki()
        {
            txtTitle.Text = "";
            txtDesc.Text = "";
            txtLink.Text = "";
            listTags.Items.Clear();
        }

        protected void listTags_PreRender(object sender, EventArgs e)
        {
            FillTags();
        }
    }
}