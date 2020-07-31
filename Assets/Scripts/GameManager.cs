using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    //This script is in progress ***
    //It needs a "Ratings" panel to display data.


    [SerializeField] protected Image playerFace;
    [SerializeField] protected Sprite playerDefaultFace;
    [SerializeField] protected Sprite playerHappyFace;
    [SerializeField] protected Sprite playerUnsureFace;
    [SerializeField] protected Sprite playerExhaustedFace;

    [SerializeField] protected TMP_Text timerText;
    [SerializeField] protected float customerTimer;
    [SerializeField] protected GameObject ratingDisplay;
    [SerializeField] protected TMP_Text ratingDisplayText;

    protected Customer currentCustomer;
    protected CustomerCreator customerCreator;
    protected SatisfactionEvaluator satisfactionEvaluator;
    //protected DialogueTextUpdater textUpdater;
    protected int customersPerGame;
    protected int customersHelped;
    protected double[] roundRatings;
    protected double finalScore;
    protected float currentTime;
    protected bool activeCustomer = false;
    protected bool pausedGame = false;

    public bool PausedGame { set => pausedGame = value; }

    public static GameManager instance;

    protected void Awake()
    {
        #region Singleton
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject); //unity is stupid. Needs this to not implode
        instance = this;
        #endregion

        //textUpdater = FindObjectOfType<DialogueTextUpdater>();
    }

    protected void Start()
    {
        roundRatings = new double[customersPerGame];

        //StartCoroutine(IntroDialogue(introDialogue[0]));
    }

    protected void Update()
    {
        CountdownTimer();
    }

    private void CountdownTimer()
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0 && activeCustomer && !pausedGame)
        {
            CustomerExit();
        }
    }

    protected void CustomerExit()
    {
        //activeCustomer = false;
        //satisfactionEvaluator.DetermineFinalRating();
        //roundRatings[customersHelped] = satisfactionEvaluator.FinalGrade;
        //currentCustomer.CallCustomerExitCoroutine();

        //StartCoroutine(FarewellCutscene());
    }

    //Come back here for intro dialogue;
    //protected IEnumerator IntroDialogue(PlayerDialogueScriptableObject dialogue)
    //{
        //for (int i = 0; i < introDialogue.Length; i++)
        //{
        //    if (i == 1)
        //    {
        //        playerFace.sprite = playerExhaustedFace;
        //    }
        //    if (i == 2)
        //    {
        //        playerFace.sprite = playerDefaultFace;
        //    }
        //    yield return StartCoroutine(textUpdater.DisplayPlayerDialogue(introDialogue[i]));
        //}

        //StartNewRound();
    //}

    //protected IEnumerator FarewellCutscene()
    //{
    //    pausedGame = true;
    //    yield return StartCoroutine(textUpdater.DisplayPlayerDialogue(farewells[customersHelped]));
    //    StartCoroutine(RatingCutscene());
    //}

    //protected IEnumerator RatingCutscene()
    //{

    //    ratingDisplay.SetActive(true);
    //    ratingDisplayText.text = "Score: " + roundRatings[customersHelped];

    //    if (roundRatings[customersHelped] >= 75)
    //    {
    //        playerFace.sprite = playerHappyFace;
    //        yield return StartCoroutine(textUpdater.DisplayPlayerDialogue(greatRatingsResponses[customersHelped]));
    //    }
    //    if (roundRatings[customersHelped] < 75 && roundRatings[customersHelped] > 50)
    //    {
    //        playerFace.sprite = playerUnsureFace;
    //        yield return StartCoroutine(textUpdater.DisplayPlayerDialogue(mediocreRatingsResponses[customersHelped]));
    //    }
    //    if (roundRatings[customersHelped] <= 50)
    //    {
    //        playerFace.sprite = playerExhaustedFace;
    //        yield return StartCoroutine(textUpdater.DisplayPlayerDialogue(poorRatingsResponses[customersHelped]));
    //    }

    //    customersHelped++;

    //    if (customersHelped > customersPerGame)
    //    {
    //        playerFace.sprite = playerDefaultFace;
    //        StartNewRound();
    //    }
    //    else if (customersHelped <= customersPerGame)
    //    {
    //        //Fade out, load credits, display game scores + final score;
    //    }
    //}

    //protected void StartNewRound()
    //{
    //    //currentCustomer = customerCreator.CreateCustomer();
    //    //satisfactionEvaluator.InitCustomer(currentCustomer);
    //    activeCustomer = true;
    //    pausedGame = false;
    //    currentTime = customerTimer;
    //}
}
