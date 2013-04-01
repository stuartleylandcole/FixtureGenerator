using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FixtureGenerator
{
    public class Location
    {
        public string City { get; set; }
        public string Area { get; set; }

        public Location(string city, string area)
        {
            City = city;
            Area = area;
        }
    }
}
