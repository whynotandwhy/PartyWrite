using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDetailedItemDisplay : DetailedItemDisplay
{
    [SerializeField] protected Item item = new Item();
    public IItem Item => item;

    #region UI testing
    [ContextMenu("Test Item Display")]
    public void Reload()
    {
        UpdateUI(item);
        Debug.Log("Item Excitement: " + item.Exciting);
        Debug.Log("Item Humor: " + item.Humor);
        Debug.Log("Item Different: " + item.Different);
        Debug.Log("Item Regal: " + item.Regal);
    }
    #endregion
}
