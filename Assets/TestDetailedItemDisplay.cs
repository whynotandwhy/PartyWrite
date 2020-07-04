using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDetailedItemDisplay : DetailedItemDisplay
{
    [SerializeField] protected Item item = new Item();

    #region UI testing
    [ContextMenu("Reload from local")]
    public void Reload()
    {
        UpdateUI(item);
    }
    #endregion
}
