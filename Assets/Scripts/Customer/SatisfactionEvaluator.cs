using UnityEngine;
using System.Collections.Generic;

public interface GameScoring
{
    Customer CalculateSatifaction(ICustomerDesires goals, ICustomerDesires guess);
}


public class SatisfactionEvaluator
{
    protected Customer evaluatedCustomer;


    public static ICustomerDesires CalculateSatifaction
        (ICustomerDesires goals, IItem guess)
    {
        ICustomerDesires myguess = guess as ICustomerDesires;
        return CustomerCreator.GenerateCustomerComparison(
                CompareValues(goals.Exciting, guess.Exciting),
                CompareValues(goals.Humor, guess.Humor),
                CompareValues(goals.Different, guess.Different),
                CompareValues(goals.Regal, guess.Regal),
                goals.Cost - guess.Cost
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

    protected static float CompareValues(float customerValue, float cartValue)
    {
        return cartValue / customerValue;
    }

}
