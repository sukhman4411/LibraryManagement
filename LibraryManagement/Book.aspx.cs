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
    public partial class Book : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Book_Table();
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            BookTable auth = new BookTable
            {
                BookName = txtBookName.Text,
            };
            BookBussiness.SaveBooks(auth);
            Book_Table();
        }

        protected void Reset_Click(object sender, EventArgs e)
        {
            Response.Redirect("Book.aspx");
        }

        private void Book_Table()
        {
            BookBussiness BookBiz = new BookBussiness();
            List<BookTable> auth = BookBiz.GetBooks();
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