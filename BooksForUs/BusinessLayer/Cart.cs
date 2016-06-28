using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

using BooksForAll.DataLayer;

namespace BooksForAll.BusinessLayer
{
    public class Cart
    {
        public string GenreName;
        public int GenreID;

        public string TitleName;
        public string TitleImage;
        public string TitleDescription;
        public string TitlePrice;
        //public string TitleGenre;

        public string CustomerName;
        public string CustomerEmailID;
        public string CustomerZipcode;
        public string CustomerPhone;
        public string CustomerAddress;
        public string OrderList;
        public string PaymentMethod;
        public string TitleList;

        public int CustomerID;
        public int TitleID;
        public int TotalTitles;

        public string OrderStatus;
        public string OrderNo;

        public int Quantity;
        public int TotalPrice;
        public int StockType;
        public int Flag;


        public void AddNewGenre()
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = DataLayer.DataAccess.AddParameter("@GenreName", GenreName, System.Data.SqlDbType.VarChar, 200);
            DataTable dt = DataLayer.DataAccess.ExecuteDTByProcedure("SP_AddNewGenre", parameters);
        }

        public void AddNewTitle()
        {
            SqlParameter[] parameters = new SqlParameter[6];
            parameters[0] = DataLayer.DataAccess.AddParameter("@TitleName", TitleName, System.Data.SqlDbType.VarChar, 300);
            parameters[1] = DataLayer.DataAccess.AddParameter("@TitleDescription", TitleDescription, System.Data.SqlDbType.VarChar, 1000);
            parameters[2] = DataLayer.DataAccess.AddParameter("@TitlePrice", TitlePrice, System.Data.SqlDbType.Int, 100);
            parameters[3] = DataLayer.DataAccess.AddParameter("@GenreID", GenreID, System.Data.SqlDbType.Int, 100);
            parameters[4] = DataLayer.DataAccess.AddParameter("@TitleImage", TitleImage, System.Data.SqlDbType.VarChar, 500);
            parameters[5] = DataLayer.DataAccess.AddParameter("@Quantity", Quantity, System.Data.SqlDbType.Int, 100);

            DataTable dt = DataLayer.DataAccess.ExecuteDTByProcedure("SP_AddNewTitle", parameters);
        }

        public DataTable GetAllTitles()
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = DataLayer.DataAccess.AddParameter("@GenreID", GenreID, System.Data.SqlDbType.Int, 20);
            DataTable dt = DataLayer.DataAccess.ExecuteDTByProcedure("SP_GetAllTitles", parameters);
            return dt;
        }

        public DataTable GetSortedTitlesASC()
        {
            SqlParameter[] parameters = new SqlParameter[0];
            DataTable dt = DataLayer.DataAccess.ExecuteDTByProcedure("SP_GetSortedTitlesASC",parameters);
            return dt;
        }

        public DataTable GetSortedTitlesDESC()
        {
            SqlParameter[] parameters = new SqlParameter[0];
            DataTable dt = DataLayer.DataAccess.ExecuteDTByProcedure("SP_GetSortedTitlesDESC", parameters);
            return dt;
        }

        public DataTable GetGenres()
        {
            SqlParameter[] parameters = new SqlParameter[0];
            DataTable dt = DataLayer.DataAccess.ExecuteDTByProcedure("SP_GetAllGenres", parameters);
            return dt;

        }

        internal void SaveCustomerTitles()
        {
            SqlParameter[] parameters = new SqlParameter[3];

            parameters[0] = DataLayer.DataAccess.AddParameter("@CustomerID", CustomerID, System.Data.SqlDbType.Int, 20);
            parameters[1] = DataLayer.DataAccess.AddParameter("@TitleID", TitleID, System.Data.SqlDbType.Int, 20);
            parameters[2] = DataLayer.DataAccess.AddParameter("@TotalTitles", TotalTitles, System.Data.SqlDbType.Int, 10);

            DataTable dt = DataLayer.DataAccess.ExecuteDTByProcedure("SP_SaveCustomerTitles", parameters);

        }

        internal DataTable GetTransactionDetails()
        {
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = DataLayer.DataAccess.AddParameter("@CustomerName", CustomerName, System.Data.SqlDbType.VarChar, 100);
            parameters[1] = DataLayer.DataAccess.AddParameter("@CustomerZipcode", CustomerZipcode, System.Data.SqlDbType.Int, 10);
            DataTable dt = DataLayer.DataAccess.ExecuteDTByProcedure("SP_GetTransactionDetails", parameters);
            return dt;
        }

        internal DataTable GetOrdersList()
        {
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = DataLayer.DataAccess.AddParameter("@CustomerName", CustomerName, System.Data.SqlDbType.VarChar, 100);
            parameters[1] = DataLayer.DataAccess.AddParameter("@CustomerZipcode", CustomerZipcode, System.Data.SqlDbType.Int, 20);
            DataTable dt = DataLayer.DataAccess.ExecuteDTByProcedure("SP_GetOrdersList", parameters);
            return dt;
        }

        internal DataTable SaveCustomerInfo()
        {
            SqlParameter[] parameters = new SqlParameter[5];
            parameters[0] = DataLayer.DataAccess.AddParameter("@CustomerName", CustomerName, System.Data.SqlDbType.VarChar, 100);
            parameters[1] = DataLayer.DataAccess.AddParameter("@CustomerEmailID", CustomerEmailID, System.Data.SqlDbType.VarChar, 100);
            parameters[2] = DataLayer.DataAccess.AddParameter("@CustomerZipcode", CustomerZipcode, System.Data.SqlDbType.Int, 10);
            parameters[3] = DataLayer.DataAccess.AddParameter("@TotalTitles", TotalTitles, System.Data.SqlDbType.Int, 1000);
            parameters[4] = DataLayer.DataAccess.AddParameter("@TotalPrice", TotalPrice, System.Data.SqlDbType.Int, 1000);


            DataTable dt = DataLayer.DataAccess.ExecuteDTByProcedure("SP_SaveCustomerInfo", parameters);

            return dt;
        }



    }
}