using UnityEngine;
using System.Collections.Generic;

public interface IGameScoring
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
        (ICustomerDesires goals, ICustomerDesires guess)
    {
        return CustomerCreator.GenerateCustomerComparison(
            CompareValues(goals.Exciting, guess.Exciting),
            CompareValues(goals.Humor, guess.Humor),
            CompareValues(goals.Different, guess.Different),
            CompareValues(goals.Regal, guess.Regal),
            goals.Cost - guess.Cost
        );
    }
    public static ICustomerDesires CalculateSatifaction
        (ICustomerDesires goals, IItem guess)
    {
        return CalculateSatifaction(goals, (ICustomerDesires)guess);
    }

    public static float CalculateFinalScore(ICustomerDesires goals, IItem guess)
    {
        float excitingRating = GetValueDifferential(goals.Exciting, guess.Exciting);
        float humorRating = GetValueDifferential(goals.Humor, guess.Humor);
        float differentRating = GetValueDifferential(goals.Different, guess.Different);
        float regalRating = GetValueDifferential(goals.Regal, guess.Regal);

        float costRating;
        if (guess.Cost < goals.Cost)
            costRating = 1.1f;
        else
        {
            costRating = GetValueDifferential(goals.Cost, guess.Cost);
        }        

        return (excitingRating + humorRating + differentRating + regalRating + costRating) / 5;
    }

    public static int CustomerCategoryPriority(ICustomerDesires customer, ICustomerDesires itemDisplay)
    {
        valueDifferentials = new float[5];
        valueDifferentials[0] = customer.Exciting / itemDisplay.Exciting;
        valueDifferentials[1] = customer.Humor / itemDisplay.Humor;
        valueDifferentials[2] = customer.Different / itemDisplay.Different;
        valueDifferentials[3] = customer.Regal / itemDisplay.Regal;
        valueDifferentials[4] = customer.Cost / itemDisplay.Cost;

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

        return 4;
    }
    public static int CustomerCategoryPriority(ICustomerDesires customer, IItem itemDisplay)
    {
        return CustomerCategoryPriority(customer, (ICustomerDesires)itemDisplay);
    }

    public static float GetCategoryValue(int category)
    {
        return valueDifferentials[category]; 
    }


    public static ICustomerDesires SimplifyGuess(IEnumerable<IItem> guesses)
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
        return CustomerCreator.GenerateCustomerComparison(excitement, humor, different, regal, cost);
    }


    protected static float CompareValues(float customerValue, float cartValue)
    {
        return cartValue / customerValue;
    }

    protected static float GetValueDifferential(float customerValue, float cartValue)
    {        
        if(customerValue < cartValue)
            return customerValue / cartValue;
        return cartValue / customerValue;
    }

}
