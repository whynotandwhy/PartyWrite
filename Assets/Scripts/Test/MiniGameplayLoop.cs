using System;
using UnityEngine;

public class MiniGameplayLoop : MonoBehaviour
{
    //This would need to be exchanged for a shopping cart containing total values
    [SerializeField] protected CustomerDisplay customerDisplay;
    [SerializeField] protected TestDetailedItemDisplay itemDisplay;

    protected ICustomerDesires customer;
    protected ICustomerDesires customerEvaluation;

    protected ICustomerDesires _customer;
    protected ICustomerDesires _customerEvaluation;

    protected void Awake()
    {
        if (customerDisplay == null)
            customerDisplay = FindObjectOfType<CustomerDisplay>();
        if (itemDisplay == null)
            itemDisplay = FindObjectOfType<TestDetailedItemDisplay>();
    }

    [ContextMenu("Generate Customer")]
    protected void GenerateCustomer()
    {
        customer = CustomerCreator.GenerateCustomer(100f);
        EvaluateCustomer();
    }

    protected void EvaluateCustomer()
    {
        if (customer == null)
            throw new NotImplementedException("Customer has not been created.");

        customerEvaluation = SatisfactionEvaluator.CalculateSatifaction(customer, itemDisplay.Item);
        customerDisplay.UpdateUI(customerEvaluation);
    }    
}
