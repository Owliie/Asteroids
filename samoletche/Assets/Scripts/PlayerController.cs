using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int lives;
    public float PlayerSpeed = 0.2f;
    public string GameOverScene = "GameOver";

    void Start()
    {
        AsteroidSpawner.Instance.RegisterPlayer(this.gameObject);
        GameStateController.Instance.OnPlayerSpawned();
    }

    public void RecieveLife()
    {
        this.lives++;
    }

    public void LoseLife()
    {
        this.lives--;
        if (lives <= 0)
        {
            SaveAndLoadSys.SavePlayerRec();
            MenuController.CurrentScene = SceneManager.GetActiveScene().name;
            AsteroidSpawner.Instance.UnregisterPlayer(this.gameObject);
            GameStateController.Instance.OnPlayerDied();
            Destroy(this.gameObject);
        }
    }

    void FixedUpdate()
    {
        this.MoveShipWithPhysics();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        }
        this.UpdateShootInputs();
    }

    private void UpdateShootInputs()
    {
        if (Input.GetButton("Fire"))
        {
            this.GetComponent<Weapon>().Shoot();
        }
    }

    private void MoveShipWithPhysics()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        float playerCameraOffset = Camera.main.transform.position.y - this.transform.position.y;
        Vector3 mousePositionScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, playerCameraOffset);
        Vector3 mousePositionWorldSpace = Camera.main.ScreenToWorldPoint(mousePositionScreenSpace);

        Quaternion newRotation = Quaternion.LookRotation(mousePositionWorldSpace - this.transform.position);
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        direction = this.transform.rotation * direction;
        direction = direction * this.PlayerSpeed * Time.deltaTime;

        Rigidbody rb = this.GetComponent<Rigidbody>();
        rb.MovePosition(this.transform.position + direction);
        rb.MoveRotation(newRotation);
    }
}