using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Player Dialogue/DialogueScriptableObject")]
public class PlayerDialogueScriptableObject : ScriptableObject
{
    [TextArea(5, 10)]
    [SerializeField] public string[] dialogue;
}

