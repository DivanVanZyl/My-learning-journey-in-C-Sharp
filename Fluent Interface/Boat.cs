using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluent_Interface
{
    internal class Boat
    {
        private string _name;
        private bool _hasSails;

        public string Name => _name;
        public bool HasSails => _hasSails;

        private Boat() { }
        public static Boat BuildBoat()
        {
            return new Boat();
        }

        public Boat WithSails()
        {
            _hasSails = true;
            return this;
        }

        public Boat WithName(string name)
        {
            _name = name;
            return this;
        }
    }
}
