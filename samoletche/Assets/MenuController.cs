using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public static string CurrentScene;

    public void NormalMode()
    {
        SceneManager.LoadScene("Normal", LoadSceneMode.Single);
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
        PlayerStats.NormalModeRecord = data.NormalModeRecord;
        PlayerStats.SurvivalModeRecord = data.SurvivalModeRecord;
        PlayerStats.PlayerName = data.PlayerName;
    }

    void Update()
    {
        GameObject.Find("PlayerRecordNormal").GetComponent<Text>().text = PlayerStats.NormalModeRecord.ToString();
    }
}
