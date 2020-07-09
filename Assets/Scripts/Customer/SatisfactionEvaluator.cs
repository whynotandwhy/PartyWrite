using UnityEngine;
using System.Collections.Generic;

public interface GameScoring
{
    Customer CalculateSatifaction(ICustomerDesires goals, ICustomerDesires guess);
}


public class SatisfactionEvaluator : MonoBehaviour
{
    //Editor references
    [SerializeField] protected CustomerCreator customerCreator;

    //This should be the shopping cart
    [SerializeField] protected TestDetailedItemDisplay itemDisplay;

    protected Customer _evaluatedCustomer;


    public ICustomerDesires CalculateSatifaction
        (ICustomerDesires goals, IItem guess)
    {
        ICustomerDesires myguess = guess as ICustomerDesires;
        return customerCreator.GenerateCustomerComparison(
                CompareValues(goals.Exciting, guess.Exciting),
                CompareValues(goals.Humor, guess.Humor),
                CompareValues(goals.Different, guess.Different),
                CompareValues(goals.Regal, guess.Regal),
                goals.Cost - itemDisplay.Item.Cost
            );
    }

    public IItem SimplifyGuess(IEnumerable<IItem> guesses)
    {
        float cost = 0;
        foreach(IItem thing in guesses)
        {
            cost += thing.Cost;
        }
        return new Item(0, 0, 0, 0, cost, string.Empty, default, string.Empty, 0);
    }

    protected float CompareValues(float customerValue, float cartValue)
    {
        return cartValue / customerValue;
    }

    //Need to figure out how to pass the shopping cart over.Also this doesn't account for item value going over customer goal value
    public ICustomerDesires EvaluateCustomer(ICustomerDesires currentCustomer)
    {
        ICustomerDesires _evaluatedCustomer = 
            CalculateSatifaction(currentCustomer, itemDisplay.Item);
        return _evaluatedCustomer;
    }




    protected void Awake()
    {
        if (customerCreator == null)
            customerCreator = FindObjectOfType<CustomerCreator>();
    }



}
