using System;
using System.Collections.Generic;

namespace RR_BL
{
    public class Reviews
    {
        public Reviews() { }
        public Reviews(int id, string uid, string rid, int? rating, string comment)
        {
            this.ID = id;
            this.UID = uid;
            this.RID = rid;
            this.Rating = rating;
            this.Comment = comment;
        }
        
        public int ID { get; set; }
        public string UID { get; set; }
        public string RID { get; set; }
        public int? Rating { get; set; }
        public string Comment { get; set; }
    }
}
