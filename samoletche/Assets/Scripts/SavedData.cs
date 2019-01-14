using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SavedData
{
    public uint ClassicModeRecord = 0;
    public uint SurvivalModeRecord = 0;
//    public string PlayerName = "";

    public SavedData()
    {
        this.ClassicModeRecord = PlayerStats.ClassicModeRecord;
        this.SurvivalModeRecord = PlayerStats.SurvivalModeRecord;
//        this.PlayerName = PlayerStats.PlayerName;
    }
}
