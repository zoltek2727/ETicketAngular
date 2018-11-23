using System;
using System.Collections.Generic;

namespace ETicketAngular.Models
{
    public partial class Deliveries
    {
        public Deliveries()
        {
            Purchases = new HashSet<Purchases>();
        }

        public int DeliveryId { get; set; }
        public string DeliveryType { get; set; }
        public decimal Price { get; set; }

        public ICollection<Purchases> Purchases { get; set; }
    }
}
