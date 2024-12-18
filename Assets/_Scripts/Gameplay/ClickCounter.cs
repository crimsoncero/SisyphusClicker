using UnityEngine;

public class ClickCounter
{
    public uint Current { get; private set; }

    public void Reset()
    {
        Current = 0;
    }

    public void Increase(uint amount)
    {
        Current += amount;
    }


}
