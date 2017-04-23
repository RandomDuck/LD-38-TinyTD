using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {
	public int cost = 100;
	public GameObject bulletPrefab;
	public float radius = 0f, damage = 1f;
	Transform turretTransform;
	public float FireRange = 4;
	EnemyUnit nearestEnemy = null;
	float fireCooldown = 0.5f;
	float fireCooldownLeft = 0;
	// Use this for initialization
	void Start () {
		turretTransform = transform.Find("Turret");
	}
	
	// Update is called once per frame
	void Update () {
		if (nearestEnemy == null || Vector3.Distance(this.transform.position,nearestEnemy.transform.position) > FireRange) {
			findNewEn();
		}
		if (nearestEnemy != null)
		{
			Aim();
		}
	}
	void findNewEn(){
		EnemyUnit[] enemies = GameObject.FindObjectsOfType<EnemyUnit>();	
		float dist = Mathf.Infinity;
		
		foreach(EnemyUnit e in enemies) {
			float d = Vector3.Distance(this.transform.position, e.transform.position);
			if(nearestEnemy == null || d < dist) {
				nearestEnemy = e;
				dist = d;
			}
		}
	}	
	void Aim() {
		Vector3 dir = nearestEnemy.transform.position - this.transform.position;

		Quaternion lookRot = Quaternion.LookRotation( dir );

		//Debug.Log(lookRot.eulerAngles.y);
		if (Vector3.Distance(this.transform.position,nearestEnemy.transform.position) < FireRange)
		{
			turretTransform.rotation = Quaternion.Euler( 0, lookRot.eulerAngles.y, 0 );
		}


		fireCooldownLeft -= Time.deltaTime;
		if(fireCooldownLeft <= 0 && dir.magnitude <= FireRange) {
			fireCooldownLeft = fireCooldown;
			ShootAt(nearestEnemy);
		}
	}
		void ShootAt(EnemyUnit e) {
		// TODO: Fire out the tip!
		GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, this.transform.position, this.transform.rotation);

		Bullet b = bulletGO.GetComponent<Bullet>();
		b.target = e.gameObject.transform;
		b.damage = damage;
		b.radius = radius;
	}



}