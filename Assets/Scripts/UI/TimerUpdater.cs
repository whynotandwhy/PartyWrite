using UnityEngine;
using UnityEngine.UI;

public class TimerUpdater : CoreUIElement<float>
{
    [SerializeField] protected Image timerMeter;
    public override void UpdateUI(float primaryData)
    {
        if (ClearedIfEmpty(primaryData))
            return;
        timerMeter.fillAmount = primaryData;
    }

    protected override bool ClearedIfEmpty(float newData)
    {
        if (newData == 0)
            return true;
        return false;
    }
}
