using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameplayLoop : MonoBehaviour
{
    //This would need to be exchanged for a shopping cart containing total values
    [SerializeField] protected TestDetailedItemDisplay itemDisplay;
    [SerializeField] protected CustomerDisplay customerDisplay;
    [SerializeField] protected Text valExcitement;
    [SerializeField] protected Text valHumor;
    [SerializeField] protected Text valDifferent;
    [SerializeField] protected Text valRegal;
    protected Customer customer;
    protected Customer customerComparison;
    protected int randomStat;
    protected int MaxDesire = 15;


    protected void Awake()
    {
        if(customerDisplay == null)
            customerDisplay = FindObjectOfType<CustomerDisplay>();

        //This would need to be exchanged for shopping cart containing total values
        if(itemDisplay == null)
            itemDisplay = FindObjectOfType<TestDetailedItemDisplay>();
    }

    [ContextMenu("Test Generate Customer")]
    protected void GenerateCustomer()
    {
        customer =
            new Customer(
                        RandomizeCustomerStat(),
                        RandomizeCustomerStat(),
                        RandomizeCustomerStat(),
                        RandomizeCustomerStat(),
                        100);
        valExcitement.text = customer.Exciting.ToString();
        valHumor.text = customer.Humor.ToString();
        valDifferent.text = customer.Different.ToString();
        valRegal.text = customer.Regal.ToString();
    }

    [ContextMenu("Update Customer")]
    protected void UpdateCustomer()
    {
        customerComparison = new Customer(
            CompareValues(customer.Exciting, itemDisplay.Item.Exciting),
            CompareValues(customer.Humor, itemDisplay.Item.Humor),
            CompareValues(customer.Different, itemDisplay.Item.Different),
            CompareValues(customer.Regal, itemDisplay.Item.Regal),
            customer.Cost - itemDisplay.Item.Cost
            );

        customerDisplay.UpdateUI(customerComparison);
    }
    
    protected float CompareValues(float customerValue, float cartValue)
    {
        bool lessThan;

        lessThan = cartValue <= customerValue ? true : false;

        return lessThan ? cartValue / customerValue : customerValue / cartValue;
    }

    protected int RandomizeCustomerStat() => randomStat = Random.Range(0, MaxDesire);
}
