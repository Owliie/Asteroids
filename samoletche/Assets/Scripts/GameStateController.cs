using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateController : MonoBehaviour {

	public float GameOverScreenDelay = 2.0f;
	public string GameOverScene = "GameOver";
	private uint CurrentScore = 0;
    public static GameStateController Instance { get; private set; }

    void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad (this.gameObject);
		}
		else
		{
			Destroy(this.gameObject);
		}
	}
    
	public void OnPlayerSpawned()
	{
	    this.CurrentScore = 0;
	}

	public void OnPlayerDied()
	{
	    this.Invoke("ShowGameOverScreen", this.GameOverScreenDelay);
	}

	public void IncrementScore(uint scoreToAdd)
	{
	    this.CurrentScore += scoreToAdd;
	    if (SceneManager.GetActiveScene().name == "Survival" && this.CurrentScore > PlayerStats.SurvivalModeRecord)
	    {
	        PlayerStats.SurvivalModeRecord = this.CurrentScore;
	    }
	    else if (this.CurrentScore > PlayerStats.ClassicModeRecord)
	    {
	        PlayerStats.ClassicModeRecord = this.CurrentScore;
	    }
    }

	public uint GetCurrentScore()
	{
		return this.CurrentScore;
	}

	void ShowGameOverScreen()
	{
		SceneManager.LoadScene (this.GameOverScene);
	}
}
