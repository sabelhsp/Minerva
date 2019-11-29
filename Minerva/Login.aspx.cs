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
        bool adminRights;
        private string passwordLogin;
        private int userIdLogin;
        HttpCookie cookieName = new HttpCookie("UserName");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private bool ValidateUser(string uName, string pWord)
        {
            SqlConnection cnn;
            SqlCommand cmd;
            SqlDataReader dataReader;
            SqlDataAdapter adapter = new SqlDataAdapter();
            string commandText;
            string lookupPassword = null;

            // Check for invalid username.
            // username must not be null and must be between 1 and 15 characters.
            if ((null == username) || (0 == uName.Length) || (uName.Length > 18))
            {
                System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of username failed.");
                return false;
            }

            // Check for invalid password.
            // passWord must not be null and must be between 1 and 25 characters.
            if ((null == password) || (0 == pWord.Length) || (pWord.Length > 25))
            {
                System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of password failed.");
                return false;
            }
            userIdLogin = Convert.ToInt32(uName);
            passwordLogin = pWord;
            commandText = "SELECT * FROM UserInfo WHERE UserId=" + userIdLogin;
            try
            {
           
                // string to use to connect to your local SQL Server.
                cnn = new SqlConnection(@"server=LAPTOP-LKVILIHC\MSSQLSERVER01;Trusted_Connection=True;database=Minerva");
                cnn.Open();

                //create SQL command and set data reader to save name for user.
                cmd = new SqlCommand(commandText, cnn);
                dataReader = cmd.ExecuteReader();
                //While data reader is open we wwant it to pull back some user information.
                while (dataReader.Read())
                {
                    lookupPassword = Convert.ToString(dataReader.GetValue(5));
                    lookupPassword = lookupPassword.TrimEnd();
                    adminRights = Convert.ToBoolean(dataReader.GetValue(9));
                    string tempFirstName = Convert.ToString(dataReader.GetValue(1));
                    string tempLastName = Convert.ToString(dataReader.GetValue(2));
                    tempFirstName = tempFirstName.TrimEnd();
                    tempLastName = tempLastName.TrimEnd();
                    cookieName.Value = tempFirstName + " " + tempLastName;
                    cookieName.Expires = DateTime.Now.AddHours(1);
                }

                // Cleanup command and connection objects.
                cmd.Dispose();
                cnn.Dispose();
                cnn.Close();
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
            return (0 == string.Compare(lookupPassword, pWord, false));
        }

        protected void Submit_Click(object sender, EventArgs e)
        {

            if (ValidateUser(username.Text, password.Text))
            {
                if (user.Value == "employee" && cookieName != null)
                {
                    Response.Cookies.Add(cookieName);
                    Response.Redirect("~/EmployeeHomePage.aspx");
                }
                else if (user.Value == "admin" && adminRights == true && cookieName != null)
                {
                    Response.Cookies.Add(cookieName);
                    Response.Redirect("~/AdminHomePage.aspx");
                }
            }else
            {
                labelLoginError.Text = "Login Failed. Please check your inputs and try again.";
            }
        }
    }
}