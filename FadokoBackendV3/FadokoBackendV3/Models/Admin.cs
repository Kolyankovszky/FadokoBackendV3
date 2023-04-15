using System;
using System.Collections.Generic;

#nullable disable

namespace FadokoBackendV3.Models
{
    public partial class Admin
    {
        public Admin()
        {
            Orders = new HashSet<Order>();
        }

        public int AdId { get; set; }
        public string AdName { get; set; }
        public string AdPermission { get; set; }
        public string AdEmail { get; set; }
        public string AdPhone { get; set; }
        public int Active { get; set; }
        public string Salt { get; set; }
        public string Hash { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
