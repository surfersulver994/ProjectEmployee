using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CascadingComboBox1.Models
{
    public class State
    {
        public string CountryCode { get; set; }
        public int StateID { get; set; }
        public string StateName { get; set; }

        //public static IQueryable<State> GetStates()
        //{
        //    return new List<State>
        //    {
        //        new State
        //            {
        //                CountryCode = "CA",
        //                StateID=1,
        //                StateName = "Ontario"
        //            },
        //        new State
        //            {
        //                CountryCode = "3",
        //                StateID=2,
        //                StateName = "Quebec"
        //            },
        //        new State
        //            {
        //                CountryCode = "3",
        //                StateID=3,
        //                StateName = "Nova Scotia"
        //            },
        //        new State
        //            {
        //                CountryCode = "3",
        //                StateID=4,
        //                StateName = "New Brunswick"
        //            },
        //        new State
        //            {
        //                CountryCode = "3",
        //                StateID=5,
        //                StateName = "Manitoba"
        //            },
        //        new State
        //            {
        //                CountryCode = "3",
        //                StateID=6,
        //                StateName = "British Columbia"
        //            },
        //        new State
        //            {
        //                CountryCode = "3",
        //                StateID=7,
        //                StateName = "Prince Edward Island"
        //            },
        //        new State
        //            {
        //                CountryCode = "3",
        //                StateID=8,
        //                StateName = "Saskatchewan"
        //            },
        //        new State
        //            {
        //                CountryCode = "3",
        //                StateID=9,
        //                StateName = "Alberta"
        //            },
        //        new State
        //            {
        //                CountryCode = "2",
        //                StateID=10,
        //                StateName = "Newfoundland and Labrador"
        //            },
        //        new State
        //            {
        //                CountryCode = "2",
        //                StateID=11,
        //                StateName = "New-York"
        //            },
        //        new State
        //            {
        //                CountryCode = "2",
        //                StateID=12,
        //                StateName = "California"
        //            },
        //        new State
        //            {
        //                CountryCode = "2",
        //                StateID=13,
        //                StateName = "Washington"
        //            }
        //    }.AsQueryable();
        //}


        //public static IQueryable<State> SqlGetStates()
        //{
        //    return new List<State>
        //    {
        //        new State
        //            {
        //                CountryCode = "CA",
        //                StateID=1,
        //                StateName = "Ontario"
        //            },
        //        new State
        //            {
        //                CountryCode = "3",
        //                StateID=2,
        //                StateName = "Quebec"
        //            },
        //        new State
        //            {
        //                CountryCode = "3",
        //                StateID=3,
        //                StateName = "Nova Scotia"
        //            },
        //        new State
        //            {
        //                CountryCode = "3",
        //                StateID=4,
        //                StateName = "New Brunswick"
        //            },
        //        new State
        //            {
        //                CountryCode = "3",
        //                StateID=5,
        //                StateName = "Manitoba"
        //            },
        //        new State
        //            {
        //                CountryCode = "3",
        //                StateID=6,
        //                StateName = "British Columbia"
        //            },
        //        new State
        //            {
        //                CountryCode = "3",
        //                StateID=7,
        //                StateName = "Prince Edward Island"
        //            },
        //        new State
        //            {
        //                CountryCode = "3",
        //                StateID=8,
        //                StateName = "Saskatchewan"
        //            },
        //        new State
        //            {
        //                CountryCode = "3",
        //                StateID=9,
        //                StateName = "Alberta"
        //            },
        //        new State
        //            {
        //                CountryCode = "2",
        //                StateID=10,
        //                StateName = "Newfoundland and Labrador"
        //            },
        //        new State
        //            {
        //                CountryCode = "2",
        //                StateID=11,
        //                StateName = "New-York"
        //            },
        //        new State
        //            {
        //                CountryCode = "2",
        //                StateID=12,
        //                StateName = "California"
        //            },
        //        new State
        //            {
        //                CountryCode = "2",
        //                StateID=13,
        //                StateName = "Washington"
        //            },
        //        new State
        //            {
        //                CountryCode = "2x",
        //                StateID=14,
        //                StateName = "Vermont"
        //            }
        //    }.AsQueryable();
        //}

        public static IQueryable<State> GetStates()
        {
            string connectionString = @"data source=DESKTOP-7R1I2HK; initial catalog=NEWTEMPDB; integrated security=True; MultipleActiveResultSets=True";
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                //viewbag code start
                DataTable dtblProductCode = new DataTable();
                SqlDataAdapter sqlDaa = new SqlDataAdapter("SELECT [Rate] FROM [NEWTEMPDB].[dbo].[Product]", sqlCon);
                sqlDaa.Fill(dtblProductCode);
                List<int> ProductCodeList = new List<int>();
                foreach (DataRow dr in dtblProductCode.Rows)
                {
                    int StateID = dr.Field<int>("Rate");
                    int StateName = dr.Field<int>("Rate");
                    ProductCodeList.Add(StateID);
                    ProductCodeList.Add(StateName);
                    SelectList list = new SelectList(ProductCodeList, "", "");
                    //ViewBag.ProductCodeList = list;

                }
                //viewbag code end
            }
            return new List<State>();
        }



    }
}