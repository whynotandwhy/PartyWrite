using UnityEngine;

[System.Serializable]
public class Item : IItem
{
    [SerializeField] protected float _Exciting;
    [SerializeField] protected float _Humor;
    [SerializeField] protected float _Different;
    [SerializeField] protected float _Regal;
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
    public string Name => _Name;
    public Sprite Sprite => _Sprite;
    public string Description => _Description;
    public float PricePlayer => _PricePlayer;

    public Item() : this
    (
        0, 0,
        0, 0,
        0, string.Empty,
        default, string.Empty,
        0
    )
    { }

    public Item(
        float regal, float exciting,
        float humor, float different,
        float cost, string name,
        Sprite sprite, string description,
        float pricePlayer)
    {
        _Regal = regal; _Exciting = exciting;
        _Humor = humor; _Different = different;
        _Cost = cost; _Name = name;
        _Sprite = sprite; _Description = description;
        _PricePlayer = pricePlayer;
    }

}

