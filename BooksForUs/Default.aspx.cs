using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;

using BooksForAll.BusinessLayer;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;

namespace BooksForAll
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetGenre();
                GetTitles(0);
                //HighlightTitle();
            }
        }

        private void GetGenre()
        {
            Cart k = new Cart();
            DataList1.DataSource = null;
            DataList1.DataSource = k.GetGenres();
            DataList1.DataBind();
        }

        private void GetTitles(int GenreID)
        {
            Cart k = new Cart()
            {
                GenreID = GenreID
            };

            titleDataList.DataSource = null;
            titleDataList.DataSource = k.GetAllTitles();
            titleDataList.DataBind();
        }

        protected void Genre_Click(object sender, EventArgs e)
        {
            emptycart.Visible = false;
            int GenreID = Convert.ToInt16((((LinkButton)sender).CommandArgument));
            GetTitles(GenreID);
            HighlightTitle();
        }

        protected void AddToCart_Clicked(object sender, EventArgs e)
        {
            string TitleID = Convert.ToInt16((((Button)sender).CommandArgument)).ToString();
            string TitleQuantity = "1";

            DataListItem currentTitle = (sender as Button).NamingContainer as DataListItem;
            Label availableStock = currentTitle.FindControl("lblavstock") as Label;

            if (Session["MyCart"] != null)
            {
                DataTable dt = (DataTable)Session["MyCart"];
                var checkTitle = dt.AsEnumerable().Where(r => r.Field<string>("TitleID") == TitleID);

                if (checkTitle.Count() == 0)
                {
                    string query = "select * from Titles where TitleID = " + TitleID + "";
                    DataTable dtTitles = GetData(query);

                    DataRow dr = dt.NewRow();
                    dr["TitleID"] = TitleID;
                    dr["Title"] = Convert.ToString(dtTitles.Rows[0]["Title"]);
                    dr["Description"] = Convert.ToString(dtTitles.Rows[0]["Description"]);
                    dr["Price"] = Convert.ToString(dtTitles.Rows[0]["Price"]);
                    dr["ImageURL"] = Convert.ToString(dtTitles.Rows[0]["ImageURL"]);
                    dr["Quantity"] = TitleQuantity;

                    dt.Rows.Add(dr);

                    Session["MyCart"] = dt;
                    CartButton.Text = "Cart" + " [ " + dt.Rows.Count.ToString() + " ]";
                }
            }

            else
            {

                string query = "select * from Titles where TitleID = " + TitleID + "";
                DataTable dtTitles = GetData(query);

                DataTable dt = new DataTable();

                dt.Columns.Add("TitleID", typeof(string));
                dt.Columns.Add("Title", typeof(string));
                dt.Columns.Add("Description", typeof(string));
                dt.Columns.Add("Price", typeof(string));
                dt.Columns.Add("ImageURL", typeof(string));
                dt.Columns.Add("Quantity", typeof(string));

                DataRow dr = dt.NewRow();

                dr["TitleID"] = TitleID;
                dr["Title"] = Convert.ToString(dtTitles.Rows[0]["Title"]);
                dr["Description"] = Convert.ToString(dtTitles.Rows[0]["Description"]);
                dr["Price"] = Convert.ToString(dtTitles.Rows[0]["Price"]);
                dr["ImageURL"] = Convert.ToString(dtTitles.Rows[0]["ImageURL"]);
                dr["Quantity"] = TitleQuantity;

                dt.Rows.Add(dr);

                Session["MyCart"] = dt;
                CartButton.Text = "Cart" + " [ " + dt.Rows.Count.ToString() + " ]";
            }

            HighlightTitle();

        }

        private void HighlightTitle()
        {
            if (Session["MyCart"] != null)
            {
                DataTable dtTitlesAddedToCart = (DataTable)Session["MyCart"];
                if (dtTitlesAddedToCart.Rows.Count > 0)
                {
                    foreach (DataListItem item in titleDataList.Items)
                    {
                        HiddenField hfTitleID = item.FindControl("hfTitleID") as HiddenField;
                        if (dtTitlesAddedToCart.AsEnumerable().Any(row => hfTitleID.Value == row.Field<String>("TitleID")))
                        {
                            Button AddToCart = item.FindControl("buyNow") as Button;
                            AddToCart.BackColor = System.Drawing.Color.Green;
                            AddToCart.Text = "Added to Cart";
                        }
                    }
                }
            }
        }

        public DataTable GetData(string query)
        {
            DataTable dt = new DataTable();
            string Conn = WebConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;
            SqlConnection conn = new SqlConnection(Conn);
            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            da.Fill(dt);

            conn.Close();
            return dt;
        }

        protected void Cart_Clicked(object sender, EventArgs e)
        {
            GetMyCart();
        }

        public void GetMyCart()
        {
            //Shopping Cart Logic

            DataTable dtTitles;

            if (Session["MyCart"] != null)
            {
                dtTitles = (DataTable)Session["MyCart"];
            }
            else
            {
                dtTitles = new DataTable();
            }

            if (dtTitles.Rows.Count > 0)
            {

                //lots more logic here

                TotalTitlesBox.Text = dtTitles.Rows.Count.ToString();
                CartButton.Text = "Cart [ " + dtTitles.Rows.Count.ToString() + " ]";
                CartDataList.DataSource = dtTitles;
                CartDataList.DataBind();
                UpdateTotalBill();

                CartPanel.Visible = true;
                CartClearButton.Visible = false;
                DataList1.Visible = false;
                OrderPlacedPanel.Visible = false;
                titleDataList.Visible = false;
                CartLabel.Visible = false;
                GenreHeading.Visible = false;
                ByPriceLabel.Visible = false;
                ByPricePanel.Visible = false;
                CheckoutPanel.Visible = true;
                emptycart.Visible = false;

            }
            else
            {
                emptycart.Visible = true;
                CartClearButton.Visible = false;
                CartPanel.Visible = false;
                DataList1.Visible = false;
                titleDataList.Visible = false;
                OrderPlacedPanel.Visible = false;
                CartLabel.Visible = false;
                GenreHeading.Visible = false;
                ByPriceLabel.Visible = false;
                ByPricePanel.Visible = false;
                CheckoutPanel.Visible = false;

                CartButton.Text = "Cart [ 0 ]";

                CartDataList.DataSource = null;
                CartDataList.DataBind();

            }


        }

        protected void BrandName_Click(object sender, EventArgs e)
        {

            DataList1.Visible = true;
            titleDataList.Visible = true;
            CartLabel.Visible = true;
            GenreHeading.Visible = true;
            ByPriceLabel.Visible = true;
            ByPricePanel.Visible = true;
            CartClearButton.Visible = true;
            CartPanel.Visible = false;
            emptycart.Visible = false;
            CheckoutPanel.Visible = false;
            ContactPanel.Visible = false;
            AboutPanel.Visible = false;

            GetTitles(0);
            HighlightTitle();
        }

        protected void TitleQuantityBox_TextChanged(object sender, EventArgs e)
        {
            TextBox QuantityBox = (sender as TextBox);

            DataListItem currentItem = (sender as TextBox).NamingContainer as DataListItem;
            HiddenField TitleID = currentItem.FindControl("hfTItleID") as HiddenField;

            if (QuantityBox.Text == string.Empty || QuantityBox.Text == "0" || QuantityBox.Text == "1")
            {
                QuantityBox.Text = "1";
            }
            else
            {
                if (Session["MyCart"] != null)
                {
                    DataTable dt = (DataTable)Session["MyCart"];
                    DataRow[] rows = dt.Select("TitleID='" + TitleID.Value + "'");
                    int index = dt.Rows.IndexOf(rows[0]);
                    dt.Rows[index]["Quantity"] = QuantityBox.Text;
                    Session["MyCart"] = dt;
                }
                else
                {
                    //Error
                }

            }

            UpdateTotalBill();
        }

        private void UpdateTotalBill()
        {

            long TotalPrice = 0;
            long TotalTitles = 0;

            foreach (DataListItem item in CartDataList.Items)
            {
                Label CartPriceLbl = item.FindControl("CartPriceLabel") as Label;
                TextBox TitleQuantityBox = item.FindControl("TitleQuantity") as TextBox;
                long TitlePrice = Convert.ToInt64(CartPriceLbl.Text) * Convert.ToInt64(TitleQuantityBox.Text);
                TotalPrice = TotalPrice + TitlePrice;
                TotalTitles = TotalTitles + Convert.ToInt32(TitleQuantityBox.Text);
            }

            TotalPriceBox.Text = Convert.ToString(TotalPrice);
            TotalTitlesBox.Text = Convert.ToString(TotalTitles);
        }

        protected void RemoveFromCart_Click(object sender, EventArgs e)
        {

            // Remove from Cart

            string TitleID = Convert.ToInt16((((Button)sender).CommandArgument)).ToString();
            if (Session["MyCart"] != null)
            {
                DataTable dt = (DataTable)Session["MyCart"];
                DataRow dRow = dt.Select("TitleID=" + TitleID + " ").FirstOrDefault();

                if (dRow != null)
                    dt.Rows.Remove(dRow);

                Session["MyCart"] = dt;

            }

            GetMyCart();

        }

        protected void PlaceOrder_Click(object sender, EventArgs e)
        {
            string TitleIds = string.Empty;
            DataTable dt;

            if (Session["MyCart"] != null)
            {
                dt = (DataTable)Session["MyCart"];

                var FullName = FirstNameBox.Text + " " + LastNameBox.Text;

                Cart k = new Cart()
                {
                    CustomerName = FirstNameBox.Text + " " + LastNameBox.Text,
                    CustomerEmailID = EmailBox.Text,
                    CustomerZipcode = ZipcodeBox.Text,
                    TotalTitles = Convert.ToInt32(TotalTitlesBox.Text),
                    TotalPrice = Convert.ToInt32(TotalPriceBox.Text),
                    TitleList = TitleIds

                };

                DataTable dtResult = k.SaveCustomerInfo();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Cart SaveTitles = new Cart()
                    {
                        CustomerID = Convert.ToInt32(dtResult.Rows[0][0]),
                        TitleID = Convert.ToInt32(dt.Rows[i]["TitleID"]),
                        TotalTitles = Convert.ToInt32(dt.Rows[i]["Quantity"])
                    };
                    SaveTitles.SaveCustomerTitles();
                }

                Session.Clear();
                GetMyCart();

                TransactionNumberLabel.Text = "Your confirmation number is :- " + dtResult.Rows[0][0];

                OrderPlacedPanel.Visible = true;
                emptycart.Visible = false;
                CartPanel.Visible = false;
                DataList1.Visible = false;
                titleDataList.Visible = false;
                CartLabel.Visible = false;
                GenreHeading.Visible = false;
                ByPriceLabel.Visible = false;
                ByPricePanel.Visible = false;
                CheckoutPanel.Visible = false;


                SendOrderEmail(FullName, EmailBox.Text, Convert.ToString(dtResult.Rows[0][0]));

                FirstNameBox.Text = string.Empty;
                LastNameBox.Text = string.Empty;
                ZipcodeBox.Text = string.Empty;
                EmailBox.Text = string.Empty;
                TotalPriceBox.Text = "0";
                TotalTitlesBox.Text = "0";

            }
        }

        protected void About_Click(object sender, EventArgs e)
        {
            AboutPanel.Visible = true;
            emptycart.Visible = false;
            CartPanel.Visible = false;
            DataList1.Visible = false;
            titleDataList.Visible = false;
            OrderPlacedPanel.Visible = false;
            CartLabel.Visible = false;
            GenreHeading.Visible = false;
            ByPriceLabel.Visible = false;
            ByPricePanel.Visible = false;
            CheckoutPanel.Visible = false;
            ContactPanel.Visible = false;
        }

        protected void Contact_Click(object sender, EventArgs e)
        {
            ContactPanel.Visible = true;
            AboutPanel.Visible = false;
            emptycart.Visible = false;
            CartPanel.Visible = false;
            DataList1.Visible = false;
            titleDataList.Visible = false;
            OrderPlacedPanel.Visible = false;
            CartLabel.Visible = false;
            GenreHeading.Visible = false;
            ByPriceLabel.Visible = false;
            ByPricePanel.Visible = false;
            CheckoutPanel.Visible = false;
        }

        protected void LowtoHigh_Click(object sender, EventArgs e)
        {
            GetTitlesASCSorted();
        }

        protected void HightoLow_Click(object sender, EventArgs e)
        {
            GetTitlesDESCSorted();
        }

        private void GetTitlesASCSorted()
        {
            Cart k = new Cart();

            titleDataList.DataSource = null;
            titleDataList.RepeatDirection = RepeatDirection.Horizontal;
            titleDataList.DataSource = k.GetSortedTitlesASC();
            titleDataList.DataBind();
        }

        private void GetTitlesDESCSorted()
        {
            Cart k = new Cart();

            titleDataList.DataSource = null;
            titleDataList.RepeatDirection = RepeatDirection.Horizontal;
            titleDataList.DataSource = k.GetSortedTitlesDESC();
            titleDataList.DataBind();
        }

        private void SendOrderEmail(string CustomerName, string CustomerEmail, string TransactionNumber)
        {
            string body = this.MakeOrderEmail(CustomerName, TransactionNumber);

            EmailSender.SendMail(CustomerEmail, "- Your Books for All Order -", body);
        }

        private string MakeOrderEmail(string CustomerName, string TransactionNumber)
        {
            string body = string.Empty;

            using (System.IO.StreamReader reader = new StreamReader(Server.MapPath("~/EmailTemplate.html")))
            {
                body = reader.ReadToEnd();
            }

            body = body.Replace("{CustomerName}", CustomerName);
            body = body.Replace("{TransactionNumber}", TransactionNumber);
            body = body.Replace("{OrdersURL}", "http://booksforall.azurewebsites.net/Orders.aspx");
            return body;
        }

        protected void ClearCart_Click(object sender, EventArgs e)
        {
            if (Session["MyCart"] != null)
            {
                DataTable dtTitlesAddedToCart = (DataTable)Session["MyCart"];
                if (dtTitlesAddedToCart.Rows.Count > 0)
                {
                    foreach (DataListItem item in titleDataList.Items)
                    {
                        HiddenField hfTitleID = item.FindControl("hfTitleID") as HiddenField;
                        if (dtTitlesAddedToCart.AsEnumerable().Any(row => hfTitleID.Value == row.Field<String>("TitleID")))
                        {
                            Button AddToCart = item.FindControl("buyNow") as Button;
                            Color bootstrapColor = ColorTranslator.FromHtml("#006dcc");
                            AddToCart.BackColor = bootstrapColor;
                            AddToCart.Text = "Add to Cart";
                        }
                    }
                }

                dtTitlesAddedToCart.Clear();
                HighlightTitle();
                CartButton.Text = "Cart [ 0 ]";
            }
        }
    }
}


