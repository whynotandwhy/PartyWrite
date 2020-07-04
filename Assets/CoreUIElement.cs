using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public abstract class CoreUIElement<T> : MonoBehaviour
{
    public abstract void UpdateUI(T newData);
    protected abstract bool ClearedIfEmpty(T newData);


    protected void UpdateText(string text, Text target) { target.text = text; }
    protected void UpdateNumericText(string textformatting, float value, Text target) { UpdateText(string.Format(textformatting, value), target); }
    protected void SetPercentage(Image target, float percent) { target.fillAmount = percent; } 
}
