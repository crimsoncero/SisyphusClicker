using System;
using UnityEngine;

public class MainMenu : Menu
{
    public event Action OnStart;

    [SerializeField] private OptionsMenu _options;
    [SerializeField] private CreditsMenu _credits;

    public void StartGame()
    {
        OnStart?.Invoke();

        ToggleActive(false);
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
