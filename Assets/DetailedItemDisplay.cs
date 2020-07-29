using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetailedItemDisplay : CoreUIElement<IItem>
{
    [SerializeField] protected Image _Excitment;
    protected Image Excitment => _Excitment;
    [SerializeField] protected Image _Humor;
    protected Image Humor => _Humor;
    [SerializeField] protected Image _Different;
    protected Image Different => _Different;
    [SerializeField] protected Image _Regal;
    protected Image Regal => _Regal;
    [SerializeField] protected Text _Name;
    protected Text Name => _Name;
    [SerializeField] protected Image _Sprite;
    protected Image Sprite => _Sprite;
    [SerializeField] protected Text _Description;
    protected Text Description => _Description;
    [SerializeField] protected Text _PlayerPrice;
    protected Text PlayerPrice => _PlayerPrice;
    [SerializeField] protected Text _CustomerPrice;
    protected Text CustomerPrice => _CustomerPrice;


    public override void UpdateUI(IItem newData)
    {
        if (ClearedIfEmpty(newData))
            return;
        SetPercentage(_Excitment, newData.Exciting);
        SetPercentage(_Humor, newData.Humor);
        SetPercentage(_Different, newData.Different);
        SetPercentage(_Regal, newData.Regal);
        UpdateText(_Name, newData.Name );
        UpdateText(_Description, newData.Description );
        UpdateNumericText(_PlayerPrice, "{0}", newData.PricePlayer);
        UpdateNumericText(_CustomerPrice, "{0}", newData.Cost );
        UpdateSprite(newData.Sprite, _Sprite);
    }

    protected override bool ClearedIfEmpty(IItem newData)
    {
        if (newData != null)
            return false;
        //clearing data
        SetPercentage(_Excitment, 0);
        SetPercentage(_Humor, 0);
        SetPercentage(_Different, 0);
        SetPercentage(_Regal, 0);
        UpdateText(_Name, "");
        UpdateText(_Description, "" );
        UpdateNumericText(_PlayerPrice, "{0}", 0 );
        UpdateNumericText(_CustomerPrice, "{0}", 0);
        UpdateSprite(null, _Sprite);

        return true;
    }

}

