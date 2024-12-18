using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private MainMenu _mainMenu;

    private void Start()
    {
        _mainMenu.ToggleActive(true);
    }
}
