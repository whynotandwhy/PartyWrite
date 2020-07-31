using UnityEngine;
using UnityEngine.EventSystems;


public class Draggable : CoreUIElement<Draggable>, ISlot<IItem>
{
    [SerializeField] protected bool RightClickClears = true;

    public void OnPointerClick(PointerEventData eventData)
    {
        if ((RightClickClears) && (eventData.button == PointerEventData.InputButton.Right))
        {
            Set(default, 0);
            Manager?.OnDrop();
        }
    }
    public void SetIndex(int index)
    {
        this.index = index;
    }


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

    protected CoreManger _Manager;
    public CoreManger Manager => _Manager;

    public void Start()
    {
        _Manager = GetComponentInParent<CoreManger>();
        if (_Manager == default)
            throw new System.InvalidOperationException("SlotData Has no manager");
        _Manager.RegisterSlot(this);
        this.UpdateUI(this);
    }

    public void OnDrag(PointerEventData eventData){_Manager.HandleDrag(eventData, this);}
    public void OnDrop(PointerEventData eventData) {_Manager.HandleSlotDrop(eventData, this);}
    public void OnEndDrag(PointerEventData eventData){_Manager.OnDrop();}
    public void OnPointerEnter(PointerEventData eventData) { _Manager.HandleHover(this, eventData); }
    public void OnPointerExit(PointerEventData eventData) { _Manager.HandleHover(default, eventData); }

    public void Add(IItem item, int count)
    {
        if (this.item == default)
        {
            Set(item, count);
            return;
        }
#pragma warning disable CS0253 // Possible unintended reference comparison; right hand side needs cast
        if (this.item != item)
#pragma warning restore CS0253 // Possible unintended reference comparison; right hand side needs cast
            throw new System.InvalidOperationException("adding mismatch");
        Set(this.item, this.count + count - AddRemainder(count));
    }

    public void Subtract(IItem item, int count)
    {
#pragma warning disable CS0253 // Possible unintended reference comparison; right hand side needs cast
        if ((this.item == default)||(this.item != item))
#pragma warning restore CS0253 // Possible unintended reference comparison; right hand side needs cast
            throw new System.InvalidOperationException("adding mismatch");
        Set(this.item,  this.count - count - SubtractRemainder(count));
    }

    protected int AddRemainder(int count){ return Mathf.Min(count, this.MaxCount - count);}
    public int CanAdd(IItem item, int count)
    {
        if (item == default)
            return count;

#pragma warning disable CS0253 // Possible unintended reference comparison; right hand side needs cast
        if ((this.item == default) || (this.item == item))
#pragma warning restore CS0253 // Possible unintended reference comparison; right hand side needs cast
            return AddRemainder(count);

        return count;
    }

    protected int SubtractRemainder(int count){return Mathf.Max(0,  count - this.count);}
    public int CanSubtract(IItem item, int count)
    {
        if (item == default)
            return count;

#pragma warning disable CS0253 // Possible unintended reference comparison; right hand side needs cast
        if ((this.item == default) || (this.item == item) || (this.count == 0))
#pragma warning restore CS0253 // Possible unintended reference comparison; right hand side needs cast
            return SubtractRemainder(count);

        return count;
    }

    public void Set(IItem item, int count)
    {
        this.item = item as Item;
        this.count = count;
        if (count == 0)
            this.item = default;
        UpdateUI(this);
    }

    public override void UpdateUI(Draggable primaryData)
    {
        if (ClearedIfEmpty(primaryData))
            return;

        icon.gameObject.SetActive(true);
        icon.sprite = primaryData.item.Sprite;
    }

    protected override bool ClearedIfEmpty(Draggable newData)
    {
        if ((newData.item != default)&&newData.count !=0)
            return false;

        icon.gameObject.SetActive(false);

        return true;
    }

    [SerializeField] protected UnityEngine.UI.Image icon;
}

