using System;
using UnityEngine;

public class ClickCounter 
{
    public event Action OnCounterChanged;

    public uint Count { get; private set; }
    public bool IsInit { get; private set; } = false;
    public void Reset()
    {
        IsInit = true;
        Count = 0;
    }

    public void Increase(uint amount)
    {
        Count += amount;
        OnCounterChanged?.Invoke();

    }

    public void SetCounter(uint amount)
    {
        Count = amount;
    }
}
