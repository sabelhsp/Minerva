using System;
using System.Web.UI;
using System.Data.SqlClient;
using System.Web;

namespace Minerva
{
    public partial class EditEmployee : System.Web.UI.Page
    {

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
        }

        protected void RadioButtonListEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            //show form will be true until the form needs to be hidden
            if (RadioButtonListEdit.SelectedValue == "edit")
            {
                showForm = false;
                labelUserExists.Text = "";
                labelFoundUser.Text = "";
            }
            else if(RadioButtonListEdit.SelectedValue == "delete")
            {
                showForm = false;
                labelUserExists.Text = "";
                labelFoundUser.Text = "";
            }
            else
            {
                showForm = true;
                labelUserExists.Text = "";
                labelFoundUser.Text = "";
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
            int userIdSearch = Convert.ToInt32(textBoxUserId.Text);
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
                textBoxFirstName.Text = Convert.ToString(dataReader.GetValue(1));
                textBoxLastName.Text = Convert.ToString(dataReader.GetValue(2));
                textBoxEmail.Text = Convert.ToString(dataReader.GetValue(3));
                textBoxPhone.Text = Convert.ToString(dataReader.GetValue(4));
                textBoxEditPassword.Text = Convert.ToString(dataReader.GetValue(5));
                textBoxSSN.Text = Convert.ToString(dataReader.GetValue(6));
                textBoxDOB.Text = Convert.ToString(dataReader.GetValue(7));
                textBoxAddress.Text = Convert.ToString(dataReader.GetValue(8));
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
                if (RadioButtonListEdit.SelectedValue == "add")
                {
                    btnSubmitEditEmployee.Visible = !showForm;
                    labelUserExists.Text = "This UserId already exists please use another Id# if you intend to add a new employee.";
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
            int userId = Convert.ToInt32(textBoxUserId.Text);
            string firstName = Convert.ToString(textBoxFirstName.Text);
            string lastName = Convert.ToString(textBoxLastName.Text);
            string email = Convert.ToString(textBoxEmail.Text);
            string phoneNum = Convert.ToString(textBoxPhone.Text);
            string password = Convert.ToString(textBoxEditPassword.Text);
            int sSN = Convert.ToInt32(textBoxSSN.Text);
            string dOB = Convert.ToString(textBoxDOB.Text);
            string address = Convert.ToString(textBoxAddress.Text);
            int adminRights = Convert.ToInt32(checkBoxAdmin.Checked);
            if (RadioButtonListEdit.SelectedValue == "add")
            {         
                string commandText = @"Insert Into UserInfo (UserId,FirstName,LastName,Email,Phone,Password,SSN,DOB,Address,Admin) Values ("
                    +userId+",'" + firstName + "','" + lastName + "','" + email + "','" + phoneNum + "','" + password + "'," + sSN + ",'"
                    + dOB + "','" + address + "'," + adminRights + ");";
                cnn = new SqlConnection(connectionString);
                cnn.Open();
                command = new SqlCommand(commandText, cnn);
                int numRow = command.ExecuteNonQuery();
                command.Dispose();
                cnn.Close();
                labelUserExists.Text = "User has been added successfully. " +numRow+ " number of rows affected.";
            }
            if (RadioButtonListEdit.SelectedValue == "edit")
            {
                string commandText = "SELECT * FROM UserInfo WHERE UserId=" + userId;
                cnn = new SqlConnection(connectionString);
                cnn.Open();
                command = new SqlCommand(commandText, cnn);
                command.Dispose();
                cnn.Close();
            }
            if (RadioButtonListEdit.SelectedValue == "delete")
            {
                string commandText = "SELECT * FROM UserInfo WHERE UserId=" + userId;
                cnn = new SqlConnection(connectionString);
                cnn.Open();
                command = new SqlCommand(commandText, cnn);
                command.Dispose();
                cnn.Close();
            }

        }
    }
}