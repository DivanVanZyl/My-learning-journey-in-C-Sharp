using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoPizza.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Address { get; set; }
        public string? Phone { get; set; }

        /*Collection of Order objects. This is a "Navigation Property". 
         * It indicates that a customer has zero or more orders. 
         * This creates a one-many relationship in the DB that is generated.
         */
        public ICollection<Order> Orders { get; set; } = null!; 
    }
}
