using UnityEngine;

[System.Serializable]
public class GameData
{
    public uint ClickCount;
    public uint CurrentMilestone;

    public GameData()
    {
        ClickCount = 0;
        CurrentMilestone = 0;
    }
}
