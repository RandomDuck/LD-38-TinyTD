using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Spawner : MonoBehaviour {
	public bool nextWave = false;
	public Text ButtonText, wave;
	public Button button;
	public int WaveNum = 1;
	float spawnCD = 0.5f;
	float spawnCDremaining = 5;

	[System.Serializable]
	public class WaveComponent {
		public GameObject enemyPrefab;
		public int num;
		[System.NonSerialized]
		public int spawned = 0;
	}

	public WaveComponent[] waveComps;

	public int getwavenum() {return WaveNum;}
	// Use this for initialization
	void Start() {
		button.interactable = true;
		ButtonText.text = "Next wave!";
	}
	void Update () {
		
		if (nextWave) {SpawnUpdate();}
		wave.text = "Current wave: " + WaveNum;
	}
	
	// Update is called once per frame
	void SpawnUpdate () {
		button.interactable = false;
		ButtonText.text = "Wave in progress";
		
		spawnCDremaining -= Time.deltaTime;
		if(spawnCDremaining < 0) {
			spawnCDremaining = spawnCD;

			bool didSpawn = false;

			// Go through the wave comps until we find something to spawn;
			foreach(WaveComponent wc in waveComps) {
				if(wc.spawned < wc.num) {
					// Spawn it!
					wc.spawned++;
					Instantiate(wc.enemyPrefab, this.transform.position, this.transform.rotation);

					didSpawn = true;
					break;
				}
			}

			if(didSpawn == false) {
				WaveNum++;
				foreach(WaveComponent wc in waveComps) {
					wc.num += Mathf.CeilToInt( wc.num*0.5f);
					wc.spawned = 0;

				}
				nextWave = false;
				button.interactable = true;
				ButtonText.text = "Next wave!";
			}
		}
	}
	public void ButtonEneable() {nextWave = true;}
}
