using UnityEngine;

public class CustomerCreator 
{ 
    protected static ICustomerDesires customer;
    protected static int randomStat;
    protected static int maxRandomStat = 16;

    
    public static ICustomerDesires GenerateCustomer(float startingIncome)
    {
        customer =
            new Customer(
                        RandomizeCustomerStat(),
                        RandomizeCustomerStat(),
                        RandomizeCustomerStat(),
                        RandomizeCustomerStat(),
                        startingIncome);

        return customer;
    }

    public static ICustomerDesires GenerateCustomerComparison(float exciting, float humor, float different, float regal, float cost)
    {
        return new Customer(exciting, humor, different, regal, cost);
    }

    protected static int RandomizeCustomerStat() => randomStat = Random.Range(1, maxRandomStat);
}
