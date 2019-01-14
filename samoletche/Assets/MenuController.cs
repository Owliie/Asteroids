using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public static string CurrentScene;

    public void ClassicMode()
    {
        SceneManager.LoadScene("Classic", LoadSceneMode.Single);
    }

    public void SurvivalMode()
    {
        SceneManager.LoadScene("Survival", LoadSceneMode.Single);
    }

    public void Replay()
    {
        SceneManager.LoadScene(CurrentScene, LoadSceneMode.Single);
    }

    public void BackToHome()
    {
        SceneManager.LoadScene("Home", LoadSceneMode.Single);
    }

    public void Exit()
    {
        Application.Quit();
    }

    void Awake()
    {
        SavedData data = SaveAndLoadSys.Load();
        if (data != null)
        {
            PlayerStats.ClassicModeRecord = data.ClassicModeRecord;
            PlayerStats.SurvivalModeRecord = data.SurvivalModeRecord;
            //        PlayerStats.PlayerName = data.PlayerName;
        }
    }

    void Update()
    {
        if (GameObject.Find("PlayerRecordClassic"))
        {
            GameObject.Find("PlayerRecordClassic").GetComponent<Text>().text = "Classic: " + PlayerStats.ClassicModeRecord.ToString();
        }
        if (GameObject.Find("PlayerRecordSurvival"))
        {
            GameObject.Find("PlayerRecordSurvival").GetComponent<Text>().text = "Survival: " + PlayerStats.SurvivalModeRecord.ToString();
        }
    }
}
