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
    public override void HandleHover(Draggable dropee, PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public override void HandleSlotDrop(PointerEventData eventData, Draggable dropped)
    {
        throw new System.NotImplementedException();
    }

    protected override Sprite SelectSprite(IItem item)
    {
        throw new System.NotImplementedException();
    }
}