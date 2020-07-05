using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public abstract class CoreUIElement<T> : MonoBehaviour
{
    public abstract void UpdateUI(T newData);
    protected abstract bool ClearedIfEmpty(T newData);


    protected void UpdateText(Text target, string text) { target.text = text; }
    protected void UpdateSprite(Image image, Sprite sprite) { image.sprite = sprite; }
    protected void UpdateNumericText(Text target, string textformatting, float value) { UpdateText(target, string.Format(textformatting, value)); }
    protected void SetPercentage(Image target, float percent) { target.fillAmount = percent; }
}
