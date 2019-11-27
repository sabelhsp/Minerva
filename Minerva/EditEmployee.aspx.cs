using System;
using System.Web.UI;
using System.Data.SqlClient;

namespace Minerva
{
    public partial class EditEmployee : System.Web.UI.Page
    {
        private bool showForm = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Request.Cookies["UserName"].Value == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void RadioButtonListEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            //show form will be true until the form needs to be hidden
            if (RadioButtonListEdit.SelectedValue == "2")
            {
                showForm = false;
            }
            else if(RadioButtonListEdit.SelectedValue == "3")
            {
                showForm = false;
            }
            else
            {
                showForm = true;
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
            string connectionString;
            string commandText = "SELECT * FROM UserInfo WHERE UserId="+userIdSearch;
            string output = "";
            SqlConnection cnn;
            SqlCommand command;
            SqlDataReader dataReader;
            SqlDataAdapter adapter = new SqlDataAdapter();
            connectionString = @"Server=LAPTOP-LKVILIHC\MSSQLSERVER01;Database=Minerva;Trusted_Connection=True";
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
                textBoxDOB.Text = Convert.ToString(dataReader.GetValue(7)); ;
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
                if (RadioButtonListEdit.SelectedValue == "1")
                {
                    btnSubmitEditEmployee.Visible = !showForm;
                    labelUserExists.Text = "This UserId already exists please use another Id# if you intend to add a new employee.";
                }
                else
                {
                    btnSubmitEditEmployee.Visible = showForm;
                }
            }
        }
    }
}