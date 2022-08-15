using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLShop.Domain.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public long Ssn { get; set; }
        public string Username { get; set; }


        public ICollection<ContactDetail> ContactDetails { get; set; }
        public Name Name { get; set; }
    }
}
