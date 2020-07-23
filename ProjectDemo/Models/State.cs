using System.Collections.Generic;
using System.Linq;

public class State
{
    public string ProductCode { get; set; }
    public int StateID { get; set; }
    public string Unit { get; set; }
    public int Rate { get; set; }


    public static IQueryable<State> GetStates()
    {
        return new List<State>
            {   
                new State
                    {
                        ProductCode = "2",
                        StateID=99,
                        Unit = "pieces"//bring in unit
                    },
                new State
                    {
                        ProductCode = "2",
                        StateID=12,
                        Unit = "56"//bring in rate
                    },
                new State
                    {
                        ProductCode = "2",
                        StateID=13,
                        Unit = "~/Image/a201101509.png"//bring in image
                    },
                new State
                    {
                        ProductCode = "3",
                        StateID=11,
                        Unit = "kilos"//bring in unit
                    },
                   new State
                    {
                        ProductCode = "3",
                        StateID=11,
                        Unit = "ounces"//bring in rate
                    },
                      new State
                    {
                        ProductCode = "3",
                        StateID=11,
                        Unit = "~/Image/a201101509.png"//bring in image
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
