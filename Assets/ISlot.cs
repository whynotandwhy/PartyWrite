using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISlot : IItem
{
    int Count { get; }
    int MaxCount { get; }

    void Add();
    void Subtract();
    int CanAdd();
    int CanSubtract();
}
