using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : ICustomerDesires
{
    [SerializeField] protected float _Exciting;
    [SerializeField] protected float _Humor;
    [SerializeField] protected float _Different;
    [SerializeField] protected float _Regal;
    [SerializeField] protected float _Cost;

    public float Exciting => _Exciting;
    public float Humor => _Humor;
    public float Different => _Different;
    public float Regal => _Regal;
    public float Cost => _Cost;
}