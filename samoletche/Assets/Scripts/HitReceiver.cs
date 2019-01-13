using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HitReceiver : MonoBehaviour
{
    public GameObject ObjectToSpawnOnDeath;
    public GameObject LifeToSpawn;
    public GameObject DestructionFX;
    public float SpawnDistance = 2;
    public float DeflectionAngle = 45;
    public float DestructionFXDuration = 0.5f;
    public uint ScoreOnDeath = 0;
    public bool DebugDraw = false;

    public void ReceiveHit(GameObject damageDealer)
    {
        if (this.ObjectToSpawnOnDeath != null)
        {
            Vector3 hitDirection = this.transform.position - damageDealer.transform.position;
            hitDirection.Normalize();
            if (this.DebugDraw)
            {
                Debug.DrawLine(damageDealer.transform.position, this.transform.position, Color.red, 2.0f);
            }

            this.SpawnDeathObject(hitDirection, -this.DeflectionAngle);
            this.SpawnDeathObject(hitDirection, this.DeflectionAngle);
        }
        if (this.DestructionFX != null)
        {
            GameObject spawnedFX = Instantiate(this.DestructionFX, this.transform.position, Random.rotation);
            Destroy(spawnedFX, this.DestructionFXDuration);
        }

        if (this.LifeToSpawn != null && SceneManager.GetActiveScene().name != "Survival")
        {
            var rand = Random.Range(0, 20);
            if (rand == 3)
            {
                Instantiate(this.LifeToSpawn, transform.position, transform.rotation);
            }
        }
        GameStateController.Instance.IncrementScore(this.ScoreOnDeath);

        if (this.tag == "Player")
        {
            this.GetComponent<PlayerController>().LoseLife();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void SpawnDeathObject(Vector3 hitDirection, float angle)
    {
        Vector3 spawnDirection = Quaternion.AngleAxis(angle, Vector3.up) * hitDirection;
        Vector3 spawnPosition = this.transform.position + spawnDirection * this.SpawnDistance;
        if (this.DebugDraw)
        {
            Debug.DrawLine(this.transform.position, spawnPosition, Color.green, 2.0f);
        }

        GameObject spawnedObject = Instantiate(this.ObjectToSpawnOnDeath, spawnPosition, Random.rotation);
        var asteroidMovementController = spawnedObject.GetComponent<AsteroidMovementController>();
        if (asteroidMovementController)
        {
            asteroidMovementController.InitialDirection = spawnDirection;
        }
    }
}
