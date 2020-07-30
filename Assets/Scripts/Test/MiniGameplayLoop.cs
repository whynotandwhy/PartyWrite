using System;
using UnityEngine;

public class MiniGameplayLoop : MonoBehaviour
{
    //This would need to be exchanged for a shopping cart containing total values
    [Header("Reference Scripts")]
    [SerializeField] protected CustomerDisplay customerDisplay;
    [SerializeField] protected TestDetailedItemDisplay itemDisplay;
    [SerializeField] protected DialogueSorter dialogueSorter;

    [Header("Game Settings")][SerializeField] protected int totalCustomerCount = 2;
    [SerializeField] protected float customerTimerMax;

    protected ICustomerDesires customer;
    protected ICustomerDesires customerEvaluation;

    protected ICustomerDesires _customer;
    protected ICustomerDesires _customerEvaluation;

    protected float[] customerScores;
    protected int currentCustomerIndex = 0;
    protected float currentCustomerTime;
    protected bool countDownPaused = true;

    public bool PauseTimer { get => countDownPaused; set => countDownPaused = value; }
    public void ResetGame()
    {
        customerScores = new float[totalCustomerCount];
        currentCustomerIndex = 0;

        //Hide end panel;

        IntroDialogue();
        GenerateCustomer();       
    }

    protected void Awake()
    {
        if (customerDisplay == null)
            customerDisplay = FindObjectOfType<CustomerDisplay>();
        if (itemDisplay == null)
            itemDisplay = FindObjectOfType<TestDetailedItemDisplay>();
        if (dialogueSorter == null)
            dialogueSorter = FindObjectOfType<DialogueSorter>();
    }

    protected void Start()
    {
        customerScores = new float[totalCustomerCount];

        IntroDialogue();
        GenerateCustomer();
    }

    protected void Update()
    {
        if(!countDownPaused)
            CountDownTime();
    }

    protected void IntroDialogue()
    {

    }

    protected void CountDownTime()
    {
        //Need to display this somewhere
        currentCustomerTime = Mathf.Clamp(currentCustomerTime - Time.deltaTime, 0, customerTimerMax);

        if (currentCustomerTime <= 0f)
            GetCustomerFinalScore();
    }

    [ContextMenu("Get Final Score")]
    protected void GetCustomerFinalScore()
    {
        //farewell dialogue goes here.
        //Pauses the timer since the current customer is complete.
        countDownPaused = true;
        float score = SatisfactionEvaluator.CalculateFinalScore(customer, itemDisplay.Item);

        //Adds this score to the array
        customerScores[currentCustomerIndex] = score;
        

        Debug.Log("Final score: " + score);

        //If this is our final customer, get show the "end panel" and return
        if (currentCustomerIndex == totalCustomerCount - 1)
        {
            DisplayFinalScores();
            return;
        }

        //otherwise incremement and start a new customer.
        currentCustomerIndex++;
        GenerateCustomer();
    }

    [ContextMenu("Generate New Customer")]
    protected void GenerateCustomer()
    {
        //Greetings dialogue goes here.
        
        customer = CustomerCreator.GenerateCustomer(100f);
        
        currentCustomerTime = customerTimerMax;
        countDownPaused = false;
    }

    [ContextMenu("Evaluate Current Customer")]
    public void EvaluateCustomer()
    {
        if (customer == null)
            throw new NotImplementedException("Customer has not been created.");

        customerEvaluation = SatisfactionEvaluator.CalculateSatifaction(customer, itemDisplay.Item);
        customerDisplay.UpdateUI(customerEvaluation);
        dialogueSorter.DisplayCustomerDialogue(customer, itemDisplay.Item);
    }
    
    protected void DisplayFinalScores()
    {
        foreach(float score in customerScores)
        {
            Debug.Log("Score for customer: " + score);
        }
        //Maybe some kind of outro dialogue here

        //Either average our scores together in customerScores or display all of them individually on a panel
        //Could use CoreUIUpdater to create a "win" panel for this, too.
    }   
}
