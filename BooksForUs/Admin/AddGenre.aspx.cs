using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BooksForAll.BusinessLayer;

namespace BooksForUs.Admin
{
    public partial class AddGenre : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddGenreButton_Click(object sender, EventArgs e)
        {
            Cart k = new Cart
            {
                GenreName = genrebox.Text
            };
            k.AddNewGenre();
            genrebox.Text = string.Empty;
            Response.Redirect("~/admin/AddProducts.aspx");
        }
    }
}