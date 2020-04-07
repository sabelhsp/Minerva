using System;
using System.Web.UI;
using System.Data.SqlClient;
using System.Web;

namespace Minerva
{
    public partial class EditEmployee : System.Web.UI.Page
    {
        int operatorId;
        SqlConnection cnn;
        SqlCommand command;
        string connectionString = @"Server=LAPTOP-LKVILIHC\MSSQLSERVER01;Database=Minerva;Trusted_Connection=True";
        private bool showForm = true;


        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookieName = new HttpCookie("UserName");
            cookieName = Request.Cookies["UserName"];

            if (cookieName == null)
            {
                Response.Redirect("Login.aspx");
            }
            HttpCookie cookieId = new HttpCookie("UserId");
            cookieId = Request.Cookies["UserId"];
            operatorId = Convert.ToInt32(cookieId.Value);
            
        }

        protected void RadioButtonListEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            //show form will be true until the form needs to be hidden
            if (RadioButtonListEdit.SelectedValue == "edit")
            {
                showForm = false;
                labelUserExists.Text = "";
                labelFoundUser.Text = "";
                ClearTextFields();
            }
            else if(RadioButtonListEdit.SelectedValue == "delete")
            {
                showForm = false;
                labelUserExists.Text = "";
                labelFoundUser.Text = "";
                ClearTextFields();
            }
            else
            {
                showForm = true;
                labelUserExists.Text = "";
                labelFoundUser.Text = "";
                ClearTextFields();
            }
            //User Search Button will always be visible so that you can confirm a UserID does or deos not exist
            labelFirstName.Visible = showForm;
            labelLastName.Visible = showForm;
            labelEmail.Visible = showForm;
            labelPhone.Visible = showForm;
            labelEditPassword.Visible = showForm;
            labelSSN.Visible = showForm;
            labelDOB.Visible = showForm;
            labelAddress.Visible = showForm;
            labelAdminRights.Visible = showForm;
            textBoxFirstName.Visible = showForm;
            textBoxLastName.Visible = showForm;
            textBoxEmail.Visible = showForm;
            textBoxPhone.Visible = showForm;
            textBoxEditPassword.Visible = showForm;
            textBoxSSN.Visible = showForm;
            textBoxDOB.Visible = showForm;
            textBoxAddress.Visible = showForm;
            checkBoxAdmin.Visible = showForm;
            btnSubmitEditEmployee.Visible = showForm;
        }

        protected void btnUserIdSearch_Click(object sender, EventArgs e)
        {
            labelUserExists.Text = "";
            int userIdSearch = Convert.ToInt32(textBoxUserId.Text.TrimStart(new char[] { '0' }));
            string output = "";
            SqlDataReader dataReader;
            SqlDataAdapter adapter = new SqlDataAdapter();
            string commandText = "SELECT * FROM UserInfo WHERE UserId=" + userIdSearch;
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            command = new SqlCommand(commandText, cnn);
            dataReader = command.ExecuteReader();
            while (dataReader.Read()) {
                output = "Found User";
                textBoxFirstName.Text = Convert.ToString(dataReader.GetValue(1)).TrimEnd();
                textBoxLastName.Text = Convert.ToString(dataReader.GetValue(2)).TrimEnd();
                textBoxEmail.Text = Convert.ToString(dataReader.GetValue(3)).TrimEnd();
                textBoxPhone.Text = Convert.ToString(dataReader.GetValue(4)).TrimEnd();
                textBoxEditPassword.Text = Convert.ToString(dataReader.GetValue(5)).TrimEnd();
                textBoxSSN.Text = Convert.ToString(dataReader.GetValue(6)).TrimEnd();
                textBoxDOB.Text = Convert.ToString(dataReader.GetValue(7)).TrimEnd();
                textBoxAddress.Text = Convert.ToString(dataReader.GetValue(8)).TrimEnd();
                checkBoxAdmin.Checked = Convert.ToBoolean(dataReader.GetValue(9));
                
            }
            labelFoundUser.Text = output;
            command.Dispose();
            cnn.Close();

            if(output == "Found User")
            {
                showForm = true;
                labelFirstName.Visible = showForm;
                labelLastName.Visible = showForm;
                labelEmail.Visible = showForm;
                labelPhone.Visible = showForm;
                labelEditPassword.Visible = showForm;
                labelSSN.Visible = showForm;
                labelDOB.Visible = showForm;
                labelAddress.Visible = showForm;
                labelAdminRights.Visible = showForm;
                textBoxFirstName.Visible = showForm;
                textBoxLastName.Visible = showForm;
                textBoxEmail.Visible = showForm;
                textBoxPhone.Visible = showForm;
                textBoxEditPassword.Visible = showForm;
                textBoxSSN.Visible = showForm;
                textBoxDOB.Visible = showForm;
                textBoxAddress.Visible = showForm;
                checkBoxAdmin.Visible = showForm;
                btnSubmitEditEmployee.Visible = showForm;
                if (RadioButtonListEdit.SelectedValue == "add")
                {
                    btnSubmitEditEmployee.Visible = !showForm;
                    labelUserExists.Text = "This UserId already exists please use another Id# if you intend to add a new employee.";
                    ClearTextFields();
                }
                else
                {
                    btnSubmitEditEmployee.Visible = showForm;
                }
            }
            else
            {
                labelFoundUser.Text = "No user found.";
                labelUserExists.Text = "";
            }
        }

        protected void btnSubmitEditEmployee_Click(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(textBoxUserId.Text.TrimStart(new char[] { '0' }));
            string firstName = Convert.ToString(textBoxFirstName.Text).TrimEnd();
            string lastName = Convert.ToString(textBoxLastName.Text).TrimEnd();
            string email = Convert.ToString(textBoxEmail.Text).TrimEnd();
            string phoneNum = Convert.ToString(textBoxPhone.Text).TrimEnd();
            string password = Convert.ToString(textBoxEditPassword.Text).TrimEnd();
            int sSN = Convert.ToInt32(textBoxSSN.Text.TrimStart(new char[] { '0' }));
            string dOB = Convert.ToString(textBoxDOB.Text).TrimEnd();
            string address = Convert.ToString(textBoxAddress.Text).TrimEnd();
            int adminRights = Convert.ToInt32(checkBoxAdmin.Checked);
            labelFoundUser.Text = "";
            if (RadioButtonListEdit.SelectedValue == "add")
            {         
                string commandText = @"Insert Into UserInfo (UserId,FirstName,LastName,Email,Phone,Password,SSN,DOB,Address,isAdmin,AdminId) Values ("
                    +userId+",'" + firstName + "','" + lastName + "','" + email + "','" + phoneNum + "','" + password + "'," + sSN + ",'"
                    + dOB + "','" + address + "'," + adminRights+ "," + operatorId+ ");";
                cnn = new SqlConnection(connectionString);
                cnn.Open();
                command = new SqlCommand(commandText, cnn);
                int numRowAdd = command.ExecuteNonQuery();
                command.Dispose();
                cnn.Close();
                labelUserExists.Text = "User has been added successfully. " +numRowAdd+ " number of rows affected.";
                ClearTextFields();
                if (Convert.ToBoolean(adminRights))
                {
                    commandText = @"Insert Into Admin (AdminId, FirstName, LastName, Email, admin) Values (" +
                        userId + ", '" + firstName + "', '" + lastName + "', '" + email + "', " + adminRights + ");";
                    cnn = new SqlConnection(connectionString);
                    cnn.Open();
                    command = new SqlCommand(commandText, cnn);
                    command.ExecuteNonQuery();
                    command.Dispose();
                    cnn.Close();
                }
                System.IO.Directory.CreateDirectory("C:\\Users\\shaus\\OneDrive\\Documents\\Senior Design 2019\\VSCode\\Minerva\\Minerva\\" + firstName+" "+lastName);

            }
            if (RadioButtonListEdit.SelectedValue == "edit")
            {
                string commandText = @"UPDATE UserInfo " +
                    "SET FirstName = '"+firstName+"', LastName = '"+lastName+"', Email = '"+email+"', Phone = '"+phoneNum
                    +"', Password = '"+password+"', SSN = "+sSN+", DOB = '"+dOB+"', Address = '"+address+"', isAdmin = "+adminRights+", AdminId = "+operatorId+
                    " WHERE UserId = "+userId+";";
                cnn = new SqlConnection(connectionString);
                cnn.Open();
                command = new SqlCommand(commandText, cnn);
                int numRowEdit = command.ExecuteNonQuery();
                command.Dispose();
                cnn.Close();
                labelUserExists.Text = "User has been edited successfully. " + numRowEdit + " number of rows affected.";

                if (Convert.ToBoolean(adminRights))
                {
                    commandText = @"UPDATE Admin SET AdminId = " + userId + ", FirstName = '" + firstName + "', LastName = '" + lastName + "', Email = '" + email +
                        "', admin = " + adminRights + " WHERE AdminId = "+userId+";";
                    cnn = new SqlConnection(connectionString);
                    cnn.Open();
                    command = new SqlCommand(commandText, cnn);
                    command.ExecuteNonQuery();
                    command.Dispose();
                    cnn.Close();
                }
            }
            if (RadioButtonListEdit.SelectedValue == "delete")
            {
                string commandText = @"DELETE FROM UserInfo WHERE UserId = " + userId+";";
                cnn = new SqlConnection(connectionString);
                cnn.Open();
                command = new SqlCommand(commandText, cnn);
                int numRowDelete = command.ExecuteNonQuery();
                command.Dispose();
                cnn.Close();
                labelUserExists.Text = "User has been deleted successfully. " + numRowDelete + " number of rows affected.";
                ClearTextFields();
            }


        }

        public void ClearTextFields()
        {
            textBoxUserId.Text = "";
            textBoxFirstName.Text = "";
            textBoxLastName.Text = "";
            textBoxEmail.Text = "";
            textBoxPhone.Text = "";
            textBoxEditPassword.Text = "";
            textBoxSSN.Text = "";
            textBoxDOB.Text = "";
            textBoxAddress.Text = "";
            checkBoxAdmin.Checked = false;
        }
    }
}