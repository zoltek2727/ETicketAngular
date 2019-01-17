using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace ETicketAngular.Models
{
    public partial class Users
    {
        public Users()
        {
            Purchases = new HashSet<Purchases>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserEmail { get; set; }
        public string UserFirstname { get; set; }
        public string UserSurname { get; set; }
        public DateTime? UserBirthdate { get; set; }
        public string UserCity { get; set; }
        public string UserAddress { get; set; }
        public string UserPhone { get; set; }
        public string UserSex { get; set; }
        public DateTime UserCreated { get; set; }
        public DateTime UserLastLog { get; set; }
        public int RoleId { get; set; }
        public int CountryId { get; set; }

        public Countries Country { get; set; }
        public Roles Role { get; set; }
        public ICollection<Purchases> Purchases { get; set; }
    }
}
