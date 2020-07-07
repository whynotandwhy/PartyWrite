using UnityEngine;

public class CustomerCreator : MonoBehaviour
{ 
    protected Customer _customer;
    protected int _randomStat;
    protected int _maxRandomStat = 16;

    
    public Customer GenerateCustomer(float startingIncome)
    {
        _customer =
            new Customer(
                        RandomizeCustomerStat(),
                        RandomizeCustomerStat(),
                        RandomizeCustomerStat(),
                        RandomizeCustomerStat(),
                        startingIncome);

        return _customer;
    }
    public Customer GenerateCustomerComparison(float exciting, float humor, float different, float regal, float cost)
    {
        return new Customer(exciting, humor, different, regal, cost);
    }

    protected int RandomizeCustomerStat() => _randomStat = Random.Range(1, _maxRandomStat);
}
