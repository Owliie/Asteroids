using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public float ShotsPerSecond = 10f;
    public GameObject ProjectileToSpawn;
    public Transform SpawnPosition;

    private float NextShotTime = 0.0f;
    
    public void Shoot()
    {
        float cooldown = 1 / this.ShotsPerSecond;

        if (Time.time > this.NextShotTime)
        {
            var newProjectile = Instantiate(this.ProjectileToSpawn, this.SpawnPosition.position, this.SpawnPosition.rotation);
            Physics.IgnoreCollision(this.gameObject.GetComponent<Collider>(), newProjectile.GetComponent<Collider>());
            this.NextShotTime = Time.time + cooldown;
        }
    }
}
