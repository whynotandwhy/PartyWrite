using UnityEngine;


public class MenuSwitcher : MonoBehaviour
{
    [SerializeField] protected GameObject titleMenu;
    [SerializeField] protected GameObject optionsMenu;
    [SerializeField] protected GameObject gamePanel;


    protected bool optionsPanelEnabled = false;
    protected bool gameStarted = false;

    public void ToggleOptionsMenus()
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

    public void ToggleGamePanel()
    {
        gameStarted = !gameStarted;

        titleMenu.SetActive(!gameStarted);
        gamePanel.SetActive(gameStarted);

        if (gameStarted)
            AudioManager.instance.PlayShopSong();
        else
            AudioManager.instance.PlayTitleSong();
    }
}
