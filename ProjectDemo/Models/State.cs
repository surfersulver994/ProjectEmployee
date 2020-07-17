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

        public static IQueryable<State> GetStates()
        {
            var a = "branch2";
            string connectionstring = @"data source=desktop-7r1i2hk; initial catalog=newtempdb; integrated security=true; multipleactiveresultsets=true";
            using (SqlConnection sqlcon = new SqlConnection(connectionstring))
            {
                ////////viewbag code start
                DataTable dtblproductcode = new DataTable();
                SqlDataAdapter sqldaa = new SqlDataAdapter("select [rate] from [newtempdb].[dbo].[product]", sqlcon);
                sqldaa.Fill(dtblproductcode);
                List<int> productcodelist = new List<int>();
                foreach (DataRow dr in dtblproductcode.Rows)
                {
                    int stateid = dr.Field<int>("rate");
                    int statename = dr.Field<int>("rate");
                    productcodelist.Add(stateid);
                    productcodelist.Add(statename);
                    SelectList list = new SelectList(productcodelist, "", "");
                    ////////viewbag.productcodelist = list;

                }
                ////////viewbag code end
                var Aqueryable = productcodelist.AsQueryable();
                return List<Aqueryable>();
                
            }

        }



    }
}