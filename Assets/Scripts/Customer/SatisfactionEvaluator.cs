using UnityEngine;

public class SatisfactionEvaluator : MonoBehaviour
{
    //Editor references
    [SerializeField] protected CustomerCreator customerCreator;

    //This should be the shopping cart
    [SerializeField] protected TestDetailedItemDisplay itemDisplay;

    protected Customer _evaluatedCustomer;

    //Need to figure out how to pass the shopping cart over.Also this doesn't account for item value going over customer goal value
    public Customer EvaluateCustomer(Customer currentCustomer)
    {
        _evaluatedCustomer = customerCreator.GenerateCustomerComparison(
            CompareValues(currentCustomer.Exciting, itemDisplay.Item.Exciting),
            CompareValues(currentCustomer.Humor, itemDisplay.Item.Humor),
            CompareValues(currentCustomer.Different, itemDisplay.Item.Different),
            CompareValues(currentCustomer.Regal, itemDisplay.Item.Regal),
            currentCustomer.Cost - itemDisplay.Item.Cost
            );

        return _evaluatedCustomer;
    }

    protected void Awake()
    {
        if (customerCreator == null)
            customerCreator = FindObjectOfType<CustomerCreator>();
    }


    protected float CompareValues(float customerValue, float cartValue)
    {
        return cartValue / customerValue;
    }
}
