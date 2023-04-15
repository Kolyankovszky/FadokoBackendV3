using System;
using System.Collections.Generic;

#nullable disable

namespace FadokoBackendV3.Models
{
    public partial class Receiptconn
    {
        public int ReId { get; set; }
        public int PrId { get; set; }
        public int CoId { get; set; }
        public int Quantity { get; set; }

        public virtual Commodity Co { get; set; }
        public virtual Product Pr { get; set; }
    }
}
