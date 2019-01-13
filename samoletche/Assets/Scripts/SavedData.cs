using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SavedData
{
    public uint NormalModeRecord = 0;
    public uint SurvivalModeRecord = 0;
    public string PlayerName = "";

    public SavedData()
    {
        this.NormalModeRecord = PlayerStats.NormalModeRecord;
        this.SurvivalModeRecord = PlayerStats.SurvivalModeRecord;
        this.PlayerName = PlayerStats.PlayerName;
    }
}
