using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq;

namespace CascadingComboBox1.Models
{
    public class State
    {
        public string CountryCode { get; set; }
        public int StateID { get; set; }
        public string StateName { get; set; }

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
                    int rate = dr.Field<int>("rate");
                    int unit = dr.Field<int>("unit");
                    ls.Add(new SelectListItem() { Text = rate.ToString(), Value = rate.ToString() });
                    ls.Add(new SelectListItem() { Text = unit.ToString(), Value = unit.ToString() });
                }
            }
            return ls.ToList();
        }
    }
}