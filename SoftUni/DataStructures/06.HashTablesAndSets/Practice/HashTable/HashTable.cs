using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class HashTable<TKey, TValue> : IEnumerable<KeyValue<TKey, TValue>>
{
    private const int DefaultCapacity = 16;
    private LinkedList<KeyValue<TKey, TValue>>[] slots;
    public const float LoadFactor = 0.75f;

    public HashTable()
    {
        this.Count = 0;
        this.slots = new LinkedList<KeyValue<TKey, TValue>>[DefaultCapacity];
    }
    public HashTable(int capacity)
    {
        this.Count = 0;
        this.slots = new LinkedList<KeyValue<TKey, TValue>>[capacity];
    }

    // Fields :
    public int Count { get; private set; }

    public int Capacity
    {
        get
        {
            return this.slots.Length;
        }
    }

    // Methods :
    private void Grow() 
    {
        var newHashTable = new HashTable<TKey, TValue>(2 * this.Capacity);
        foreach (var element in this)
        {
            newHashTable.Add(element.Key, element.Value);
        }

        this.slots = newHashTable.slots;
        this.Count = newHashTable.Count;
    }

    private void GrowIfNeeded()
    {
        if ((float)(this.Count + 1) / this.Capacity > LoadFactor)
        {
            this.Grow();
        }
    }

    private int FindSlothNumber(TKey key)
    {
        int slothNumber = Math.Abs(key.GetHashCode()) % this.slots.Length; 
        return slothNumber;
    }

    public void Add(TKey key, TValue value)
    {
        GrowIfNeeded();
        int slothNumber = this.FindSlothNumber(key);
        if (this.slots[slothNumber] == null)
        {
            this.slots[slothNumber] = new LinkedList<KeyValue<TKey, TValue>>();
        }

        foreach (var element in this.slots[slothNumber])
        {
            if (element.Key.Equals(key))
            {
                throw new ArgumentException("Key already exists: " + key);
            }
        }

        var newElement = new KeyValue<TKey, TValue>(key, value);
        this.slots[slothNumber].AddLast(newElement);
        this.Count++;
    }

    public bool AddOrReplace(TKey key, TValue value)
    {
        var element = this.Find(key);

        if (element == null)
        {
            this.Add(key, value);
            return false;
        }
        else 
        {
            int slothNumber = this.FindSlothNumber(key);
            var newElement = new KeyValue<TKey, TValue>(key, value);
            var listOfElements = this.slots[slothNumber];

            foreach (var currElem in listOfElements)
            {
                if (currElem.Equals(element))
                {
                    currElem.Value = newElement.Value;
                }
            }

            return true;
        }
    }

    public TValue Get(TKey key)
    {
        var element = this.Find(key);

        if (element == null)
        {
            throw new KeyNotFoundException();
        }

        return element.Value;
    }

    public TValue this[TKey key]
    {
        get
        {
            return this.Get(key);
        }
        set
        {
            this.AddOrReplace(key, value);
        }
    }

    public bool TryGetValue(TKey key, out TValue value)
    {
        var element = this.Find(key);
        value = default(TValue);

        if (element == null)
        {
            return false;
        }
        else 
        {
            value = element.Value;
            return true;
        }
    }

    public KeyValue<TKey, TValue> Find(TKey key)
    {
        int slothNumber = this.FindSlothNumber(key);
        var listOfElements = this.slots[slothNumber];

        if (listOfElements == null)
        {
            return null;
        }

        foreach (var element in listOfElements)
        {
            if (element.Key.Equals(key))
            {
                return element;
            }
        }

        return null;
    }

    public bool ContainsKey(TKey key)
    {
        var element = this.Find(key);
        return element != null;
    }

    public bool Remove(TKey key)
    {
        int slothNumber = this.FindSlothNumber(key);
        var listOfElements = this.slots[slothNumber];
        if (listOfElements != null)
        {
            var currentElement = listOfElements.First;
            while (currentElement != null)
            {
                if (currentElement.Value.Key.Equals(key))
                {
                    listOfElements.Remove(currentElement);
                    this.Count--;
                    return true;
                }

                currentElement = currentElement.Next;
            }
        }

        return false;
    }

    public void Clear()
    {
        this.Count = 0;
        this.slots = new LinkedList<KeyValue<TKey, TValue>>[DefaultCapacity];
    }

    public IEnumerable<TKey> Keys
    {
        get
        {
            return this.Select(e => e.Key);
        }
    }

    public IEnumerable<TValue> Values
    {
        get
        {
            return this.Select(e => e.Value);
        }
    }

    public IEnumerator<KeyValue<TKey, TValue>> GetEnumerator()
    {
        foreach (var listOfElements in this.slots)
        {
            if (listOfElements != null)
            {
                foreach (var element in listOfElements)
                {
                    yield return element;
                }
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
