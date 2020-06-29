using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using ProjectDemo.Models;
using System.Configuration;
using System.IO;
using System.Data.OleDb;
using System.Web.Script.Serialization;
using System.Web.Services;
using CascadingComboBox1.Models;


namespace ProjectDemo.Controllers
{
    public class SubformController : Controller
    {
        //static string ApathX = System.Web.HttpContext.Current.Request.Url.AbsolutePath.ToString();
        //string OrderId = ApathX.Substring(25);
        string OrderId = "";
        string connectionString = @"data source=DESKTOP-7R1I2HK; initial catalog=NEWTEMPDB; integrated security=True; MultipleActiveResultSets=True";


        //
        // GET: /Subform/


        [HttpGet]
        public ActionResult Index()
        {
            DataTable dtblSubform = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM [NEWTEMPDB].[dbo].[Subform]", sqlCon);
                ///trial code 
                //SqlDataAdapter sqlDaa = new SqlDataAdapter("SELECT [ProductCode] FROM [NEWTEMPDB].[dbo].[Product]", sqlCon);
                //sqlDaa.Fill(dtblSubform);
                //List<int> ProductCodeList = new List<int>();
                //foreach (DataRow dr in dtblSubform.Rows)
                //{
                //    int item1 = dr.Field<int>("ProductCode");

                //    ProductCodeList.Add(item1);
                //    ProductCodeList = ProductCodeList.ToList();
                //    SelectList list = new SelectList(ProductCodeList, "", "");
                //    ViewBag.ProductCodeList = list;
                //}
                /////trial code end
                sqlDa.Fill(dtblSubform);
                //DataRow[] drA = new DataRow[dtblSubform.Rows.Count];
                ////dtblSubform.Rows.CopyTo(drA, 0);
                //var b = drA[1][1];SubformGridview
            }
            return View(dtblSubform);
        }


        //
        // GET: /Subform/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Subform/Create

