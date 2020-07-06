using System.Collections;
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
        //In else statements, need a way to display the values are over the customer requirements.
            SetPercentage(Excitment, customer.Exciting); 
            SetPercentage(Humor, customer.Humor);
            SetPercentage(Different, customer.Different);
            SetPercentage(Regal, customer.Regal);
        
        UpdateNumericText(CustomerPrice, "{0}", customer.Cost);
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
