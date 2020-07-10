using UnityEngine;


public class MenuSwitcher : MonoBehaviour
{
    [SerializeField] protected GameObject titleMenu;
    [SerializeField] protected GameObject optionsMenu;
    [SerializeField] protected GameObject gamePanel;


    protected bool optionsPanelEnabled = false;
    protected bool gameStarted = false;

    public void ToggleMenus()
    {
        optionsPanelEnabled = !optionsPanelEnabled;

        if(!gameStarted)
        {
            titleMenu.SetActive(!optionsPanelEnabled);
            optionsMenu.SetActive(optionsPanelEnabled);
        }
        else
        {
            gamePanel.SetActive(!optionsPanelEnabled);
            optionsMenu.SetActive(optionsPanelEnabled);

            Time.timeScale = optionsPanelEnabled ? 0f : 1f;
        }
    }

    public void EnableGamePanel()
    {
        gameStarted = !gameStarted;

        titleMenu.SetActive(!gameStarted);
        gamePanel.SetActive(gameStarted);
    }
}
