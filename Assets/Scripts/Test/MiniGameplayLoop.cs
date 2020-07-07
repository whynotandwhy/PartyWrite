using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameplayLoop : MonoBehaviour
{
    //This would need to be exchanged for a shopping cart containing total values
    [SerializeField] protected SatisfactionEvaluator evaluator;
    [SerializeField] protected CustomerCreator customerCreator;
    [SerializeField] protected CustomerDisplay customerDisplay;

    protected Customer _customer;
    protected Customer _customerEvaluation;

    protected void Awake()
    {
        if (evaluator == null)
            evaluator = FindObjectOfType<SatisfactionEvaluator>();
        if (customerCreator == null)
            customerCreator = FindObjectOfType<CustomerCreator>();
        if (customerDisplay == null)
            customerDisplay = FindObjectOfType<CustomerDisplay>();
    }

    [ContextMenu("Generate Customer")]
    protected void Start()
    {
        _customer = customerCreator.GenerateCustomer(100f);
        customerDisplay.InitCustomer(_customer);
    }

    [ContextMenu("Compare Values")]
    protected void EvaluateCustomer()
    {
        if (_customer == null)
            throw new NotImplementedException("Customer has not been created.");

        _customerEvaluation = evaluator.EvaluateCustomer(_customer);
        customerDisplay.UpdateUI(_customerEvaluation);
    }    
}
