using System;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public event Action OnGameStart;
    public event Action OnGameEnd;


    [SerializeField] 
    private Clicker _clicker;
    private ClickCounter _clickCounter;

    public static GameManager Instance { get; private set; }


    public void Awake()
    {
        if(!Instance.IsUnityNull() && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        _clickCounter = new ClickCounter();
        _clicker.enabled = false;
        _clicker.OnClick += OnClick;
    }

    private void OnDestroy()
    {
        _clicker.OnClick -= OnClick;
    }
    public void NewGame()
    {
        _clickCounter.Reset();
    }

    public void StartGame()
    {
        // if new game:
        if(!_clickCounter.IsInit)
        {
            NewGame();
        }


        _clicker.enabled = true;

        OnGameStart?.Invoke();
    }

    public void PauseGame()
    {
        _clicker.enabled = false;
        OnGameEnd?.Invoke();

    }

    private void OnClick()
    {
        _clickCounter.Increase(1);

        Debug.Log($"Current Counter: {_clickCounter.Count}");
    }
    
}
