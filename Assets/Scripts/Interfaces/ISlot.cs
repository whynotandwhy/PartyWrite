using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISlot<T> : IDraggable<T>
{
    int Count { get; }
    int MaxCount { get; }

    void Add(T item, int count);
    void Subtract(T item, int count);
    int CanAdd(T item, int count);
    int CanSubtract(T item, int count);
    void Set(T item, int count);
}
