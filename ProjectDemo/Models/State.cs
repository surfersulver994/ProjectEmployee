﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CascadingComboBox1.Models
{
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
    }
}