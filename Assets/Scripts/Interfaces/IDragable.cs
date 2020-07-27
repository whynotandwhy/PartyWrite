﻿using UnityEngine;
using UnityEngine.EventSystems;

public interface IDraggable<T> : IDropHandler, IEndDragHandler, IDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    T DragItem { get; }
    Sprite DragIcon { get; }
    int Index { get; }
}

