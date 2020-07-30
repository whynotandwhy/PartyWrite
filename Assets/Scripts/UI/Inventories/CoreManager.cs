using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.EventSystems;



public class MyDragTracker : DragTracker<Draggable> { }

/// <summary>
/// CoreManager should handle all common code logic 
/// allowing all specialized behavore to be defined in extended classes
/// </summary>
public class CoreManger : DraggableManager<Draggable, IItem>
{
    [SerializeField] protected DetailedItemDisplay DetailedDisplay;

    public override void HandleHover(Draggable dropee, PointerEventData eventData)
    {
        if ((SharedDrag.SlotSource != default)||dropee == default||(dropee.Count == 0)||(dropee.DragItem == default))
            return;

        DetailedDisplay.UpdateUI((dropee==default)?default:dropee.DragItem);
    }

    /// <summary>
    /// called when a 
    /// </summary>
    /// <param name="eventData"></param>
    /// <param name="dropped"></param>
    public override void HandleSlotDrop(PointerEventData eventData, Draggable dropped)
    {
        int transferSize = 1;
        int newvalue = dropped.CanAdd(
            SharedDrag.SlotSource.DragItem,
            transferSize);

        if (newvalue <= 0)
        {
            //dropped needs to be added to first so that we don't loose ref to the IItem;
            dropped.Add(SharedDrag.SlotSource.DragItem, transferSize - newvalue);
            SharedDrag.SlotSource.Subtract(SharedDrag.SlotSource.DragItem, transferSize - newvalue);
        }
        else
        {
            Swap(SharedDrag.SlotSource, dropped);
        }

        OnDrop();
    }

    protected virtual void Swap(Draggable source, Draggable Destination)
    {
        int droppedcount = source.Count;
        IItem droppedItem = source.DragItem;
        source.Set(Destination.DragItem, Destination.Count);
        Destination.Set(droppedItem, droppedcount);
    }

    protected override Sprite SelectSprite(Draggable item)
    {
        return item.DragItem.Sprite;
    }

    protected override void InitDragObject()
    {
        if (SharedDrag != default)
            return;

        var mouseObject = new GameObject();
        SharedDrag = mouseObject.AddComponent<MyDragTracker>();
        SharedDrag.Rect = mouseObject.AddComponent<RectTransform>();
        if (DragSize == default)
            DragSize = new Vector2(32, 32);
        SharedDrag.Rect.sizeDelta = DragSize;
        SharedDrag.DragImage = mouseObject.AddComponent<Image>();
        SharedDrag.DragImage.raycastTarget = false;
    }
}