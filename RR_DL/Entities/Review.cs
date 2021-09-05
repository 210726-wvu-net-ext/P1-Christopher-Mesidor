using System;
using System.Collections.Generic;

#nullable disable

namespace RR_DL.Entities
{
    public partial class Review
    {
        public int Id { get; set; }
        public string Users { get; set; }
        public string Restaurant { get; set; }
        public int? Rating { get; set; }
        public string Comments { get; set; }

        public virtual Restaurant RestaurantNavigation { get; set; }
        public virtual User UsersNavigation { get; set; }
    }
}
