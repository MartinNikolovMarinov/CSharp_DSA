using System;
using System.Collections;
using System.Collections.Generic;

public class DoublyLinkedList<T> : IEnumerable<T>
{
    private static int DEFAULT_CAPACITY = 8;
    private T[] src;
    private int head;
    private int tail;
    public int Count { get; private set; }

    public DoublyLinkedList()
    {
        src = new T[DEFAULT_CAPACITY];
        head = src.Length / 2;
        tail = src.Length / 2;
    }

    private void Grow()
    {
        int i, start;
        var arr = new T[src.Length * 2];

        start = arr.Length / 2 - Count / 2;
        for (i = 0; i < Count; i++)
        {
            arr[i + start] = src[head + i];
        }

        tail = start + i - 1;
        head = start;
        src = arr;
    }

    public void AddFirst(T element)
    {
        if (head - 1 < 0)
            Grow();
        Count++;
        if (Count == 1)
            src[head] = element;
        else
            src[--head] = element;
    }

    public void AddLast(T element)
    {
        if (tail + 1 >= src.Length)
            Grow();
        Count++;
        if (Count == 1)
            src[head] = element;
        else
            src[++tail] = element;
    }

    public T RemoveFirst()
    {
        if (Count == 0)
            throw new InvalidOperationException("No elements in List.");
        Count--;
        var elem = src[head++];
        return elem;
    }

    public T RemoveLast()
    {
        if (Count == 0)
            throw new InvalidOperationException("No elements in List.");
        Count--;
        var elem = src[tail--];
        return elem;
    }

    public void ForEach(Action<T> action)
    {
        foreach (var item in this)
        {
            action(item);
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        if (Count != 0)
        {
            for (int i = head; i <= tail; i++)
            {
                yield return src[i];
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public T[] ToArray()
    {
        T[] arr = new T[this.Count];
        int i = 0;
        foreach (var item in this)
        {
            arr[i++] = item;
        }

        return arr;
    }
}

public class Prog
{
    public static void Main()
    {
        // Arrange
        var list = new DoublyLinkedList<int>();

        // Act
        var items = new List<int>();
        list.ForEach(items.Add);
    }
}