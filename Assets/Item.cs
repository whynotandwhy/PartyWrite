using UnityEngine;

[System.Serializable]
public class Item : IItem
{
    [SerializeField] protected float _Regal;
    [SerializeField] protected float _Exciting;
    [SerializeField] protected float _Humor;
    [SerializeField] protected float _Different;
    [SerializeField] protected float _Cost;
    [SerializeField] protected string _Name;
    [SerializeField] protected Sprite _Sprite;
    [SerializeField] protected string _Description;
    [SerializeField] protected float _PricePlayer;

    public float Regal => _Regal;
    public float Exciting => _Exciting;
    public float Humor => _Humor;
    public float Different => _Different;
    public float Cost => _Cost;
    string IItem.Name => _Name;
    Sprite IItem.Sprite => _Sprite;
    string IItem.Description => _Description;
    float IItem.PricePlayer => _PricePlayer;
}

