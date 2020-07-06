using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerDisplay : CoreUIElement<ICustomerDesires, IItem>
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

    public override void UpdateUI(ICustomerDesires customer, IItem item)
    {
        if (ClearedIfEmpty(customer))
            return;
        //In else statements, need a way to display the values are over the customer requirements.
        if (item.Exciting <= customer.Exciting)
            SetPercentage(Excitment, (item.Exciting / customer.Exciting)); 
        else
            Excitment.fillAmount = 1;

        if (item.Humor <= customer.Humor)
            SetPercentage(Humor, item.Humor / customer.Humor);
        else
            Humor.fillAmount = 1;

        if (item.Different <= customer.Different)
            SetPercentage(Different, item.Different / customer.Different);
        else
            Different.fillAmount = 1;

        if (item.Regal <= customer.Regal)
            SetPercentage(Regal, item.Regal / customer.Regal);
        else
            Regal.fillAmount = 1;
        
        UpdateNumericText(CustomerPrice, "{0}", customer.Cost - item.Cost);
        UpdateNumericText(_ValExcitement, "{0}", customer.Exciting);
        UpdateNumericText(_ValHumor, "{0}", customer.Humor);
        UpdateNumericText(_ValDifferent, "{0}", customer.Different);
        UpdateNumericText(_ValRegal, "{0}", customer.Regal);
    }

    public override void UpdateUI(ICustomerDesires newData)
    {
        Debug.Log("No item supplied to compare to.");
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
