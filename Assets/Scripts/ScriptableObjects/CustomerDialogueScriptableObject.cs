using UnityEngine;

public enum Category
{
    Exciting,
    Humor,
    Different,
    Regal,
    Cost,
    Perfect
}

[CreateAssetMenu(fileName = "CustomerData", menuName = "Customer Dialogue/DialogueScriptableObject")]
public class CustomerDialogueScriptableObject : ScriptableObject
{
    [TextArea(5, 10)]
    [SerializeField] public string dialogue;
    [SerializeField] public Category category;
}
