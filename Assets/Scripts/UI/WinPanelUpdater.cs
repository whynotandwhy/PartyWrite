using UnityEngine;
using TMPro;

public class WinPanelUpdater : CoreUIElement<float[]>
{
    [SerializeField] protected GameObject winPanel;
    [SerializeField] protected TMP_Text customer1;
    [SerializeField] protected TMP_Text customer2;
    [SerializeField] protected TMP_Text customer3;
    [SerializeField] protected TMP_Text customer4;
    [SerializeField] protected TMP_Text customer5;
    [SerializeField] protected TMP_Text finalScore;

    public override void UpdateUI(float[] primaryData)
    {
        if (ClearedIfEmpty(primaryData))
            return;

        UpdateNumericText(customer1, "{0}", primaryData[0]);
        UpdateNumericText(customer2, "{0}", primaryData[1]);
        UpdateNumericText(customer3, "{0}", primaryData[2]);
        UpdateNumericText(customer4, "{0}", primaryData[3]);
        UpdateNumericText(customer5, "{0}", primaryData[4]);
        UpdateNumericText(finalScore, "{0}", primaryData[5]);
        winPanel.SetActive(true);
    }

    protected override bool ClearedIfEmpty(float[] newData)
    {
        if (newData[5] == 0)
        {
            UpdateNumericText(customer1, "{0}", 0f);
            UpdateNumericText(customer2, "{0}", 0f);
            UpdateNumericText(customer3, "{0}", 0f);
            UpdateNumericText(customer4, "{0}", 0f);
            UpdateNumericText(customer5, "{0}", 0f);
            UpdateNumericText(finalScore, "{0}", 0f);
            winPanel.SetActive(false);
            return true;
        }            
        return false;
    }
}
