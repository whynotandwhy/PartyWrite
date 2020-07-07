﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerDisplay : CoreUIElement<ICustomerDesires>
{
    [SerializeField] protected Image _Excitment;
    protected Image Excitment => _Excitment;
    [SerializeField] protected Text _ValExcitement;
    [SerializeField] protected Image _Humor;
    protected Image Humor => _Humor;
    [SerializeField] protected Text _ValHumor;
    [SerializeField] protected Image _Different;
    protected Image Different => _Different;
    [SerializeField] protected Text _ValDifferent;
    [SerializeField] protected Image _Regal;
    protected Image Regal => _Regal;
    [SerializeField] protected Text _ValRegal;
    [SerializeField] protected Text _CustomerPrice;
    protected Text CustomerPrice => _CustomerPrice;

    public override void UpdateUI(ICustomerDesires customer)
    {
        if (ClearedIfEmpty(customer))
            return;
        SetMeterEffects(Excitment, customer.Exciting);
        SetPercentage(Excitment, customer.Exciting);

        SetMeterEffects(Humor, customer.Humor);
        SetPercentage(Humor, customer.Humor);

        SetMeterEffects(Different, customer.Different);
        SetPercentage(Different, customer.Different);

        SetMeterEffects(Regal, customer.Regal);
        SetPercentage(Regal, customer.Regal);

        UpdateNumericText(CustomerPrice, "{0}", customer.Cost);
    }

    public void InitCustomer(ICustomerDesires customer)
    {
        UpdateNumericText(CustomerPrice, "{0}", customer.Cost);
        UpdateNumericText(_ValExcitement, "{0}", customer.Exciting);
        UpdateNumericText(_ValHumor, "{0}", customer.Humor);
        UpdateNumericText(_ValDifferent, "{0}", customer.Different);
        UpdateNumericText(_ValRegal, "{0}", customer.Regal);
    }

    protected void SetMeterEffects(Image meter, float statValue)
    {
        //Add more advanced way to recognize how "over" we are.
        meter.color = statValue <= 1f ? Color.green : statValue > 1f && statValue <= 1.25 ? Color.yellow : Color.red;
    }

    protected override bool ClearedIfEmpty(ICustomerDesires newData)
    {
        if (newData != null)
            return false;

        SetPercentage(Excitment, 0);
        SetPercentage(Humor, 0);
        SetPercentage(Different, 0);
        SetPercentage(Regal, 0);
        UpdateNumericText(_ValExcitement, "{0}", 0);
        UpdateNumericText(_ValHumor, "{0}", 0);
        UpdateNumericText(_ValDifferent, "{0}", 0);
        UpdateNumericText(_ValRegal, "{0}", 0);

        UpdateNumericText(CustomerPrice, "{0}", 0);

        return true;
    }
}
