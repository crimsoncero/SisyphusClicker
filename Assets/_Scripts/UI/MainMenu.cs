using System;
using UnityEngine;

public class MainMenu : Menu
{

    [SerializeField] private OptionsMenu _options;
    [SerializeField] private CreditsMenu _credits;

    public void StartGame()
    {
        ToggleActive(false);
        GameManager.Instance.StartGame();
        GameUI.Instance.gameObject.SetActive(true);
    }

    public void OpenOptions()
    {
        OpenSubMenu(_options);
    }

    public void OpenCredits()
    {
        OpenSubMenu(_credits);
    }
}
