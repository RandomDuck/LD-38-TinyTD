using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnit : MonoBehaviour {
	
	Transform[] NodeIndex;
	Transform TargetNode;
	int NextNodeIndex = 1;
	public float HitPoints = 1, speed = 1;
	public int healthRMvalue = 1, value = 2;
	// Use this for initialization
	void Start () {
		GameObject PathGo = GameObject.FindWithTag("Node");
		NodeIndex = PathGo.GetComponentsInChildren<Transform>();
		TargetNode = NodeIndex[NextNodeIndex];
		Debug.Log("NextNodeIndex = " + NextNodeIndex.ToString());
		Debug.Log("TargetNode: " + TargetNode.name);
		NextNodeIndex++;
		
	}
	void newNodePlz () {
		if(NextNodeIndex <= NodeIndex.Length-1) {
			TargetNode = NodeIndex[NextNodeIndex];
			Debug.Log("NextNodeIndex = " + NextNodeIndex.ToString());
			Debug.Log("TargetNode: " + TargetNode.name);
			NextNodeIndex++;
		} else {
			HurtPlayer();
			Die();	
		}
	}
	void Die(){
		GameObject.Destroy(this.gameObject);
	}
	void HurtPlayer() {
		GameObject.FindObjectOfType<ScoreMan>().LoseLife(healthRMvalue);
	}
	// Update is called once per frame
	void Update () {
		if (TargetNode == null){
			newNodePlz();
		}
		Move();
		// TODO: make code for when destroyed by tower. (public Murderme()?)
		

	}
	void Move() {
			Vector3 dir = TargetNode.position - this.transform.localPosition;

		float distThisFrame = speed * Time.deltaTime;

		if(dir.magnitude <= distThisFrame) {
			
			TargetNode = null;
		}
		else {
			// TODO: Consider ways to smooth this motion.

			transform.Translate( dir.normalized * distThisFrame, Space.World );
			Quaternion targetRotation = Quaternion.LookRotation( dir );
			this.transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRotation, Time.deltaTime*5);
		}
	}
		public void TakeDamage(float damage) {
		HitPoints -= damage;
		if(HitPoints <= 0) {
			GameObject.FindObjectOfType<ScoreMan>().GainMoney(value);
			Die();
		}
	}
}
