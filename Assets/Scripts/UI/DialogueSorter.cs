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



    public void DisplayCustomerDialogue(ICustomerDesires customer)
    {

        var worstCategory = SatisfactionEvaluator.CustomerCategoryPriority(customer);
        var worstCategoryValue = SatisfactionEvaluator.GetCategoryValue(worstCategory);

        GetCustomerDialogue(worstCategory, worstCategoryValue);
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

    protected void Awake()
    {
        //evaluator = FindObjectOfType<SatisfactionEvaluator>();
        //gameManager = FindObjectOfType<GameManager>();
    }

    protected IEnumerator DisplayCustomerDialogue(CustomerDialogueScriptableObject textToDisplay)
    {
        print("Opening dialogue box.");
        //gameManager.PausedGame = true;
        OpenDialogueBox(customerDialogueBox, customerDialogueText);

        customerDialogueText.text = textToDisplay.dialogue;

        yield return StartCoroutine(WaitForKeyPress());

        print("Closing dialogue box.");

        CloseDialogueBox(customerDialogueBox, customerDialogueText);
        //gameManager.PausedGame = false;
    }

    protected IEnumerator WaitForKeyPress()
    {
        bool notPressed = true;

        while (notPressed)
        {
            if (Input.anyKeyDown)
            {
                notPressed = false;
            }
            yield return null;
        }
    }

    public IEnumerator DisplayPlayerDialogue(PlayerDialogueScriptableObject textToDisplay)
    {

        OpenDialogueBox(playerDialogueBox, playerDialogueText);
        int t = textToDisplay.dialogue.Length;

        for (int i = 0; i < t; i++)
        {
            playerDialogueText.text = textToDisplay.dialogue[i];

            yield return StartCoroutine(WaitForKeyPress());
        }

        CloseDialogueBox(playerDialogueBox, playerDialogueText);
    }

    protected void OpenDialogueBox(Image dialogueBox, Text dialogueText)
    {
        dialogueText.text = "";
        dialogueBox.gameObject.SetActive(true);
        dialogueText.gameObject.SetActive(true);
    }

    protected void CloseDialogueBox(Image dialogueBox, Text dialogueText)
    {
        dialogueText.text = "";
        dialogueBox.gameObject.SetActive(false);
        dialogueText.gameObject.SetActive(false);
    }

}
