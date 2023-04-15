using System;
using System.Collections.Generic;

#nullable disable

namespace FadokoBackendV3.Models
{
    public partial class Commodity
    {
        public Commodity()
        {
            Receiptconns = new HashSet<Receiptconn>();
        }

        public int CoId { get; set; }
        public string CoName { get; set; }
        public int CoUnit { get; set; }
        public int CoCat { get; set; }
        public int CoPrice { get; set; }
        public int CoActive { get; set; }

        public virtual ICollection<Receiptconn> Receiptconns { get; set; }
    }
}
