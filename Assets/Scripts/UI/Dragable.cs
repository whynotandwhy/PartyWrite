using UnityEngine;
using UnityEngine.EventSystems;


public class Dragable : MonoBehaviour, IDraggable<IItem>
{
    protected Item _Item;
    public IItem DragItem => _Item;

    protected Sprite _DragIcon;
    public Sprite DragIcon => _DragIcon;

    protected int _Index;
    public int Index => _Index;

    protected DraggableManager<IDraggable<IItem>,IItem> _Manager;

    public void Start()
    {
        _Manager = GetComponentInParent<DraggableManager<IDraggable<IItem>, IItem>>();
        if (_Manager == default)
            throw new System.InvalidOperationException("SlotData Has no manager");
        _Manager.RegisterSlot(this);
    }

    public void OnDrag(PointerEventData eventData)
    {
        _Manager.HandleDrag(eventData);
    }

    public void OnDrop(PointerEventData eventData)
    {
        _Manager.HandleSlotDrop(eventData,this);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _Manager.OnDrop();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _Manager.HandleHover(this, eventData);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _Manager.HandleHover(default, eventData);
    }
}

