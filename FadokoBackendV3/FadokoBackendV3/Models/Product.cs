using System;
using System.Collections.Generic;

#nullable disable

namespace FadokoBackendV3.Models
{
    public partial class Product
    {
        public Product()
        {
            Receiptconns = new HashSet<Receiptconn>();
            Tetelconns = new HashSet<Tetelconn>();
        }

        public int PrId { get; set; }
        public string PrName { get; set; }
        public string PrSize { get; set; }
        public string PrOther { get; set; }
        public string PrUrl { get; set; }
        public int PrActive { get; set; }
        public int PrPrice { get; set; }

        public virtual ICollection<Receiptconn> Receiptconns { get; set; }
        public virtual ICollection<Tetelconn> Tetelconns { get; set; }
    }
}
