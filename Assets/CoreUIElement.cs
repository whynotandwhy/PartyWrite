using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CoreUIElement<T> : MonoBehaviour
{
    public abstract void UpdateUI(T newData);
}
