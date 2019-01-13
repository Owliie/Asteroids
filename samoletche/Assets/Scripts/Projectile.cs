using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float ProjectileDuration = 5f;
    public float ProjectileVelocity = 15f;
    
	void Start () {
        Rigidbody rigidbody = this.GetComponent<Rigidbody>();
        rigidbody.velocity = this.transform.forward * this.ProjectileVelocity;
        Destroy(this.gameObject, this.ProjectileDuration);
	}

}
