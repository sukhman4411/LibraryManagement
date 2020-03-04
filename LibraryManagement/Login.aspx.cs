using LibraryManagement.BussinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagement
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            UserModel model = new UserModel();
            Response.Cookies["UserName"].Value = txtEmail.Text.Trim();
            Response.Cookies["Password"].Value = txtPassword.Text.Trim();
            model.UserName = txtEmail.Text.Trim();
            model.Password = txtPassword.Text.Trim();
            LoginBussiness login_Business = new LoginBussiness();
            bool msg = login_Business.LoginUser(model);
            if (msg)
            {
                Response.Redirect("Author.aspx");
            }
            else
            {
                Label1.Visible = true;
                Label1.Text = "Login ID and Password is invalid.";
            }
        }
    }
}