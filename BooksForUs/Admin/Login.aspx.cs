using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Collections.Specialized;

namespace BooksForUs.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label2.Visible = false;
            TextBox1.Focus();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string loginID = WebConfigurationManager.AppSettings["AdminLoginID"];
            string passWord = WebConfigurationManager.AppSettings["AdminPassword"];

            if (TextBox1.Text == loginID && TextBox2.Text == passWord)
            {
                Label2.Text = TextBox1.Text + TextBox2.Text;
                Session["BooksforAllAdmin"] = "BookforAllAdmin";
                Response.Redirect("~/admin/AddProducts.aspx");
            }
            else
            {
                Label2.Visible = true;
                Label2.Text = "Incorrect Login/Password";
            }

        } 

    }
}