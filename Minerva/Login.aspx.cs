using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Minerva
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private bool ValidateUser(string uName, string pWord)
        {
            SqlConnection conn;
            SqlCommand cmd;
            string lookupPassword = null;

            // Check for invalid username.
            // username must not be null and must be between 1 and 15 characters.
            if ((null == username) || (0 == username.Text.Length) || (username.Text.Length > 18))
            {
                System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of username failed.");
                return false;
            }

            // Check for invalid passWord.
            // passWord must not be null and must be between 1 and 25 characters.
            if ((null == password) || (0 == password.Text.Length) || (password.Text.Length > 25))
            {
                System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of passWord failed.");
                return false;
            }

            try
            {
           
                // string to use to connect to your local SQL Server.
                conn = new SqlConnection(@"server=LAPTOP-LKVILIHC\MSSQLSERVER01;Trusted_Connection=True;database=Minerva");
                conn.Open();

                // Create SqlCommand to select pwd field from users table given supplied username.
                cmd = new SqlCommand("Select pwd from users where uname=@username", conn);
                cmd.Parameters.Add("@username", SqlDbType.VarChar, 25);
                cmd.Parameters["@username"].Value = username;

                // Execute command and fetch pwd field into lookupPassword string.
                lookupPassword = (string)cmd.ExecuteScalar();

                // Cleanup command and connection objects.
                cmd.Dispose();
                conn.Dispose();
            }
            catch (Exception ex)
            {
                // Add error handling here for debugging.
                // This error message should not be sent back to the caller.
                System.Diagnostics.Trace.WriteLine("[ValidateUser] Exception " + ex.Message);
            }

            // If no password found, return false.
            if (null == lookupPassword)
            {
                // You could write failed login attempts here to event log for additional security.
                return false;
            }

            // Compare lookupPassword and input passWord, using a case-sensitive comparison.
            return (0 == string.Compare(lookupPassword, password.Text, false));
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            if(ValidateUser(username.Text,password.Text))
                if (user.Value == "employee")
                {
                    Response.Redirect("~/EmployeeHomePage.aspx");
                }
                else if (user.Value == "admin")
                {
                    Response.Redirect("~/AdminHomePage.aspx");
                }
        }
    }
}