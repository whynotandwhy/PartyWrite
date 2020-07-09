using System;
using UnityEngine;

public class MiniGameplayLoop : MonoBehaviour
{
    //This would need to be exchanged for a shopping cart containing total values
    [SerializeField] protected SatisfactionEvaluator evaluator;
    [SerializeField] protected CustomerCreator customerCreator;
    [SerializeField] protected CustomerDisplay customerDisplay;
    [SerializeField] protected TestDetailedItemDisplay itemDisplay;

    protected ICustomerDesires customer;
    protected ICustomerDesires customerEvaluation;

    protected void Awake()
    {
        if (customerDisplay == null)
            customerDisplay = FindObjectOfType<CustomerDisplay>();
        if (itemDisplay == null)
            itemDisplay = FindObjectOfType<TestDetailedItemDisplay>();
    }

    [ContextMenu("Generate Customer")]
    protected void Start()
    {
        customerCreator = new CustomerCreator();
        customer = customerCreator.GenerateCustomer(100f);
    }

    [ContextMenu("Compare Values")]
    protected void EvaluateCustomer()
    {
        if (customer == null)
            throw new NotImplementedException("Customer has not been created.");

        customerEvaluation = evaluator.EvaluateCustomer(customer, customerCreator, itemDisplay);
        customerDisplay.UpdateUI(customerEvaluation);
    }    
}
