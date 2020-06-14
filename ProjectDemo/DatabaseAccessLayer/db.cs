using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using ProjectDemo.Models;

namespace ProjectDemo.DatabaseAccessLayer
{
    public class db
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

        public void addRecord(Orders ord)
        {
            SqlCommand com = new SqlCommand("sp_Order_Add",con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@OrderDate",ord.OrderDate);
            com.Parameters.AddWithValue("@CustomerID",ord.CustomerID);
            com.Parameters.AddWithValue("@TotalQty",ord.TotalQty);
            com.Parameters.AddWithValue("@TotalAmount",ord.TotalAmount);
            con.Open();
            com.ExecuteNonQuery();
            con.Open();
        }


        public void updateRecord(Orders ord)
        {
            SqlCommand com = new SqlCommand("sp_Order_Update", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@OrderDate", ord.OrderDate);
            com.Parameters.AddWithValue("@CustomerID", ord.CustomerID);
            com.Parameters.AddWithValue("@TotalQty", ord.TotalQty);
            com.Parameters.AddWithValue("@TotalAmount", ord.TotalAmount);
            con.Open();
            com.ExecuteNonQuery();
            con.Open();
        }


        public DataSet showRecordByID(int id)
        {
            SqlCommand com = new SqlCommand("sp_Order_id", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@OrderID",id);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }


        public void delete_record(int id)
        {
            SqlCommand com = new SqlCommand("sp_Order_Delete", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@OrderID", id);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();


        }


        public DataSet showOrderAll()
        {
            SqlCommand com = new SqlCommand("sp_Order_all", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }



    }
}