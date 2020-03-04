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
    public partial class Author : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Author_Table();
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            AuthorTable auth = new AuthorTable
            {
                AuthorName = txtAuthorName.Text,
            };
            AuthorBussiness.InsertAuthor(auth);
            Author_Table();
        }

        protected void Reset_Click(object sender, EventArgs e)
        {
            Response.Redirect("Author.aspx");
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
    }
}