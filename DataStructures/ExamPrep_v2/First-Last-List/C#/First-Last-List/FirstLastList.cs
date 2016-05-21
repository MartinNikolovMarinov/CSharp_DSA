using System;
using System.Collections.Generic;
using System.Linq;

public class FirstLastList<T> : IFirstLastList<T>
    where T : IComparable<T>
{
    private List<T> elements = new List<T>();

    public void Add(T newElement)
    {
        throw new NotImplementedException();
    }

    public int Count
    {
        get
        {
            throw new NotImplementedException();
        }
    }

    public IEnumerable<T> First(int count)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<T> Last(int count)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<T> Min(int count)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<T> Max(int count)
    {
        throw new NotImplementedException();
    }

    public int RemoveAll(T element)
    {
        throw new NotImplementedException();
    }

    public void Clear()
    {
        throw new NotImplementedException();
    }
}
