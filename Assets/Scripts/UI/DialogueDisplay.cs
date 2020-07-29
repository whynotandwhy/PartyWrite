using System;
using UnityEngine;
using TMPro;

public class DialogueDisplay : CoreUIElement<string>
{
    [SerializeField] TMP_Text dialogueBox = default;
    [SerializeField] GameObject dialogueBoxObject = default;

    public override void UpdateUI(string primaryData)
    {
        if(ClearedIfEmpty(primaryData))
        {
            dialogueBoxObject.SetActive(true);
            UpdateText(dialogueBox, primaryData);
        }        
    }

    protected override bool ClearedIfEmpty(string newData)
    {
        if(newData == string.Empty)
        {
            UpdateText(dialogueBox, string.Empty);
            dialogueBoxObject.SetActive(false);
            return false;
        }

        return true;
    }
}
