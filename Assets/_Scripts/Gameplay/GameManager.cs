using System;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour, IDataPersistence
{
    public event Action OnGameStart;
    public event Action OnGameEnd;
    public event Action OnMilestoneReached;
    public event Action OnHeightChanged
    {
        add { _clickCounter.OnCounterChanged += value; }
        remove { _clickCounter.OnCounterChanged -= value; }
    }
    [SerializeField] 
    private Clicker _clicker;
    private ClickCounter _clickCounter;

    [SerializeField] private int _heightMilestone;

    public int CurrentMilestone { get; private set; }
    public static GameManager Instance { get; private set; }
    public uint Height { get { return _clickCounter.Count * 10; } }
    public long CurrentHeightGoal { get { return (CurrentMilestone + 1) * HeightMilestone; } }

    public int HeightMilestone { get => _heightMilestone; private set => _heightMilestone = value; }

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
        DataPersistenceManager.Instance.NewGame();
    }

    private void Update()
    {
        if (Height >= CurrentHeightGoal)
        {
            Debug.Log("Milestone Reached");
            CurrentMilestone++;
            OnMilestoneReached?.Invoke();
        }
    }
    public void StartGame()
    {
        _clicker.enabled = true;
        CurrentMilestone = Mathf.FloorToInt(Height / HeightMilestone);
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

    public void LoadData(GameData data)
    {
        _clickCounter.SetCounter(data.ClickCount);
    }

    public void SaveData(ref GameData data)
    {
        data.ClickCount = _clickCounter.Count;
    }

    public float GetMilestoneProgress()
    {
        float t = Mathf.InverseLerp(CurrentHeightGoal - HeightMilestone, CurrentHeightGoal, Height);
        if (t == 1)
            return 0;
        return t;
    }
}
