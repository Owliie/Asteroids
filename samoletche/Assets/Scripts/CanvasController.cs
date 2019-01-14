using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    private GameObject score;
    private GameObject lives;

	// Use this for initialization
	void Start ()
	{
	    this.score = GameObject.Find("Score");
        this.lives = GameObject.Find("Lives");
	}
	
	// Update is called once per frame
	void Update ()
	{
	    this.score.GetComponent<Text>().text = GameObject.Find("GameStateController").GetComponent<GameStateController>().GetCurrentScore().ToString();
	    if (GameObject.Find("TUES_PlayerShip") && SceneManager.GetActiveScene().name == "Classic")
	    {
	        this.lives.GetComponent<Text>().text = GameObject.Find("TUES_PlayerShip").GetComponent<PlayerController>().lives.ToString();
	    }
	}
}
