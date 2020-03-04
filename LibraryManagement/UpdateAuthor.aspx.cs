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
    public partial class UpdateAuthor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillAuthors();
                Author_Table();
            }
        }

        private void FillAuthors()
        {
            AuthorBussiness authorBiz = new AuthorBussiness();
            List<AuthorTable> Obj_Author_ID = authorBiz.GetAuthorData();

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

        protected void Submit_Click(object sender, EventArgs e)
        {
            AuthorTable auth = new AuthorTable
            {
                ID = Convert.ToInt32(ddl_Author.SelectedValue),
                AuthorName = txtAuthorName.Text,

            };
            AuthorBussiness.UpdateAuthor(auth);
            Author_Table();
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            AuthorBussiness.DeleteAuthor(ddl_Author.SelectedValue);
            Author_Table();
        }
        private void Author_Table()
        {
            AuthorBussiness authorBiz = new AuthorBussiness();
            List<AuthorTable> auth = authorBiz.GetAuthorData();
            if (auth != null && auth.Count > 0)
            {
                grd.DataSource = auth;
                grd.DataSource = auth;
                grd.DataBind();
            }
            else
            {
                grd.DataSource = null;
                grd.DataBind();
            }
        }


        protected void ddl_Author_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<AuthorTable> authorTables = AuthorBussiness.GetAuthorDetails(ddl_Author.SelectedValue);
            if (authorTables != null && authorTables.Count > 0)
            {
                for (int i = 0; i < authorTables.Count; i++)
                {
                    txtAuthorName.Text = authorTables[i].AuthorName;
                }
            }
        }
    }
}