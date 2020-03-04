using LibraryManagement.BussinessLayer;
using LibraryManagement.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagement
{
    public partial class UpdateStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                StudentTable();
                StudentList();
                AuthorList();
                BookList();
            }
        }
        private void StudentList()
        {
            StudentBussiness Obj_Teach = new StudentBussiness();
            List<StudentTable> Obj_Student_ID = Obj_Teach.GetStudents();

            if (Obj_Student_ID != null && Obj_Student_ID.Count > 0)
            {
                for (int i = 0; i < Obj_Student_ID.Count; i++)
                {
                    ddl_Student.Items.Add(Obj_Student_ID[i].ID.ToString());
                }
                ddl_Student.Items.Insert(0, new ListItem("Select Student", " "));
            }
            else
            {
                ddl_Student.Items.Clear();
            }
        }
        private void AuthorList()
        {
            AuthorBussiness Obj_Teach = new AuthorBussiness();
            List<AuthorTable> Obj_Author_ID = Obj_Teach.GetAuthorData();

            if (Obj_Author_ID != null && Obj_Author_ID.Count > 0)
            {
                for (int i = 0; i < Obj_Author_ID.Count; i++)
                {
                    ddl_Author.Items.Add(Obj_Author_ID[i].ID.ToString());
                }
                ddl_Author.Items.Insert(0, new ListItem("Select Author", " "));
            }
            else
            {
                ddl_Author.Items.Clear();
            }
        }
        private void BookList()
        {
            BookBussiness Obj_Teach = new BookBussiness();
            List<BookTable> Obj_Book_ID = Obj_Teach.GetBooks();

            if (Obj_Book_ID != null && Obj_Book_ID.Count > 0)
            {
                for (int i = 0; i < Obj_Book_ID.Count; i++)
                {
                    ddl_Book.Items.Add(Obj_Book_ID[i].ID.ToString());
                }
                ddl_Book.Items.Insert(0, new ListItem("Select Book", " "));
            }
            else
            {
                ddl_Book.Items.Clear();
            }
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            StudentBussiness.DeleteStudent(ddl_Student.SelectedValue);
            StudentTable();
        }

        protected void ddl_Student_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<StudentTable> Obj_Student = StudentBussiness.GetStudentDetails(ddl_Student.SelectedValue);
            if (Obj_Student != null && Obj_Student.Count > 0)
            {
                for (int i = 0; i < Obj_Student.Count; i++)
                {
                    txtName.Text = Obj_Student[i].Name;
                    txtFatherName.Text = Obj_Student[i].FatherName;
                    txtMobile.Text = Obj_Student[i].Mobile;
                    txtEmail.Text = Obj_Student[i].Email;
                    ddl_Author.SelectedValue = Convert.ToString(Obj_Student[i].AuthorID);
                    ddl_Book.SelectedValue = Convert.ToString(Obj_Student[i].BookID);
                }
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            StudentTable auth = new StudentTable
            {
                ID = Convert.ToInt32(ddl_Student.SelectedValue),
                Name = txtName.Text,
                FatherName = txtFatherName.Text,
                Mobile = txtMobile.Text,
                Email = txtEmail.Text,
                AuthorID = Convert.ToInt32(ddl_Author.SelectedValue),
                BookID = Convert.ToInt32(ddl_Book.SelectedValue),

            };
            StudentBussiness.UpdateStudent(auth);
            StudentTable();
        }

        private void StudentTable()
        {
            StudentBussiness Obj_Student = new StudentBussiness();
            List<StudentTable> Obj_St = Obj_Student.GetStudents();
            if (Obj_St != null && Obj_St.Count > 0)
            {
                grd.DataSource = Obj_St;
                grd.DataBind();
            }
            else
            {
                grd.DataSource = null;
                grd.DataBind();
            }
        }
    }
}