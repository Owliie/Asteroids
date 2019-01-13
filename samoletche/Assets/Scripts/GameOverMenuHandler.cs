using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenuHandler : MonoBehaviour {

	public string GameScene = "Home";
	public void RestartGame()
	{
		SceneManager.LoadScene(this.GameScene);
	}

	public void QuitGame()
	{
		Application.Quit ();
	}
}
