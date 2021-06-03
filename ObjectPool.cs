using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolable
{
    void Dispose();
}
 
public class ObjectPool<T> : IPoolable
{
    object lockObj = new object();
    Queue<T> queue = new Queue<T>();
 
    public void Push(T item)
    {
        lock (lockObj)
        {
            queue.Enqueue(item);
        }
    }
 
    public T Pop()
    {
        lock (lockObj)
        {
            return queue.Dequeue();
        }
    }
 
    public int Count
    {
        get
        {
            lock (lockObj)
            {
                return queue.Count;
            }
        }
    }
 
    public T Get()
    {
        lock (lockObj)
        {
            return queue.Peek();
        }
    }
 
    public void Clear()
    {
        lock (lockObj)
        {
            queue.Clear();
        }
    }
 
    public void Dispose()
    {
    }
}
