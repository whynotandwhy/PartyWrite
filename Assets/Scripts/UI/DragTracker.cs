using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// stores info of items being dragged between slots
/// there will only be ever one of these shared between 
/// Dragable managers with the ___ signature
/// </summary>
public class DragTracker<T> : MonoBehaviour
{
    /// <summary>
    /// source Data
    /// </summary>
    public PointerEventData eventData;
    /// <summary>
    /// the image that will be displayed
    /// </summary>
    public Image DragImage;
    /// <summary>
    /// the size of the dragObject
    /// </summary>
    public RectTransform Rect;
    /// <summary>
    /// The associated data 
    /// </summary>
    public T SlotSource;
    /// <summary>
    /// Origin of popup
    /// </summary>
    public Vector2 StartingPosition;
}
