using System;
using System.Collections.Generic;

#nullable disable

namespace FadokoBackendV3.Models
{
    public partial class Tetelconn
    {
        public int OrId { get; set; }
        public int PrId { get; set; }
        public int Quantity { get; set; }

        public virtual Order Or { get; set; }
        public virtual Product Pr { get; set; }
    }
}
