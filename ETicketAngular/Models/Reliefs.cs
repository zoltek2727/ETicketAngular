using System;
using System.Collections.Generic;

namespace ETicketAngular.Models
{
    public partial class Reliefs
    {
        public Reliefs()
        {
            Purchases = new HashSet<Purchases>();
        }

        public int ReliefId { get; set; }
        public string ReliefType { get; set; }
        public decimal ReliefPercent { get; set; }

        public ICollection<Purchases> Purchases { get; set; }
    }
}
