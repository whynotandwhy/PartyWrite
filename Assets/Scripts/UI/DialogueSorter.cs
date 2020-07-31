using UnityEngine;

public class DialogueSorter : MonoBehaviour
{
    //Customer Dialogue
    [SerializeField] protected CustomerDialogueScriptableObject[] higherValueChoices;
    [SerializeField] protected CustomerDialogueScriptableObject[] lowerValueChoices;
    [SerializeField] protected CustomerDialogueScriptableObject perfectValueChoice;

    //Player Dialogue
    [SerializeField] protected PlayerDialogueScriptableObject introDialogue;
    [SerializeField] protected PlayerDialogueScriptableObject[] greetings;
    [SerializeField] protected PlayerDialogueScriptableObject[] farewells;
    [SerializeField] protected PlayerDialogueScriptableObject[] poorRatingsResponses;
    [SerializeField] protected PlayerDialogueScriptableObject[] mediocreRatingsResponses;
    [SerializeField] protected PlayerDialogueScriptableObject[] greatRatingsResponses;
    
    //UI Elements
    [SerializeField] protected DialogueDisplay dialogueBox;

    //Cached references
    [SerializeField] protected MiniGameplayLoop gameManager;
    [SerializeField] protected AvatarDisplayController avatarDisplayController;

    //State variables
    protected CustomerDialogueScriptableObject currentCustomerDialogue;
    protected PlayerDialogueScriptableObject currentPlayerDialogue;
    protected bool customerDialogueQueued = false;
    protected bool playerDialogueQueued = false;
    protected int playerDialogueIndex = 0;

    public bool GenerateCustomer { get; set; }
    public bool DialogueQueued { get => playerDialogueQueued; }

    
    public void DisplayCustomerDialogue(ICustomerDesires customer, ICustomerDesires itemDisplay)
    {

        var worstCategory = SatisfactionEvaluator.CustomerCategoryPriority(customer, itemDisplay);
        var worstCategoryValue = SatisfactionEvaluator.GetCategoryValue(worstCategory);

        currentCustomerDialogue = GetCustomerDialogue(worstCategory, worstCategoryValue);
        customerDialogueQueued = true;
    }

    public void DisplayPlayerHelloGoodbye(bool greeting)
    {
        avatarDisplayController.PlayerHappy();

        int i = Random.Range(0, 5);

        if (greeting)
            currentPlayerDialogue = greetings[i];
        else if(!greeting)
            currentPlayerDialogue = farewells[i];

        playerDialogueQueued = true;
    }

    public void DisplayPlayerRatingDialogue(float customerRating)
    {
        int i = Random.Range(0, 5);

        if(customerRating > .84)
        {
            avatarDisplayController.PlayerSmug();
            currentPlayerDialogue = greatRatingsResponses[i];
            playerDialogueQueued = true;
            return;
        }            

        if(customerRating > .69)
        {
            avatarDisplayController.PlayerNeutral();
            currentPlayerDialogue = mediocreRatingsResponses[i];
            playerDialogueQueued = true;
            return;
        }

        avatarDisplayController.PlayerSad();
        currentPlayerDialogue = poorRatingsResponses[i];
        playerDialogueQueued = true;
    }

    public void DisplayPlayerIntro()
    {
        currentPlayerDialogue = introDialogue;
        playerDialogueQueued = true;
    }


    protected void Awake()
    {
        if (gameManager == null)
            gameManager = FindObjectOfType<MiniGameplayLoop>();
        if (avatarDisplayController == null)
            avatarDisplayController = FindObjectOfType<AvatarDisplayController>();
    }

    protected void Update()
    {
        if(customerDialogueQueued)
        {
            DisplayDialogue(currentCustomerDialogue.dialogue);
            if (Input.anyKeyDown)
            {
                DisplayDialogue(string.Empty);
                customerDialogueQueued = false;
            }
        }

        if(playerDialogueQueued)
        {
            DisplayDialogue(currentPlayerDialogue.dialogue[playerDialogueIndex]);

            if(Input.anyKeyDown)
            {
                ++playerDialogueIndex;

                if(currentPlayerDialogue.dialogue.Length <= playerDialogueIndex)
                {
                    playerDialogueIndex = 0;
                    playerDialogueQueued = false;
                    DisplayDialogue(string.Empty);

                    if(GenerateCustomer)
                    {
                        gameManager.GenerateCustomer();
                        GenerateCustomer = false;
                    }

                    return;
                }

                DisplayDialogue(currentPlayerDialogue.dialogue[playerDialogueIndex]);
            }
        }        
    }

    private void DisplayDialogue(string dialogue) => dialogueBox.UpdateUI(dialogue);

    protected CustomerDialogueScriptableObject GetCustomerDialogue(int worstCategory, float categoryValue)
    {
        //Determines if the player's cart value is too high or low E.g. if customer
        //wants 5 and player has 3, 5/3 = 1.66 category rating. The function then loops
        //through the raiseValueChoices (raise 3 to 5) array looking for the matching
        //category, then returns that scriptable object. If customer wants 3 and player
        // has 5, 3/5 = .6, function does the same as before but using the lowerValueChoices.
        // If categoryValue == 1, it returns perfect.

        if (categoryValue > 1)
        {
            for (int i = 0; i < higherValueChoices.Length; i++)
            {
                if (worstCategory == (int)higherValueChoices[i].category)
                    return higherValueChoices[i];
            }                
        }

        else if (categoryValue < 1)
        {
            for (int i = 0; i < lowerValueChoices.Length; i++)
            {
                if (worstCategory == (int)lowerValueChoices[i].category)
                    return lowerValueChoices[i];
            }
        }

        return perfectValueChoice;
    }


}
