using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.EventSystems;

/// <summary>
/// CoreManager should handle all common code logic 
/// allowing all specialized behavore to be defined in extended classes
/// </summary>
public class CoreManger : DraggableManager<Draggable, IItem>
{
    [SerializeField] protected DetailedItemDisplay DetailedDisplay; 


    public override void HandleHover(Draggable dropee, PointerEventData eventData)
    {
        if (SharedDrag.gameObject.activeInHierarchy)
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
        throw new System.NotImplementedException();
    }

    protected virtual void Swap(Draggable source, Draggable Destination)
    {

    }

    protected override Sprite SelectSprite(Draggable item)
    {
        throw new System.NotImplementedException();
    }
}