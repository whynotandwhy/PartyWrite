using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Accuracy1 : CoreUIElement<float>
{
    [SerializeField][Range(-1,1)] protected float Value;

    [ContextMenu("Doit")]
    protected void Testing() { UpdateUI(Value); }

    [SerializeField] protected Image Displayer;
    [SerializeField] protected Color Above;
    [SerializeField] protected Color Below;

    public override void UpdateUI(float primaryData)
    {
        bool wasNegative = primaryData < 0;

        Displayer.fillAmount = Mathf.Abs(primaryData);
        Displayer.fillOrigin = (wasNegative)? ((int)Image.OriginHorizontal.Left):
            ((int)Image.OriginHorizontal.Right);
        Displayer.color = (wasNegative) ? Below : Above;

        bool something = !wasNegative;
    }

    protected override bool ClearedIfEmpty(float newData)
    {
        //juse in case you wanted to be able to call it
        return false;
    }
}
