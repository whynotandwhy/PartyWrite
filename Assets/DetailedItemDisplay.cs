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

    public override void UpdateUI(IItem newData)
    {
        if (ClearedIfEmpty(newData))
            return;
        SetPercentage(_Excitment, newData.Exciting);
    }

    protected override bool ClearedIfEmpty(IItem newData)
    {
        if (newData != null)
            return false;
        //clearing data
        SetPercentage(_Excitment, 0);

        return true;
    }

}

