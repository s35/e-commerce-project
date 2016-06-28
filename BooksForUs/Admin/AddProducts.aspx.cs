using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

using BooksForAll.BusinessLayer;

namespace BooksForUs.Admin
{
    public partial class AddProducts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAllGenres();

                //AddSubmitEvent();

                //if (Request.QueryString["alert"] == "success")
                {
                  //  Response.Write("<script>alert('Recored Saved Successfully.');</script>");
                }
            }
        }

        /*
        private void AddSubmitEvent()
        {
            UpdatePanel updatePanel = Page.Master.FindControl("UpdatePanel1") as UpdatePanel;
            UpdatePanelControlTrigger trigger = new PostBackTrigger();
            trigger.ControlID = add_Button.UniqueID;

            updatePanel.Triggers.Add(trigger);
        }
        */

        private void GetAllGenres()
        {
            Cart k = new Cart();
            DataTable dt = k.GetGenres();

            if (dt.Rows.Count > 0)
            {
                ddlGenre.DataValueField = "GenreID";
                ddlGenre.DataTextField = "GenreName";
                ddlGenre.DataSource = dt;
                ddlGenre.DataBind();
            }
        }

        protected void AddTitleButton_Click(object sender, EventArgs e)
        {
            if (uploadPhoto.PostedFile != null)
            {
                savePhoto();

                Cart k = new Cart()
                {
                    TitleName = TitleTextBox.Text,
                    TitleImage = "TitleImages/" + uploadPhoto.FileName,
                    TitlePrice = PriceTextBox3.Text,
                    TitleDescription = DescripTextBox.Text,
                    GenreID = Convert.ToInt32(ddlGenre.SelectedValue),
                    Quantity = Convert.ToInt32(QuantityBox.Text)
                };
                k.AddNewTitle();
                ClearText();
                Response.Redirect("~/Admin/AddProducts.aspx?alert=success");
            }
            else
            {
                //error
                Response.Redirect("<script>alert('Please Upload Photo');</script>");
            }
        }

        private void ClearText()
        {
            TitleTextBox.Text = string.Empty;
            PriceTextBox3.Text = string.Empty;
            DescripTextBox.Text = string.Empty;
            QuantityBox.Text = string.Empty;

        }

        private void savePhoto()
        {
            if (uploadPhoto.PostedFile != null)
            {
                string filename = uploadPhoto.PostedFile.FileName.ToString();
                string fileExt = System.IO.Path.GetExtension(uploadPhoto.FileName);

                if (filename.Length > 96)
                {
                    //too long
                }

                else if (fileExt != ".jpg" && fileExt != ".jpeg" && fileExt != ".png")
                {
                    // file type not supported
                }

                else if (uploadPhoto.PostedFile.ContentLength > 4000000)
                {
                    // Larger than 4 MB not allowed
                }

                else
                {
                    uploadPhoto.SaveAs(Server.MapPath("~/TitleImages/" + filename));
                }

            }
        }


    }
}