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
    public partial class ViewLearning : System.Web.UI.Page
    {
        int userId;
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookieName = new HttpCookie("UserName");
            cookieName = Request.Cookies["UserName"];
            HttpCookie cookieId = new HttpCookie("UserId");
            cookieId = Request.Cookies["UserId"];

            userId = Convert.ToInt32(cookieId.Value);

            if (cookieName == null)
            {
                Response.Redirect("Login.aspx");
            }
            FillTable();
        }

        private void FillTable()
        {
            SqlConnection cnn;
            SqlConnection connection;
            SqlCommand cmd;
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();

            string commandText;
            string cmdText;

            
            try
            {
                cmdText = "Select LearningCourse.CourseName, LearningCourse.CourseLink, LearningCourse.CourseDesc, LearningCourse.CourseDuration, LearningAssignment.DateDue From LearningAssignment " +
                    "Right Join LearningCourse On LearningAssignment.CourseId = LearningCourse.CourseId WHERE UserId = " + userId + " AND Completed = 0;";
                // string to use to connect to your local SQL Server.
                cnn = new SqlConnection(@"server=LAPTOP-LKVILIHC\MSSQLSERVER01;Trusted_Connection=True;database=Minerva");
                cnn.Open();

                //create SQL command and set data reader to save name for user.
                cmd = new SqlCommand(cmdText, cnn);

                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataTable dtbl = new DataTable();
                dtbl.Load(dr);
                gridAssigned.DataSource = dtbl;
                gridAssigned.DataBind();

                cmd.Dispose();
                cnn.Dispose();
                cnn.Close();

                commandText = "Select LearningCourse.CourseName, LearningCourse.CourseDesc, LearningCourse.CourseDuration, LearningAssignment.DateAssigned From LearningAssignment " +
                    "Right Join LearningCourse On LearningAssignment.CourseId = LearningCourse.CourseId WHERE UserId = "+userId+" AND Completed = 1;";
                // string to use to connect to your local SQL Server.
                connection = new SqlConnection(@"server=LAPTOP-LKVILIHC\MSSQLSERVER01;Trusted_Connection=True;database=Minerva");
                connection.Open();
                
                command = new SqlCommand(commandText, connection);
                SqlDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
                DataTable data = new DataTable();
                data.Load(dataReader);
                gridCompleted.DataSource = data;
                gridCompleted.DataBind();

                command.Dispose();
                connection.Dispose();
                connection.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}