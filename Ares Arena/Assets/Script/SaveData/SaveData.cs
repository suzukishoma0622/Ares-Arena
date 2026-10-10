using UnityEngine;
[System.Serializable]
public class SaveData
{
    public int[] MaxCrown = new int[30];
    public int[] SaintCrown = new int[30];
    public int SaintUnlock;
    public int[] GemUnlock = new int[300];
    public int[] BlessUnlock = new int[150];

    public bool FirstLoad;
}
