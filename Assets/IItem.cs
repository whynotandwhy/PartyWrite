using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItem
{
    string ItemName { get; }
    Sprite ItemSprite { get; }
    string ItemDescription { get; }
    float RegalValue { get; }
    float ExcitingValue { get; }
    float HumorValue { get; }
    float DifferentValue { get; }
    float PlayerPrice { get; }
    float CustomerPrice { get; }
}
