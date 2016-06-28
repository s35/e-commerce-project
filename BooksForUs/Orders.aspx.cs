using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

using BooksForAll.BusinessLayer;

namespace BooksForAll
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                NotFoundPnl.Visible = false;
                OrderQueryResults.Visible = false;
            }
        }

        protected void SearchOrdersBtn_Click(object sender, EventArgs e)
        {
            NotFoundPnl.Visible = false;
            OrderQueryResults.Visible = false;
            ShowOrderDetails();
        }

        private void ShowOrderDetails()
        {
            

            if (ValidateUserInfo(NameSearch.Text, Convert.ToInt32(ZipcodeSearch.Text)))
            {
                OrderQueryResults.Visible = true;
                Cart k = new Cart
                {
                    CustomerName = NameSearch.Text,
                    CustomerZipcode = ZipcodeSearch.Text
                };

                DataTable dtCustomerDetails = k.GetOrdersList();

                OrderDetailsdl.DataSource = k.GetOrdersList();
                OrderDetailsdl.DataBind();

                // Binding Order Details Above ^

                // Binding Title Specific Details Below v

                GetTransactionDetails1();

            }
            else
            {
                NotFoundPnl.Visible = true;
                //Your Order not found! Sorry
            }
        }

        private void GetTransactionDetails1()
        {
            Cart k = new Cart()
            {
                CustomerName = NameSearch.Text,
                CustomerZipcode = ZipcodeSearch.Text
            };

            dlTitles.DataSource = k.GetTransactionDetails();
            dlTitles.DataBind();
        }

        private bool ValidateUserInfo(string CustomerName, int CustomerZipcode)
        {
            Cart k = new Cart
            {
                CustomerName = NameSearch.Text,
                CustomerZipcode = ZipcodeSearch.Text
            };

            DataTable dtCustomerDetails = k.GetOrdersList();

            if (dtCustomerDetails.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}