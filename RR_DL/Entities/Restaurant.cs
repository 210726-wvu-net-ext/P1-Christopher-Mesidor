using System;
using System.Collections.Generic;

#nullable disable

namespace RR_DL.Entities
{
    public partial class Restaurant
    {
        public Restaurant()
        {
            Reviews = new HashSet<Review>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Rating { get; set; }
        public string Location { get; set; }
        public int ZipCode { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}
