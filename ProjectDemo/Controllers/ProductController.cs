﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using ProjectDemo.Models;
using System.IO;



namespace ProjectDemo.Controllers
{
    public class ProductController : Controller
    {
        string connectionString = @"data source=DESKTOP-7R1I2HK; initial catalog=NEWTEMPDB; integrated security=True; MultipleActiveResultSets=True";
        //
        // GET: /Product/
        [HttpGet]
        public ActionResult Index()
        {
            DataTable dtblOrder = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM [NEWTEMPDB].[dbo].[Product]", sqlCon);
                sqlDa.Fill(dtblOrder);
            }
            return View(dtblOrder);
        }

        //
        // GET: /Product/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Product/Create

        [HttpGet]
        public ActionResult Create()
        {
            return View(new ProductModel());
        }

        //
        // POST: /Order/Create

        [HttpPost]
        public ActionResult Create(ProductModel productModel)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();


                    string query = "INSERT INTO [NEWTEMPDB].[dbo].[Product] VALUES(@ProductName,@Unit,@Rate,@Description,@ProductImage)";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);

                    string fileName = Path.GetFileNameWithoutExtension(productModel.ImageFile.FileName);
                    string extension = Path.GetExtension(productModel.ImageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    productModel.ProductImage = "~/Image/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                    productModel.ImageFile.SaveAs(fileName);




                    sqlCmd.Parameters.AddWithValue("@ProductName", productModel.ProductName);
                    sqlCmd.Parameters.AddWithValue("@ProductImage", productModel.ProductImage);
                    sqlCmd.Parameters.AddWithValue("@Rate", productModel.Rate);
                    sqlCmd.Parameters.AddWithValue("@Description", productModel.Description);
                    sqlCmd.Parameters.AddWithValue("@Unit", productModel.Unit);
                    sqlCmd.ExecuteNonQuery();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        //
        // GET: /Product/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ProductModel productModel = new ProductModel();
            DataTable dtblOrder = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = " SELECT * FROM [NEWTEMPDB].[dbo].[Product] Where ProductCode = " + id + "";
                SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
                sqlDa.SelectCommand.Parameters.AddWithValue("@ProductCode ", id);
                sqlDa.Fill(dtblOrder);
            }
            if (dtblOrder.Rows.Count == 1)
            {
                productModel.ProductName = dtblOrder.Rows[0][1].ToString();
                productModel.Unit = Convert.ToInt32(dtblOrder.Rows[0][2].ToString());
                productModel.Rate = Convert.ToInt32(dtblOrder.Rows[0][3].ToString());
                productModel.Description = Convert.ToInt32(dtblOrder.Rows[0][4].ToString());
                productModel.ProductImage = dtblOrder.Rows[0][5].ToString();
                return View(productModel);
            }
            else
                return RedirectToAction("Index");
        }

        //
        // POST: /Product/Edit/5

        [HttpPost]
        public ActionResult Edit(ProductModel productModel, int id, HttpPostedFileBase ImageFile)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    string fileName = Path.GetFileNameWithoutExtension(productModel.ImageFile.FileName);
                    string extension = Path.GetExtension(productModel.ImageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    productModel.ProductImage = "~/Image/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                    productModel.ImageFile.SaveAs(fileName);


                    sqlCon.Open();
                    string query = "UPDATE [NEWTEMPDB].[dbo].[Product] SET ProductName= @ProductName , Unit = @Unit , Rate=@Rate , Description = @Description, ProductImage=@ProductImage WHERE ProductCode = @ProductCode";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@ProductCode", id);
                    sqlCmd.Parameters.AddWithValue("@ProductName", productModel.ProductName);
                    sqlCmd.Parameters.AddWithValue("@Unit", productModel.Unit);
                    sqlCmd.Parameters.AddWithValue("@Rate", productModel.Rate);
                    sqlCmd.Parameters.AddWithValue("@Description", productModel.Description);
                    sqlCmd.Parameters.AddWithValue("@ProductImage", productModel.ProductImage);
                    sqlCmd.ExecuteNonQuery();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        //
        // GET: /Product/Delete/5

        public ActionResult Delete(int id)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "DELETE FROM [NEWTEMPDB].[dbo].[Product] Where ProductCode = @ProductCode";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@ProductCode", id);
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

        [HttpGet]
        public ActionResult ViewProduct(int id,ProductModel productModel)
        {
            try
            {
                DataTable dtblOrder = new DataTable();
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = " SELECT * FROM [NEWTEMPDB].[dbo].[Product] Where ProductCode = " + id + "";
                    SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
                    sqlDa.SelectCommand.Parameters.AddWithValue("@ProductCode ", id);
                    sqlDa.Fill(dtblOrder);
                }
                if (dtblOrder.Rows.Count == 1)
                {
                    productModel.ProductName = dtblOrder.Rows[0][1].ToString();
                    productModel.Unit = Convert.ToInt32(dtblOrder.Rows[0][2].ToString());
                    productModel.Rate = Convert.ToInt32(dtblOrder.Rows[0][3].ToString());
                    productModel.Description = Convert.ToInt32(dtblOrder.Rows[0][4].ToString());
                    productModel.ProductImage = dtblOrder.Rows[0][5].ToString();
                    string pathA = Server.MapPath(productModel.ProductImage);
                    byte[] imageByteData = System.IO.File.ReadAllBytes(pathA);
                    string imageBase64Data = Convert.ToBase64String(imageByteData);
                    string imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
                    ViewBag.ImageData = imageDataURL;


                    return View(productModel);
                }
                else
                    return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }
    }
}
