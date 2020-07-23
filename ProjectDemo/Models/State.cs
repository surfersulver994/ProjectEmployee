using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

public class State
{
    public string ProductCode { get; set; }
    public int StateID { get; set; }
    public string Unit { get; set; }
    public int Rate { get; set; }
    public string Image { get; set; }

    //public static IQueryable<State> GetStates()
    //{
    //    return new List<State>
    //        {
    //            new State
    //                {
    //                    ProductCode = "2",
    //                    StateID=99,
    //                    Unit = "pieces"//bring in unit
    //                },
    //            new State
    //                {
    //                    ProductCode = "2",
    //                    StateID=12,
    //                    Unit = "56"//bring in rate
    //                },
    //            new State
    //                {
    //                    ProductCode = "2",
    //                    StateID=13,
    //                    Unit = "~/Image/a201101509.png"//bring in image
    //                },
    //            new State
    //                {
    //                    ProductCode = "3",
    //                    StateID=11,
    //                    Unit = "kilos"//bring in unit
    //                },
    //               new State
    //                {
    //                    ProductCode = "3",
    //                    StateID=11,
    //                    Unit = "ounces"//bring in rate
    //                },
    //                  new State
    //                {
    //                    ProductCode = "3",
    //                    StateID=11,
    //                    Unit = "~/Image/a201101509.png"//bring in image
    //                }

    //        }.AsQueryable();
    //}


    public static IQueryable<State> GetStates()
    {
        string queryString = "SELECT [ProductCode],[ProductName],[Unit],[Rate],[Description],[ProductImage]FROM [NEWTEMPDB].[dbo].[Product]";
        string connectionString = @"data source=DESKTOP-7R1I2HK; initial catalog=NEWTEMPDB; integrated security=True; MultipleActiveResultSets=True";
        List<State> families = new List<State>();
        using (SqlConnection myConnection = new SqlConnection(connectionString))
        {
            
            myConnection.Open();
            SqlCommand command = new SqlCommand(queryString, myConnection);
            SqlDataReader nwReader = command.ExecuteReader();
            while (nwReader.Read())
            {
                families.Add(new State
                {
                    Unit  = nwReader["Unit"].ToString(),
                    Rate  = Convert.ToInt32(nwReader["Rate"].ToString()),
                    Image = nwReader["ProductImage"].ToString(),
                });
            }

            myConnection.Close();

        }
        var showFamilies = families.ToList();
        IQueryable getFamilies = showFamilies.AsQueryable();

        return (IQueryable<State>)getFamilies;
    }

}
