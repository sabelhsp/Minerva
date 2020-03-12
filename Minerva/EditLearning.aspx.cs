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
    public partial class AddLearning : System.Web.UI.Page
    {
        static DateTime todayDate = DateTime.Now;
        static DateTime dueDate = todayDate.AddDays(30);
        int[] userList;
        int[] courseList;
        int operatorId;
        int userID;
        int courseID;
        private List<int> userIDList = new List<int>();
        private List<int> courseIDList = new List<int>();
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

            FillListCourses();
            FillListUsers();
        }

        private void FillListCourses()
        {
            string cmdText = "Select CourseId, CourseName FROM LearningCourse";
            SqlConnection cnn;
            SqlCommand cmd;
            SqlDataAdapter adapter = new SqlDataAdapter();

            cnn = new SqlConnection(@"server=LAPTOP-LKVILIHC\MSSQLSERVER01;Trusted_Connection=True;database=Minerva");
            cnn.Open();
            cmd = new SqlCommand(cmdText, cnn);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {
                listCourses.Items.Add(Convert.ToString(dr["CourseName"]));
                courseIDList.Add(Convert.ToInt32(dr["CourseId"]));
            }
            cmd.Dispose();
            cnn.Dispose();
            cnn.Close();
        }

        private void FillListUsers()
        {
            string cmdText = "Select UserId, FirstName, LastName FROM UserInfo Where AdminId = "+operatorId;
            SqlConnection cnn;
            SqlCommand cmd;
            SqlDataAdapter adapter = new SqlDataAdapter();
            cnn = new SqlConnection(@"server=LAPTOP-LKVILIHC\MSSQLSERVER01;Trusted_Connection=True;database=Minerva");
            cnn.Open();
            cmd = new SqlCommand(cmdText, cnn);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {
                listUsers.Items.Add(Convert.ToString(dr["FirstName"] + " " + Convert.ToString(dr["LastName"])));
                userIDList.Add(Convert.ToInt32(dr["UserId"]));
            }
            cmd.Dispose();
            cnn.Dispose();
            cnn.Close();
        }

        protected void btnAddCourses_Click(object sender, EventArgs e)
        {
            userList = listUsers.GetSelectedIndices();
            courseList = listCourses.GetSelectedIndices();
            addCoursesForUser(userList, courseList);
            listCourses.Items.Clear();
            listUsers.Items.Clear();
            FillListCourses();
            FillListUsers();
        }

        private void addCoursesForUser(int[] users, int[] courses)
        {
            for (int i = 0; i < users.Length; i++)
            {
                userID = userIDList[users[i]];
                for (int j = 0; j < courses.Length; j++)
                {
                    courseID = courseIDList[courses[j]];

                    string cmdText = "INSERT INTO LearningAssignment(UserId, CourseId, AdminId, DateAssigned, DateDue, Completed)" +
                    "Values("+userID+", "+courseID+", "+operatorId+", '"+todayDate+"', '"+dueDate+"', 0)";
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
                    testTxt.Text = "Courses added to Users successfully.";
                }
            }
        }
    }
}