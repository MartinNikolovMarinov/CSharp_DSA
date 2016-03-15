namespace _02.BiDictionary
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;

    public class BiDictionary<K1, K2, T>
    {
        private Dictionary<K1, List<T>> valuesByFirstKey;
        private Dictionary<K2, List<T>> valuesBySecondKey;
        private Dictionary<Tuple<K1, K2>, List<T>> valuesByBothKeys;

        public BiDictionary() 
        {
            this.valuesByFirstKey = new Dictionary<K1, List<T>>();
            this.valuesBySecondKey = new Dictionary<K2, List<T>>();
            this.valuesByBothKeys = new Dictionary<Tuple<K1, K2>, List<T>>();
        }

        public void Add(K1 key1, K2 key2, T value)
        {
            if (this.valuesByFirstKey.ContainsKey(key1))
                this.valuesByFirstKey[key1].Add(value);
            else
                this.valuesByFirstKey.Add(key1, new List<T>() { value });

            if (this.valuesBySecondKey.ContainsKey(key2))
                this.valuesBySecondKey[key2].Add(value);
            else
                this.valuesBySecondKey.Add(key2, new List<T>() { value });

            var bothKeys = new Tuple<K1, K2>(key1, key2);
            if (this.valuesByBothKeys.ContainsKey(bothKeys))
                this.valuesByBothKeys[bothKeys].Add(value);
            else
                this.valuesByBothKeys.Add(bothKeys, new List<T>() { value });
        }

        public IEnumerable<T> FindByKey1(K1 key1)
        {
            foreach (var keyValPair in this.valuesByFirstKey)
            {
                if (keyValPair.Key.Equals(key1))
                {
                    foreach (var val in keyValPair.Value)
                    {
                        yield return val;
                    }
                }
            }
        }
        
        public IEnumerable<T> FindByKey2(K2 key2) 
        {
            foreach (var keyValPair in this.valuesBySecondKey)
            {
                if (keyValPair.Key.Equals(key2))
                {
                    foreach (var val in keyValPair.Value)
                    {
                        yield return val;
                    }
                }
            }
        }

        public IEnumerable<T> Find(K1 key1, K2 key2) 
        {
            var query = from keyValPair in this.valuesByBothKeys
                        where keyValPair.Key.Item1.Equals(key1) &&
                            keyValPair.Key.Item2.Equals(key2)
                        select keyValPair.Value;

            return query.FirstOrDefault();
        }

        public bool Remove(K1 key1, K2 key2)
        {
            var bothKeys = new Tuple<K1, K2>(key1, key2);
            if (this.valuesByBothKeys.ContainsKey(bothKeys))
            {
                this.valuesByBothKeys.Remove(bothKeys);
                this.valuesByFirstKey.Clear();
                this.valuesBySecondKey.Clear();
                foreach (var val in valuesByBothKeys)
                {
                    if (this.valuesByFirstKey.ContainsKey(val.Key.Item1))
                    {
                        foreach (var v in val.Value)
                        {
                            this.valuesByFirstKey[val.Key.Item1].Add(v);
                        }
                    }
                    else 
                    {
                        this.valuesByFirstKey.Add(val.Key.Item1, val.Value);
                    }

                    if (this.valuesBySecondKey.ContainsKey(val.Key.Item2))
                    {
                        foreach (var v in val.Value)
                        {
                            this.valuesBySecondKey[val.Key.Item2].Add(v);
                        }
                    }
                    else
                    {
                        this.valuesBySecondKey.Add(val.Key.Item2, val.Value);
                    }
                }

                return true;
            }
            else 
            {
                return false;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var value in this.valuesByBothKeys)
            {
                sb.AppendFormat("({0} {1}): {2}", value.Key.Item1, value.Key.Item2, value.Value);
            }

            return base.ToString();
        }
    }
}
