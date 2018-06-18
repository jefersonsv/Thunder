using System;
using System.Collections.Generic;
using System.Text;

namespace Thunder
{
    internal class KeyValuePairList<Tkey, TValue> : List<KeyValuePair<Tkey, TValue>>
    {
        internal void Add(Tkey key, TValue value)
        {
            base.Add(new KeyValuePair<Tkey, TValue>(key, value));
        }
    }
}