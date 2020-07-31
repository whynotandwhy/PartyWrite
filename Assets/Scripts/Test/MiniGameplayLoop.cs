using System;
using System.Linq;
using UnityEngine;

public class MiniGameplayLoop : MonoBehaviour
{
    //This would need to be exchanged for a shopping cart containing total values
    [Header("Reference Scripts")]
    [SerializeField] protected CustomerRatingDisplay customerRatingDisplay;
    [SerializeField] protected TestDetailedItemDisplay itemDisplay;
    [SerializeField] protected DialogueSorter dialogueSorter;
    [SerializeField] protected AvatarDisplayController avatarDisplayController;
    [SerializeField] protected WinPanelUpdater winPanel;
    [SerializeField] protected TimerUpdater timerUpdater;

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
        customerScores = new float[totalCustomerCount + 1];
        currentCustomerIndex = 0;
        currentCustomerTime = customerTimerMax;


        winPanel.UpdateUI(customerScores);

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
        if (winPanel == null)
            winPanel = FindObjectOfType<WinPanelUpdater>();
        if (timerUpdater == null)
            timerUpdater = FindObjectOfType<TimerUpdater>();
    }

    protected void Start()
    {
        currentCustomerTime = customerTimerMax;
        customerScores = new float[totalCustomerCount + 1];

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

        timerUpdater.UpdateUI(currentCustomerTime / customerTimerMax);

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
        if (customer == null)
            return;

        customerEvaluation = SatisfactionEvaluator.CalculateSatifaction(customer, cart);
        customerRatingDisplay.UpdateUI(customerEvaluation);
        dialogueSorter?.DisplayCustomerDialogue(customer, cart);
    }

    [ContextMenu("Evaluate Current Customer")]
    public void EvaluateCustomer()
    {
        if (customer == null)
            return;
        EvaluateCustomer(itemDisplay.Item);
    }

    protected void DisplayFinalScores()
    {
        var finalScore = 0f;
        foreach(float score in customerScores)
            finalScore += score;

        finalScore /= totalCustomerCount;

        customerScores[totalCustomerCount] = finalScore;

        winPanel.UpdateUI(customerScores);
    }
}
