using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CascadingComboBox1.Models
{
    public class Product
    {
        public string Unit { get; set; }
        public int Rate { get; set; }

        public List<SelectListItem> GetStates()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            string connectionstring = @"data source=desktop-7r1i2hk; initial catalog=newtempdb; integrated security=true; multipleactiveresultsets=true";
            using (SqlConnection sqlcon = new SqlConnection(connectionstring))
            {
                DataTable dtblproductcode = new DataTable();
                SqlDataAdapter sqldaa = new SqlDataAdapter("select * FROM [NEWTEMPDB].[dbo].[Subform]", sqlcon);
                sqldaa.Fill(dtblproductcode);
                //List<int> productcodelist = new List<int>();
                foreach (DataRow dr in dtblproductcode.Rows)
                {
                    int Rate = dr.Field<int>("Rate");
                    int Unit = dr.Field<int>("Unit");
                    ls.Add(new SelectListItem() { Text = Rate.ToString(), Value = Rate.ToString() });
                    ls.Add(new SelectListItem() { Text = Unit.ToString(), Value = Unit.ToString() });
                }
            }
            return ls.ToList();
        }
    }
}