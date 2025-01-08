using UnityEngine;

public class UIManager : MonoBehaviour
{
    

    [SerializeField] private MainMenu _mainMenu;
    [SerializeField] private GameUI _gameUI;


    private void Awake()
    {
        GameManager.Instance.OnGameStart += EnableGameUI;
        GameManager.Instance.OnGameEnd += DisableGameUI;

    }

    private void OnDestroy()
    {
        GameManager.Instance.OnGameStart -= EnableGameUI;
        GameManager.Instance.OnGameEnd -= DisableGameUI;
    }
    private void Start()
    {
        DisableGameUI();
        _mainMenu.ToggleActive(true);
    }


    private void EnableGameUI()
    {
        _gameUI.gameObject.SetActive(true);
    }
    private void DisableGameUI()
    {
        _gameUI.gameObject.SetActive(false);
    }
}
