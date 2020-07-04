
using UnityEngine;

[System.Serializable]
public class Item : IItem
{
    [SerializeField] protected float _Regal;
    public float Regal => _Regal;

    public float Exciting => throw new System.NotImplementedException();

    public float Humor => throw new System.NotImplementedException();

    public float Different => throw new System.NotImplementedException();

    public float Cost => throw new System.NotImplementedException();

    string IItem.Name => throw new System.NotImplementedException();

    Sprite IItem.Sprite => throw new System.NotImplementedException();

    string IItem.Description => throw new System.NotImplementedException();

    float IItem.PricePlayer => throw new System.NotImplementedException();
}

