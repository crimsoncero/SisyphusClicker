using System;
using UnityEngine;

public class MainMenu : Menu
{

    [SerializeField] private OptionsMenu _options;
    [SerializeField] private CreditsMenu _credits;

    public void StartGame()
    {
        ButtonVibrate();
        ToggleActive(false);
        GameManager.Instance.StartGame();
        GameUI.Instance.gameObject.SetActive(true);
    }

    public void OpenOptions()
    {
        ButtonVibrate();
        OpenSubMenu(_options);
    }

    public void OpenCredits()
    {
        ButtonVibrate();
        OpenSubMenu(_credits);
    }
}
