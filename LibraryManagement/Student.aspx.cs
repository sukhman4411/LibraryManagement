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
    public partial class Student : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AuthorList();
                BookList();
                StudentTable();
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

        protected void Submit_Click(object sender, EventArgs e)
        {
            StudentTable student = new StudentTable
            {
                Name = txtName.Text,
                FatherName = txtFatherName.Text,
                Mobile = txtMobile.Text,
                Email = txtEmail.Text,
                AuthorID = Convert.ToInt32(ddl_Author.SelectedValue),
                BookID = Convert.ToInt32(ddl_Book.SelectedValue),
            };
            StudentBussiness.SaveStudents(student);
            StudentTable();
        }

        protected void Reset_Click(object sender, EventArgs e)
        {
            Response.Redirect("Student.aspx");
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