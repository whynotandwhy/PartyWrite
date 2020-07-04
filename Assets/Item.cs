using UnityEngine;

[System.Serializable]
public class Item : IItem
{
    [SerializeField] protected float _Regal;
    public float Regal => _Regal;
    [SerializeField] protected float _Exciting;
    public float Exciting => _Exciting;
    [SerializeField] protected float _Humor;
    public float Humor => _Humor;
    [SerializeField] protected float _Different;
    public float Different => _Different;
    [SerializeField] protected float _Cost;
    public float Cost => _Cost;
    [SerializeField] protected string _Name;
    string IItem.Name => _Name;
    [SerializeField] protected Sprite _Sprite;
    Sprite IItem.Sprite => _Sprite;
    [SerializeField] protected string _Description;
    string IItem.Description => _Description;
    [SerializeField] protected float _PricePlayer;
    float IItem.PricePlayer => _PricePlayer;
}