        public ActionResult Create()
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                DataTable dtblSubform = new DataTable();
                SqlDataAdapter sqlDaa = new SqlDataAdapter("SELECT [ProductCode] FROM [NEWTEMPDB].[dbo].[Product]", sqlCon);
                sqlDaa.Fill(dtblSubform);
                List<int> ProductCodeList = new List<int>();
                foreach (DataRow dr in dtblSubform.Rows)
                {
                    int item1 = dr.Field<int>("ProductCode");
                    ProductCodeList.Add(item1);
                    SelectList list = new SelectList(ProductCodeList, "", "");
                    ViewBag.ProductCodeList = list;
                }
                //viewbag code end

            }
            return View(new SubformModel());

            ///viewbag code start
            ///

        }

        //
        // POST: /Subform/Create

        [HttpPost]
        public ActionResult Create(SubformModel subformModel)
        {
            string aOrderId = OrderId;
            aOrderId = "2";
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "INSERT INTO [NEWTEMPDB].[dbo].[Subform] VALUES(@OrderID,@ProductCode,@ProductImage,@Unit,@Rate,@Quantity,@Amount)";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);



                    ///viewbag code start
                    ///
                    DataTable dtblSubform = new DataTable();
                    SqlDataAdapter sqlDaa = new SqlDataAdapter("SELECT [ProductCode] FROM [NEWTEMPDB].[dbo].[Product]", sqlCon);
                    sqlDaa.Fill(dtblSubform);
                    List<int> ProductCodeList = new List<int>();
                    foreach (DataRow dr in dtblSubform.Rows)
                    {
                        int item1 = dr.Field<int>("ProductCode");
                        ProductCodeList.Add(item1);
                        SelectList list = new SelectList(ProductCodeList, "", "");
                        ViewBag.ProductCodeList = list;
                    }
                    //viewbag code end
                    sqlCmd.Parameters.AddWithValue("@SubformID", subformModel.SubformID);
                    sqlCmd.Parameters.AddWithValue("@OrderID", aOrderId);
                    //sqlCmd.Parameters.AddWithValue("@OrderID", subformModel.OrderID);
                    sqlCmd.Parameters.AddWithValue("@ProductCode", subformModel.ProductCode);
                    sqlCmd.Parameters.AddWithValue("@ProductImage", subformModel.ProductImage);
                    sqlCmd.Parameters.AddWithValue("@Unit", subformModel.Unit);
                    sqlCmd.Parameters.AddWithValue("@Rate", subformModel.Rate);
                    sqlCmd.Parameters.AddWithValue("@Quantity", subformModel.Quantity);
                    sqlCmd.Parameters.AddWithValue("@Amount", subformModel.Amount);
                    sqlCmd.ExecuteNonQuery();
                }
                return RedirectToAction("SubformGridview/" + OrderId);
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        //
        // GET: /Subform/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            SubformModel subformModel = new SubformModel();
            DataTable dtblSubform = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();


                //viewbag code start
                DataTable dtblProductCode = new DataTable();
                SqlDataAdapter sqlDaa = new SqlDataAdapter("SELECT [ProductCode] FROM [NEWTEMPDB].[dbo].[Product]", sqlCon);
                sqlDaa.Fill(dtblProductCode);
                List<int> ProductCodeList = new List<int>();
                foreach (DataRow dr in dtblProductCode.Rows)
                {
                    int item1 = dr.Field<int>("ProductCode");
                    ProductCodeList.Add(item1);
                    SelectList list = new SelectList(ProductCodeList, "", "");
                    ViewBag.ProductCodeList = list;
                }
                //viewbag code end

                string query = " SELECT * FROM [NEWTEMPDB].[dbo].[Subform] Where SubformID = " + id + "";
                SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
                sqlDa.SelectCommand.Parameters.AddWithValue("@SubformID ", id);
                sqlDa.Fill(dtblSubform);
            }
            if (dtblSubform.Rows.Count == 1)
            {
                subformModel.OrderID = dtblSubform.Rows[0][1].ToString();
                subformModel.ProductCode = Convert.ToInt32(dtblSubform.Rows[0][2].ToString());
                subformModel.ProductImage = Convert.ToInt32(dtblSubform.Rows[0][3].ToString());
                subformModel.Unit = Convert.ToInt32(dtblSubform.Rows[0][4].ToString());
                subformModel.Rate = Convert.ToInt32(dtblSubform.Rows[0][5].ToString());
                subformModel.Quantity = Convert.ToInt32(dtblSubform.Rows[0][6].ToString());
                subformModel.Amount = Convert.ToInt32(dtblSubform.Rows[0][7].ToString());
                return View(subformModel);
            }
            else
                return RedirectToAction("SubformGridview/" + OrderId);
        }

        //
        // POST: /Subform/Edit/5

        [HttpPost]
        public ActionResult Edit(SubformModel subformModel, int id)
        {
            OrderId = "2";
            try
            {

                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "UPDATE [NEWTEMPDB].[dbo].[Subform] SET OrderID = @OrderID,ProductCode=@ProductCode,ProductImage=@ProductImage,Unit=@Unit,Rate=@Rate,Quantity=@Quantity,Amount=@Amount Where SubformID = @SubformId";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@SubformID", id);
                    sqlCmd.Parameters.AddWithValue("@OrderID", OrderId);
                    sqlCmd.Parameters.AddWithValue("@ProductCode", subformModel.ProductCode);
                    sqlCmd.Parameters.AddWithValue("@ProductImage", subformModel.ProductImage);
                    sqlCmd.Parameters.AddWithValue("@Unit", subformModel.Unit);
                    sqlCmd.Parameters.AddWithValue("@Rate", subformModel.Rate);
                    sqlCmd.Parameters.AddWithValue("@Quantity", subformModel.Quantity);
                    sqlCmd.Parameters.AddWithValue("@Amount", subformModel.Amount);
                    sqlCmd.ExecuteNonQuery();
                }
                return RedirectToAction("SubformGridview/" + OrderId);
            }
            catch (Exception ex)
            {
                ex.ToString();
                return RedirectToAction("SubformGridview/" + OrderId);
            }
        }

        //
        // GET: /Subform/Delete/5

        public ActionResult Delete(int id)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "DELETE FROM [NEWTEMPDB].[dbo].[Subform] Where SubformID = @SubformID";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@SubformID", id);
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        //
        // POST: /Subform/Delete/5

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
        public ActionResult SubformGridview(int id)
        {
            DataTable dtblSubform = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM [NEWTEMPDB].[dbo].[Subform] WHERE OrderID = " + id + "", sqlCon);
                sqlDa.Fill(dtblSubform);
            }
            return View(dtblSubform);
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase postedFile)
        {
            DataTable dtblSubform = new DataTable();
            DataSet ds = new DataSet();
            string filePath = string.Empty;
            if (postedFile != null)
            {
                string path = Server.MapPath("~/Uploads/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                filePath = path + Path.GetFileName(postedFile.FileName);
                string extension = Path.GetExtension(postedFile.FileName);
                postedFile.SaveAs(filePath);

                string conString = string.Empty;
                switch (extension)
                {
                    case ".xls": //Excel 97-03.
                        conString = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                        break;
                    case ".xlsx": //Excel 07 and above.
                        conString = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;
                        break;
                }

                conString = string.Format(conString, filePath);

                using (OleDbConnection connExcel = new OleDbConnection(conString))
                {
                    using (OleDbCommand cmdExcel = new OleDbCommand())
                    {
                        using (OleDbDataAdapter odaExcel = new OleDbDataAdapter())
                        {
                            cmdExcel.Connection = connExcel;

                            //Get the name of First Sheet.
                            connExcel.Open();
                            DataTable dtExcelSchema;
                            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                            string sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                            connExcel.Close();

                            //Read Data from First Sheet.
                            connExcel.Open();
                            cmdExcel.CommandText = "SELECT * From [" + sheetName + "]";
                            odaExcel.SelectCommand = cmdExcel;
                            odaExcel.Fill(ds);

                            foreach (DataTable table in ds.Tables)
                            {
                                try
                                {
                                    foreach (DataRow dr in table.Rows)
                                    {
                                        string OrderID = dr.Field<double>("OrderID").ToString();
                                        string ProductCode = dr.Field<double>("ProductCode").ToString();
                                        string Quantity = dr.Field<double>("Quantity").ToString();
                                        OrderUpload(OrderID, ProductCode, Quantity);

                                    }
                                }
                                catch (Exception ex)
                                {

                                }
                            }


                            using (SqlConnection sqlCon = new SqlConnection(connectionString))
                            {
                                sqlCon.Open();
                                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT [SubformID],[OrderID],[ProductCode],[ProductImage],[Unit],[Rate],[Quantity],[Amount]FROM [NEWTEMPDB].[dbo].[Subform]", sqlCon);
                                sqlDa.Fill(dtblSubform);
                            }

                            connExcel.Close();
                        }
                    }
                }
            }
            return View(dtblSubform);
        }

        private void OrderUpload(string OrderID, string ProductCode, string Quantity)
        {
            string ProductImage = string.Empty;
            int Unit = 0;
            int Rate = 0;
            int Amount = 0;
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {

                    sqlCon.Open();
                    DataTable dtblSubform = new DataTable();
                    SqlDataAdapter sqlDaa = new SqlDataAdapter("SELECT [ProductImage],[Unit],[Rate] FROM [NEWTEMPDB].[dbo].[Product] WHERE [ProductCode]=" + ProductCode + "", sqlCon);
                    sqlDaa.Fill(dtblSubform);
                    foreach (DataRow row in dtblSubform.Rows)
                    {
                        ProductImage = row.Field<string>("ProductImage");
                        Unit = row.Field<int>("Unit");
                        Rate = row.Field<int>("Rate");
                    }
                    int aQuantity = Convert.ToInt32(Quantity);
                    Amount = Rate * aQuantity;
                    string query = "INSERT INTO [NEWTEMPDB].[dbo].[Subform] VALUES(@OrderID,@ProductCode,@ProductImage,@Unit,@Rate,@Quantity,@Amount)";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@OrderID", OrderID);
                    sqlCmd.Parameters.AddWithValue("@ProductCode", ProductCode);
                    sqlCmd.Parameters.AddWithValue("@ProductImage", ProductImage);
                    sqlCmd.Parameters.AddWithValue("@Unit", Unit);
                    sqlCmd.Parameters.AddWithValue("@Rate", Rate);
                    sqlCmd.Parameters.AddWithValue("@Quantity", Quantity);
                    sqlCmd.Parameters.AddWithValue("@Amount", Amount);
                    sqlCmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

            }
        }


        public ActionResult StateList(string CountryCode)
        {
            IQueryable states = State.GetStates().Where(x => x.CountryCode == CountryCode);

            if (HttpContext.Request.IsAjaxRequest())
                return Json(new SelectList(
                                states,
                                "StateID",
                                "StateName"), JsonRequestBehavior.AllowGet
                            );

            return View(states);
        }
    }

}

