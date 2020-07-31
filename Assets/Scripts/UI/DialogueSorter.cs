using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTextUpdater : MonoBehaviour
{
    //Customer Dialogue
    [SerializeField] protected CustomerDialogueScriptableObject[] higherValueChoices;
    [SerializeField] protected CustomerDialogueScriptableObject[] lowerValueChoices;
    [SerializeField] protected CustomerDialogueScriptableObject perfectValueChoice;

    //Player Dialogue
    [SerializeField] protected PlayerDialogueScriptableObject[] introDialogue;
    [SerializeField] protected PlayerDialogueScriptableObject[] farewells;
    [SerializeField] protected PlayerDialogueScriptableObject[] poorRatingsResponses;
    [SerializeField] protected PlayerDialogueScriptableObject[] mediocreRatingsResponses;
    [SerializeField] protected PlayerDialogueScriptableObject[] greatRatingsResponses;
    
    //UI Elements
    [SerializeField] protected DialogueDisplay dialogueBox;

    //Cached references
    [SerializeField] protected GameManager gameManager;

    //State variables
    protected CustomerDialogueScriptableObject currentDialogue;
    protected int currentDialogueIndex = 0;
    protected bool dialogueQueued = false;


    public void DisplayCustomerDialogue(ICustomerDesires customer, ICustomerDesires itemDisplay)
    {
        var worstCategory = SatisfactionEvaluator.CustomerCategoryPriority(customer, itemDisplay);
        var worstCategoryValue = SatisfactionEvaluator.GetCategoryValue(worstCategory);

        currentDialogue = GetCustomerDialogue(worstCategory, worstCategoryValue);
        currentDialogueIndex = 0;
        dialogueQueued = true;
    }

    public void DisplayCustomerDialogue(ICustomerDesires customer, IItem itemDisplay)
    {

        var worstCategory = SatisfactionEvaluator.CustomerCategoryPriority(customer, itemDisplay);
        var worstCategoryValue = SatisfactionEvaluator.GetCategoryValue(worstCategory);

        currentDialogue = GetCustomerDialogue(worstCategory, worstCategoryValue);
        currentDialogueIndex = 0;
        dialogueQueued = true;
    }

    protected void Awake()
    {
        if (gameManager == null)
            gameManager = FindObjectOfType<GameManager>();
    }

    protected void Update()
    {
        if(dialogueQueued)
        {
            DisplayDialogue(currentDialogue);
        }
    }

    private void DisplayDialogue(CustomerDialogueScriptableObject dialogue)
    {
        dialogueBox.UpdateUI(dialogue.dialogue);
    }

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
