using System;
using System.Collections.Generic;

#nullable disable

namespace FadokoBackendV3.Models
{
    public partial class Order
    {
        public int OrId { get; set; }
        public int? AdId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int Email { get; set; }
        public int Status { get; set; }
        public DateTime LogDate { get; set; }

        public virtual Admin Ad { get; set; }
        public virtual Tetelconn Tetelconn { get; set; }
    }
}
