using System;
using Unity.VisualScripting;
using UnityEngine;
using Lofelt.NiceVibrations;
public class Menu : MonoBehaviour
{
    [SerializeField] private Menu _parentMenu;
    [SerializeField] private GameObject _menuGroup;

    public void ToggleActive(bool active)
    {
        _menuGroup.SetActive(active);
    }
    /// <summary>
    /// Closes the menu and then opens the parent menu, if no parent menu exists, just closes the menu
    /// </summary>
    public void Close()
    {
        if (!_parentMenu.IsUnityNull())
        {
            _parentMenu.ToggleActive(true);
        }

        this.ToggleActive(false);
    }

    protected void OpenSubMenu(Menu subMenu)
    {
        subMenu.ToggleActive(true);
        ToggleActive(false);
    }

    protected void ButtonVibrate()
    {
        HapticPatterns.PlayPreset(HapticPatterns.PresetType.Warning);
    }   
    
}
