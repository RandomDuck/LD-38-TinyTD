using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotClick : MonoBehaviour {

void OnMouseUp() {
		Debug.Log("TowerSpot clicked.");

		BuildingManager bm = GameObject.FindObjectOfType<BuildingManager>();
		if(bm.selectedTower != null) {
			ScoreMan sm = GameObject.FindObjectOfType<ScoreMan>();
			if(sm.money < bm.selectedTower.GetComponent<Turret>().cost) {
				Debug.Log("Not enough money!");
				return;
			}

			sm.LoseMoney( bm.selectedTower.GetComponent<Turret>().cost );

			
			Instantiate(bm.selectedTower, transform.position + new Vector3 (0,0.3f,0), transform.rotation);
//			transform.parent.gameObject.;
//			Obj.transform.SetParent(null); //become batman
//			Obj.SetActive(true);
		}
	}
	
}
