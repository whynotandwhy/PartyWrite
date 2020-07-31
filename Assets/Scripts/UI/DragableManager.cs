using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.EventSystems;


public abstract class DraggableManager<TDraggable,TItem> : MonoBehaviour 
    where TDraggable : IDraggable<TItem>
{
    /// <summary>
    /// shares Drag object to be read and used
    /// slight optimization, unsure if changing the TDraggable will
    /// create new DragTracker, to be reviewed in future.
    /// </summary>
    protected static DragTracker<TDraggable> SharedDrag;
    protected static Transform DragTrackerParent;

    [SerializeField] protected Vector2 DragSize;
    /// <summary>
    /// This function must be implemented to get the selected sprite
    /// for the specific TItem
    /// </summary>
    /// <param name="item">item passed into dragstart</param>
    /// <returns>drag sprite</returns>
    protected abstract Sprite SelectSprite(TDraggable item);


    public IEnumerable<TItem> CurrentItems => mySlots.Values.Select(X=>X.DragItem);
    #region Summary
    /// <summary>
    /// contains all the slot data for the manager, the key being the index of the slot
    /// so a "next" previous logic can be maintained/observed.
    /// </summary>
    #endregion
    protected Dictionary<int, TDraggable> mySlots = new Dictionary<int, TDraggable>();

    #region Summary
    /// <summary>
    /// Adds a new slote to the SlotManager to handle
    /// </summary>
    /// <param name="slot"></param>
    #endregion
    public virtual void RegisterSlot(TDraggable slot)
    {
        /*Changed this from default to null because compiler doesn't know if the type can be default, but it can be null.*/
        if (slot == null)
            return;
        mySlots.Add(slot.Index, slot);
    }

    public abstract void HandleSlotDrop(PointerEventData eventData, TDraggable dropped);

    /// <summary>
    /// how to handle when an object is droped on an invalid slot
    /// </summary>
    public virtual void OnDrop()
    {
        SharedDrag.SlotSource = default;
        SharedDrag.eventData = default;
        SharedDrag.gameObject.SetActive(false);
    }

    public abstract void HandleHover(TDraggable dropee, PointerEventData eventData);

    protected virtual void Awake(){InitDragObject();}
    protected abstract void InitDragObject();

    protected virtual void Start(){InitDragParentage();}

    protected virtual void InitDragParentage()
    {
        if (DragTrackerParent != default)
        {
            Debug.Log(string.Format("{0} did not set parentage", gameObject.name));
            return;
        }
        DragTrackerParent = transform.parent;
        SharedDrag.transform.SetParent(DragTrackerParent);
        SharedDrag.transform.SetAsLastSibling();
    }

    protected void HandleDragStart(PointerEventData eventData, TDraggable slot)
    {
        //what do we do when we start dragging,
        SharedDrag.gameObject.SetActive(true);
        SharedDrag.eventData = eventData;
        SharedDrag.SlotSource = slot;
        SharedDrag.DragImage.sprite = SelectSprite(slot);
    }

    public void HandleDrag(PointerEventData eventData, TDraggable slot)
    {
        //Make a new drag item if needed.
        if (SharedDrag.eventData == default || SharedDrag.eventData.pointerDrag != eventData.pointerDrag)
        {
            HandleDragStart(eventData, slot);
        }

        //Make thing follow pointer
        SharedDrag.Rect.position = Input.mousePosition;
    }


}

