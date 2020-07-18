using System.Collections.Generic;
using System.Linq;

public class State
{
    public string CountryCode { get; set; }
    public int StateID { get; set; }
    public string StateName { get; set; }

    public static IQueryable<State> GetStates()
    {
        return new List<State>
            {
                new State
                    {
                        CountryCode = "CA",
                        StateID=1,
                        StateName = "Ontario"
                    },
                new State
                    {
                        CountryCode = "3",
                        StateID=2,
                        StateName = "Quebec"
                    },
                new State
                    {
                        CountryCode = "3",
                        StateID=3,
                        StateName = "Nova Scotia"
                    },
                new State
                    {
                        CountryCode = "3",
                        StateID=4,
                        StateName = "New Brunswick"
                    },
                new State
                    {
                        CountryCode = "3",
                        StateID=5,
                        StateName = "Manitoba"
                    },
                new State
                    {
                        CountryCode = "3",
                        StateID=6,
                        StateName = "British Columbia"
                    },
                new State
                    {
                        CountryCode = "3",
                        StateID=7,
                        StateName = "Prince Edward Island"
                    },
                new State
                    {
                        CountryCode = "3",
                        StateID=8,
                        StateName = "Saskatchewan"
                    },
                new State
                    {
                        CountryCode = "3",
                        StateID=9,
                        StateName = "Alberta"
                    },
                new State
                    {
                        CountryCode = "2",
                        StateID=10,
                        StateName = "Newfoundland and Labrador"
                    },
                new State
                    {
                        CountryCode = "2",
                        StateID=11,
                        StateName = "New-York"
                    },
                new State
                    {
                        CountryCode = "2",
                        StateID=12,
                        StateName = "California"
                    },
                new State
                    {
                        CountryCode = "2",
                        StateID=13,
                        StateName = "Washington"
                    }
            }.AsQueryable();
    }

    


    public static IQueryable<State> SqlGetStates()
    {
        return new List<State>
            {
                new State
                    {
                        CountryCode = "CA",
                        StateID=1,
                        StateName = "Ontario"
                    },
                new State
                    {
                        CountryCode = "3",
                        StateID=2,
                        StateName = "Quebec"
                    },
                new State
                    {
                        CountryCode = "3",
                        StateID=3,
                        StateName = "Nova Scotia"
                    },
                new State
                    {
                        CountryCode = "3",
                        StateID=4,
                        StateName = "New Brunswick"
                    },
                new State
                    {
                        CountryCode = "3",
                        StateID=5,
                        StateName = "Manitoba"
                    },
                new State
                    {
                        CountryCode = "3",
                        StateID=6,
                        StateName = "British Columbia"
                    },
                new State
                    {
                        CountryCode = "3",
                        StateID=7,
                        StateName = "Prince Edward Island"
                    },
                new State
                    {
                        CountryCode = "3",
                        StateID=8,
                        StateName = "Saskatchewan"
                    },
                new State
                    {
                        CountryCode = "3",
                        StateID=9,
                        StateName = "Alberta"
                    },
                new State
                    {
                        CountryCode = "2",
                        StateID=10,
                        StateName = "Newfoundland and Labrador"
                    },
                new State
                    {
                        CountryCode = "2",
                        StateID=11,
                        StateName = "New-York"
                    },
                new State
                    {
                        CountryCode = "2",
                        StateID=12,
                        StateName = "California"
                    },
                new State
                    {
                        CountryCode = "2",
                        StateID=13,
                        StateName = "Washington"
                    },
                new State
                    {
                        CountryCode = "2x",
                        StateID=14,
                        StateName = "Vermont"
                    }
            }.AsQueryable();
    }

    //public static IQueryable<State> GetStates()
    //{
    //    var a = "branch2";
    //    string connectionstring = @"data source=desktop-7r1i2hk; initial catalog=newtempdb; integrated security=true; multipleactiveresultsets=true";
    //    using (SqlConnection sqlcon = new SqlConnection(connectionstring))
    //    {
    //        ////////viewbag code start
    //        DataTable dtblproductcode = new DataTable();
    //        SqlDataAdapter sqldaa = new SqlDataAdapter("select [rate] from [newtempdb].[dbo].[product]", sqlcon);
    //        sqldaa.Fill(dtblproductcode);
    //        List<int> productcodelist = new List<int>();
    //        foreach (DataRow dr in dtblproductcode.Rows)
    //        {
    //            int stateid = dr.Field<int>("rate");
    //            int statename = dr.Field<int>("rate");
    //            productcodelist.Add(stateid);
    //            productcodelist.Add(statename);
    //            SelectList list = new SelectList(productcodelist, "", "");
    //            ////////viewbag.productcodelist = list;

    //        }
    //        ////////viewbag code end
    //        var Aqueryable = productcodelist.AsQueryable();
    //        return List<Aqueryable>();

    //    }

}
