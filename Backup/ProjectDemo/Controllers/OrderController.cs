using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using ProjectDemo.Models;



namespace ProjectDemo.Controllers
{
    public class OrderController : Controller
    {
        string connectionString = @"data source=DESKTOP-7R1I2HK; initial catalog=NEWTEMPDB; integrated security=True; MultipleActiveResultSets=True";
        //
        // GET: /Order/
        [HttpGet]
        public ActionResult Index()
        {
            DataTable dtblOrder = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM [NEWTEMPDB].[dbo].[Order]", sqlCon);
                sqlDa.Fill(dtblOrder);
            }
            return View(dtblOrder);
        }

        //
        // GET: /Order/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Order/Create

        [HttpGet]
        public ActionResult Create()
        {
            return View(new OrderModel());
        }

        //
        // POST: /Order/Create

        [HttpPost]
        public ActionResult Create(OrderModel orderModel)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "INSERT INTO [NEWTEMPDB].[dbo].[Order] VALUES(@OrderDate,@CustomerID,@TotalQty,@TotalAmount)";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@OrderID", orderModel.OrderID);
                    sqlCmd.Parameters.AddWithValue("@OrderDate", orderModel.OrderDate);
                    sqlCmd.Parameters.AddWithValue("@CustomerID", orderModel.CustomerID);
                    sqlCmd.Parameters.AddWithValue("@TotalQty", orderModel.TotalQty);
                    sqlCmd.Parameters.AddWithValue("@TotalAmount", orderModel.TotalAmount);
                    sqlCmd.ExecuteNonQuery();
                }
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        //
        // GET: /Order/Edit/5

        public ActionResult Edit(int id)
        {
            OrderModel orderModel = new OrderModel();
            DataTable dtblOrder = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = " SELECT * FROM [NEWTEMPDB].[dbo].[Order] Where OrderID = " + id + "";
                SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
                sqlDa.SelectCommand.Parameters.AddWithValue("@OrderID ", id);
                sqlDa.Fill(dtblOrder);
            }
            if (dtblOrder.Rows.Count == 1)
            {
                orderModel.OrderDate = dtblOrder.Rows[0][1].ToString();
                orderModel.CustomerID = Convert.ToInt32(dtblOrder.Rows[0][0].ToString());
                orderModel.TotalQty = Convert.ToInt32(dtblOrder.Rows[0][2].ToString());
                orderModel.TotalAmount = Convert.ToInt32(dtblOrder.Rows[0][3].ToString());
                return View(orderModel);
            }
            else
                return RedirectToAction("Index");
        }

        //
        // POST: /Order/Edit/5

        [HttpPost]
        public ActionResult Edit(OrderModel orderModel)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "UPDATE [NEWTEMPDB].[dbo].[Order] SET OrderDate= @OrderDate , CustomerID = @CustomerID , TotalQty=@TotalQty , TotalAmount=@TotalAmount Where OrderID = @OrderID";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@OrderID", orderModel.OrderID);
                    sqlCmd.Parameters.AddWithValue("@OrderDate", orderModel.OrderDate);
                    sqlCmd.Parameters.AddWithValue("@CustomerID", orderModel.CustomerID);
                    sqlCmd.Parameters.AddWithValue("@TotalQty", orderModel.TotalQty);
                    sqlCmd.Parameters.AddWithValue("@TotalAmount", orderModel.TotalAmount);
                    sqlCmd.ExecuteNonQuery();
                }
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        //
        // GET: /Order/Delete/5

        public ActionResult Delete(int id)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "DELETE FROM [NEWTEMPDB].[dbo].[Order] Where OrderID = @OrderID";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@OrderID", id);
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        //
        // POST: /Order/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
     
    }
}
