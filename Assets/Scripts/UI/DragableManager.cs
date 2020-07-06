using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.EventSystems;


public class DraggableManager<TDraggable,TItem> 
    where TDraggable : IDraggable<TItem>
{

    public IEnumerable<TItem> CurrentItems => _mySlots.Values.Select(X=>X.DragItem);
    /// <summary>
    /// contains all the slot data for the manager, the key being the index of the slot
    /// so a "next" previous logic can be maintained/observed.
    /// </summary>
    protected Dictionary<int, TDraggable> _mySlots = new Dictionary<int, TDraggable>();

    /// <summary>
    /// Adds a new slote to the SlotManager to handle
    /// </summary>
    /// <param name="slot"></param>
    public virtual void RegisterSlot(TDraggable slot)
    {
        if (slot == default)
            return;
        _mySlots.Add(slot.Index, slot);
    }

    public virtual void HandleSlotDrop(PointerEventData eventData, TDraggable dropped)
    {
        //TODO: what happens when an item is dropped on this inventory

        OnDrop();
    }

    public virtual void OnDrop()
    {
        //TODO hide the draggging Visualations
    }

    public void HandleHover(TDraggable dropee, PointerEventData eventData)
    {
        //what happens when you mouse over an object in our inventory
        //dropee will be null if your not over something
    }


    protected void HandleDragStart(PointerEventData eventData)
    {
        //what do we do when we start dragging,

        //CommonMountPointer.transform.SetParent(transform.parent.parent);
        //CommonMountPointer.transform.SetAsLastSibling();
        //CommonMountPointer.gameObject.SetActive(true);
        //CommonMountPointer.eventData = eventData;
        //CommonMountPointer.DragImage.sprite = eventData.pointerDrag.GetComponentInChildren<VisableSlot>().Tracker.Item.DisplayImage;
    }

    public void HandleDrag(PointerEventData eventData)
    {
        //Make a new drag item if needed.
        //if (CommonMountPointer.eventData == default || CommonMountPointer.eventData.pointerDrag != eventData.pointerDrag)
        //{
        //    HandleDragStart(eventData);
        //}

        //Make thing follow pointer
        //CommonMountPointer.Rect.position = Input.mousePosition;
    }


}

