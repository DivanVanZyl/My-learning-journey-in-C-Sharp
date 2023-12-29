using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class Employee
    {
        public string Name;
        public string Email;
        public Employee(string Name, string Email)
        {
            this.Name = Name;
            this.Email = Email;
        }
    }
}
