using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.EventSystems;

/// <summary>
/// Unique behavoir to Store
/// </summary>
public class Store : CoreManger
{
    [SerializeField] protected ShoppingCart Shopping;
    protected override void Start()
    {
        base.Start();
        if (Shopping == default)
            Shopping = FindObjectOfType<ShoppingCart>();
    }

    public override void OnDrop() => Shopping?.OnDrop();


    public override void HandleSlotDrop(PointerEventData eventData, Draggable dropped)
    {
        if (SharedDrag.SlotSource.Manager == this)
        {
            OnDrop();
            return;
        }
        if (SharedDrag.SlotSource.Manager is ShoppingCart)
        {
            SharedDrag.SlotSource.Subtract(SharedDrag.SlotSource.DragItem, 1);
            return;
        }
    }

}
