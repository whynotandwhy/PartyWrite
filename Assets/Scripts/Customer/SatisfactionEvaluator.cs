using UnityEngine;

public class SatisfactionEvaluator
{
    protected ICustomerDesires _evaluatedCustomer;

    //Need to figure out how to pass the shopping cart over.Also this doesn't account for item value going over customer goal value
    public ICustomerDesires EvaluateCustomer(ICustomerDesires currentCustomer, CustomerCreator customerCreator, TestDetailedItemDisplay itemDisplay)
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


    protected float CompareValues(float customerValue, float cartValue)
    {
        return cartValue / customerValue;
    }
}
