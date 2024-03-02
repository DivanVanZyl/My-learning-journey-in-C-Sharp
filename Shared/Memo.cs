using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class Memo<TKey, TValue> where TKey : notnull
    {
        private Dictionary<TKey, TValue> _memo = new();

        public void Add(TKey key, TValue value)
        {
            _memo[key] = value;
        }

        public TValue GetValue(TKey key)
        {
            return _memo[key];
        }
    }
}
