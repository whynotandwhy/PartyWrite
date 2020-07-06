using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameplayLoop : MonoBehaviour
{
    protected Customer customer;
    [SerializeField] protected CustomerDisplay customerDisplay;

    //This would need to be exchanged for a shopping cart containing total values
    [SerializeField] protected TestDetailedItemDisplay itemDisplay;
    protected int randomStat;
    protected int MaxDesire = 15;


    //protected void Awake()
    //{
    //    customerDisplay = FindObjectOfType<CustomerDisplay>();

    //    //This would need to be exchanged for shopping cart containing total values
    //    itemDisplay = FindObjectOfType<TestDetailedItemDisplay>();
    //}

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
        
        customerDisplay.UpdateUI(customer, itemDisplay.Item);
        Debug.Log("Customer Excitement: " + customer.Exciting);
        Debug.Log("Customer Humor: " + customer.Humor);
        Debug.Log("Customer Different: " + customer.Different);
        Debug.Log("Customer Regal: " + customer.Regal);
    }

    [ContextMenu("Update Customer")]
    protected void UpdateCustomer()
    {
        customerDisplay.UpdateUI(customer, itemDisplay.Item);
    }

    protected int RandomizeCustomerStat()
    {
        randomStat = Random.Range(0, MaxDesire);
        return randomStat;
    }
}
