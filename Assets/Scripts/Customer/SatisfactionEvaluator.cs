using UnityEngine;
using System.Collections.Generic;

public interface GameScoring
{
    Customer CalculateSatifaction(ICustomerDesires goals, ICustomerDesires guess);
}


public class SatisfactionEvaluator
{
    protected static float[] valueDifferentials;
    protected static float highestValue;
    protected static float lowestValue;
    protected static int highestCategory;
    protected static int lowestCategory;


    public static ICustomerDesires CalculateSatifaction
        (ICustomerDesires goals, IItem guess)
    {
        return CustomerCreator.GenerateCustomerComparison(
                CompareValues(goals.Exciting, guess.Exciting),
                CompareValues(goals.Humor, guess.Humor),
                CompareValues(goals.Different, guess.Different),
                CompareValues(goals.Regal, guess.Regal),
                goals.Cost - guess.Cost
            );
    }

    public static int CustomerCategoryPriority(ICustomerDesires customer)
    {
        valueDifferentials = new float[5];
        valueDifferentials[0] = customer.Exciting;
        valueDifferentials[1] = customer.Humor;
        valueDifferentials[2] = customer.Different;
        valueDifferentials[3] = customer.Regal;
        valueDifferentials[4] = customer.Cost;

        highestValue = valueDifferentials[0];
        lowestValue = valueDifferentials[0];

        for (var i = 0; i < valueDifferentials.Length; i++)
        {
            if (highestValue < valueDifferentials[i] && valueDifferentials[i] > 1)
            {
                highestValue = valueDifferentials[i];
                highestCategory = i;
            }
        }

        for (var i = 0; i < valueDifferentials.Length; i++)
        {
            if (lowestValue > valueDifferentials[i] && valueDifferentials[i] < 1)
            {
                lowestValue = valueDifferentials[i];
                lowestCategory = i;
            }
        }

        if (highestValue > 1)
            return highestCategory;

        else if (highestValue <= 1 && lowestValue < 1)
            return lowestCategory;

            return 5;
    }

    public static float GetCategoryValue(int category)
    {
        return valueDifferentials[category]; 
    }


    public static IItem SimplifyGuess(IEnumerable<IItem> guesses)
    {
        float excitement = 0;
        float humor = 0;
        float different = 0;
        float regal = 0;
        float cost = 0;
        foreach(IItem thing in guesses)
        {
            excitement += thing.Exciting;
            humor += thing.Humor;
            different += thing.Different;
            regal += thing.Regal;
            cost += thing.Cost;
        }
        return new Item(excitement, humor, different, regal, cost, string.Empty, default, string.Empty, 0);
    }

    protected static float CompareValues(float customerValue, float cartValue)
    {
        return cartValue / customerValue;
    }

}
