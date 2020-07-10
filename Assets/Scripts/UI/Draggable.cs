using UnityEngine;
using UnityEngine.EventSystems;


public class Draggable : MonoBehaviour, ISlot<IItem>
{
    [SerializeField] protected Item item;
    public IItem DragItem => item;

    protected Sprite dragIcon;
    public Sprite DragIcon => dragIcon;

    [SerializeField] protected int index;
    public int Index => index;

    [SerializeField] protected int count;
    public int Count => count;

    [SerializeField] protected int maxCount;
    public int MaxCount => maxCount;

    protected DraggableManager<IDraggable<IItem>, IItem> _Manager;

    public void Start()
    {
        _Manager = GetComponentInParent<DraggableManager<IDraggable<IItem>, IItem>>();
        if (_Manager == default)
            throw new System.InvalidOperationException("SlotData Has no manager");
        _Manager.RegisterSlot(this);
    }

    public void OnDrag(PointerEventData eventData)
    {
        _Manager.HandleDrag(eventData, this);
    }

    public void OnDrop(PointerEventData eventData)
    {
        _Manager.HandleSlotDrop(eventData, this);
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

    public void Add(IItem item, int count)
    {
        if (this.item == default)
        {
            Set(item, count);
            return;
        }
        if (this.item != item)
            throw new System.InvalidOperationException("adding mismatch");
        this.count += count - AddRemainder(count);
    }

    public void Subtract(IItem item, int count)
    {
        if ((this.item == default)||(this.item != item))
            throw new System.InvalidOperationException("adding mismatch");
        this.count -=  count - SubtractRemainder(count);
    }

    protected int AddRemainder(int count)
    {
        return Mathf.Min(count, this.MaxCount - count);
    }

    public int CanAdd(IItem item, int count)
    {
        if (item == default)
            return count;

        if ((this.item == default) || (this.item == item))
            return AddRemainder(count);

        return count;
    }

    protected int SubtractRemainder(int count)
    {
        return Mathf.Max(0,  count - this.count);
    }

    public int CanSubtract(IItem item, int count)
    {
        if (item == default)
            return count;

        if ((this.item == default) || (this.item == item))
            return SubtractRemainder(count) ;

        return count;
    }

    public void Set(IItem item, int count)
    {
        this.item = item as Item;
        this.count = count;
    }
}

