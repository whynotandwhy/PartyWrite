using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.EventSystems;

/// <summary>
/// Unique behavoir to shoppingCart
/// </summary>
public class ShoppingCart : CoreManger
{
    [SerializeField] protected MiniGameplayLoop gamePlay;
    public void ClearAll()
    {
        foreach (Draggable item in this.mySlots.Values)
            item.Set(default, 0);
    }
    protected void UpdateUI()
    {
        gamePlay.EvaluateCustomer(
            SatisfactionEvaluator.SimplifyGuess(this.mySlots.Values.Where(X=>X.DragItem != default && X.Count != 0).Select(X => X.DragItem))
        );
    }
    public override void OnDrop()
    {
        UpdateUI();
        base.OnDrop();
    }
}
