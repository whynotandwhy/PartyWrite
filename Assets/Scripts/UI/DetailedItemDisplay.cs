using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetailedItemDisplay : CoreUIElement<IItem>
{
    [SerializeField] protected Image _Excitment;
    [SerializeField] protected Text _ValExcitement;
    protected Image Excitment => _Excitment;
    [SerializeField] protected Image _Humor;
    [SerializeField] protected Text _ValHumor;
    protected Image Humor => _Humor;
    [SerializeField] protected Image _Different;
    [SerializeField] protected Text _ValDifferent;
    protected Image Different => _Different;
    [SerializeField] protected Image _Regal;
    [SerializeField] protected Text _ValRegal;
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

    //Created temporary desire maximum, this should be static instance -- temporary desire Maximum also added to Customer Generator in MiniGameplayLoop.
    protected int MaxDesire = 15;

    public override void UpdateUI(IItem newData)
    {
        if (ClearedIfEmpty(newData))
            return;
        SetPercentage(Excitment, newData.Exciting / MaxDesire);
        SetPercentage(Humor, newData.Humor / MaxDesire);
        SetPercentage(Different, newData.Different / MaxDesire);
        SetPercentage(Regal, newData.Regal / MaxDesire);
        UpdateText(Name, newData.Name);
        UpdateText(Description, newData.Description);
        UpdateNumericText(_ValExcitement, "{0}", newData.Exciting);
        UpdateNumericText(_ValHumor, "{0}", newData.Humor);
        UpdateNumericText(_ValDifferent, "{0}", newData.Different);
        UpdateNumericText(_ValRegal, "{0}", newData.Regal);
        UpdateNumericText(PlayerPrice, "{0}", newData.PricePlayer);
        UpdateNumericText(CustomerPrice, "{0}", newData.Cost);
        UpdateSprite(Sprite, newData.Sprite);
    }

    protected override bool ClearedIfEmpty(IItem newData)
    {
        if (newData != null)
            return false;
        //clearing data
        SetPercentage(Excitment, 0);
        SetPercentage(Humor, 0);
        SetPercentage(Different, 0);
        SetPercentage(Regal, 0);
        UpdateText(Name, string.Empty);
        UpdateText(Description, string.Empty);
        UpdateNumericText(_ValExcitement, "{0}", 0);
        UpdateNumericText(_ValHumor, "{0}", 0);
        UpdateNumericText(_ValDifferent, "{0}", 0);
        UpdateNumericText(_ValRegal, "{0}", 0);
        UpdateNumericText(PlayerPrice, "{0}", 0);
        UpdateNumericText(CustomerPrice, "{0}", 0);
        UpdateSprite(Sprite, null);

        return true;
    }
}

