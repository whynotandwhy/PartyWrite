using System;
using UnityEngine;

public class MiniGameplayLoop : MonoBehaviour
{
    //This would need to be exchanged for a shopping cart containing total values
    [Header("Reference Scripts")]
    [SerializeField] protected CustomerRatingDisplay customerRatingDisplay;
    [SerializeField] protected TestDetailedItemDisplay itemDisplay;
    [SerializeField] protected DialogueSorter dialogueSorter;
    [SerializeField] protected AvatarDisplayController avatarDisplayController;

    [Header("Game Settings")] [SerializeField] protected int totalCustomerCount = 2;
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

        dialogueSorter.GenerateCustomer = true;
        dialogueSorter.DisplayPlayerIntro();
    }

    [ContextMenu("Generate New Customer")]
    public void GenerateCustomer()
    {
        dialogueSorter.DisplayPlayerHelloGoodbye(true);

        customer = CustomerCreator.GenerateCustomer();
        avatarDisplayController.GenerateRandomCustomer();

        currentCustomerTime = customerTimerMax;
        countDownPaused = false;
    }

    protected void Awake()
    {
        if (customerRatingDisplay == null)
            customerRatingDisplay = FindObjectOfType<CustomerRatingDisplay>();
        if (itemDisplay == null)
            itemDisplay = FindObjectOfType<TestDetailedItemDisplay>();
        if (dialogueSorter == null)
            dialogueSorter = FindObjectOfType<DialogueSorter>();
        if (avatarDisplayController == null)
            avatarDisplayController = FindObjectOfType<AvatarDisplayController>();
    }

    protected void Start()
    {
        customerScores = new float[totalCustomerCount];
        dialogueSorter.GenerateCustomer = true;
        dialogueSorter.DisplayPlayerIntro();
    }

    protected void Update()
    {
        if (!countDownPaused)
            CountDownTime();
        else if (countDownPaused && !dialogueSorter.DialogueQueued)
            GetCustomerFinalScore();
    }

    protected void CountDownTime()
    {
        //Need to display this somewhere
        currentCustomerTime = Mathf.Clamp(currentCustomerTime - Time.deltaTime, 0, customerTimerMax);

        if (currentCustomerTime <= 0f)
        {
            avatarDisplayController.FadeIn = false;
            dialogueSorter.DisplayPlayerHelloGoodbye(false);

            countDownPaused = true;
        }

    }

    [ContextMenu("Get Final Score")]
    protected void GetCustomerFinalScore()
    {
        float score = SatisfactionEvaluator.CalculateFinalScore(customer, itemDisplay.Item);
        customerScores[currentCustomerIndex] = score;

        Debug.Log("Final score: " + score);

        if (currentCustomerIndex == totalCustomerCount - 1)
        {
            DisplayFinalScores();
            return;
        }

        currentCustomerIndex++;
        dialogueSorter.GenerateCustomer = true;
        dialogueSorter.DisplayPlayerRatingDialogue(score);
    }

    public void EvaluateCustomer(ICustomerDesires cart)
    {
        customerEvaluation = SatisfactionEvaluator.CalculateSatifaction(customer, cart);
        customerRatingDisplay.UpdateUI(customerEvaluation);
        dialogueSorter?.DisplayCustomerDialogue(customer, cart);
    }

    [ContextMenu("Evaluate Current Customer")]
    public void EvaluateCustomer()
    {
        if (customer == null)
            throw new NotImplementedException("Customer has not been created.");

        EvaluateCustomer(itemDisplay.Item);
    }

    protected void DisplayFinalScores()
    {
        foreach (float score in customerScores)
        {
            Debug.Log("Score for customer: " + score);
        }
        //Maybe some kind of outro dialogue here

        //Either average our scores together in customerScores or display all of them individually on a panel
        //Could use CoreUIUpdater to create a "win" panel for this, too.
    }
}
