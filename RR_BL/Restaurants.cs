using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RR_BL
{
    public class Restaurants
    {
        public Restaurants() { }
        public Restaurants(string name)
        {
            this.Name = name;
        }
        public Restaurants(int id, string name, decimal? rating, string location, int zipcode) : this(name)
        {
            this.ID = id;
            this.Rating = rating;
            this.Location = location;
            this.ZipCode = zipcode;
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal? Rating { get; set; }
        public string Location { get; set; }
        public int ZipCode { get; set; }
    }
}
