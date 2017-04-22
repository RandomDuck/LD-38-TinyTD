using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 15f;
	public Transform target;
	public float damage = 1f;
	public float radius = 0;
	
	void Update () {
		if(target == null) {
			// Our enemy went away!
			Destroy(gameObject);
			return;
		}


		Vector3 dir = target.position - this.transform.localPosition;

		float distThisFrame = speed * Time.deltaTime;

		if(dir.magnitude <= distThisFrame) {
			
			DoBulletHit();
		}
		else {
			
			transform.Translate( dir.normalized * distThisFrame, Space.World );
			Quaternion targetRotation = Quaternion.LookRotation( dir );
			this.transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRotation, Time.deltaTime*5);
		}

	}

	void DoBulletHit() {
		

		if(radius == 0) {
			target.GetComponent<EnemyUnit>().TakeDamage(damage);
		}
		else {
			Collider[] cols = Physics.OverlapSphere(transform.position, radius);

			foreach(Collider c in cols) {
				EnemyUnit e = c.GetComponent<EnemyUnit>();
				if(e != null) {
					
					e.GetComponent<EnemyUnit>().TakeDamage(damage);
				}
			}
		}

	
		Destroy(gameObject);
	}
}
