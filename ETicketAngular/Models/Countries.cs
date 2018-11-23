using System;
using System.Collections.Generic;

namespace ETicketAngular.Models
{
    public partial class Countries
    {
        public Countries()
        {
            Cities = new HashSet<Cities>();
            Users = new HashSet<Users>();
        }

        public int CountryId { get; set; }
        public string CountryName { get; set; }

        public ICollection<Cities> Cities { get; set; }
        public ICollection<Users> Users { get; set; }
    }
}
