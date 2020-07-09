using UnityEngine;


public class MenuSwitcher : MonoBehaviour
{
    [SerializeField] protected GameObject optionsMenu;
    [SerializeField] protected GameObject mainsMenu;

    protected bool optionsPanelEnabled = true;

    public void ToggleMenus()
    {
        optionsPanelEnabled = !optionsPanelEnabled;

        mainsMenu.SetActive(!optionsPanelEnabled);
        optionsMenu.SetActive(optionsPanelEnabled);
    }
}
