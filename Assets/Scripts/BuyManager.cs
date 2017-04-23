using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BuyManager : MonoBehaviour {
	BuildingManager buildman;
	public Dropdown Selector;
	int cost;
	float radius, damage, range, fireRate;
	public GameObject[] Prefabs;
	GameObject CurentOne;
	public Text[] InfoText;
	public Transform spawnpos;
	
	void Start()
	{
		buildman = GameObject.FindObjectOfType<BuildingManager>();
		UpdatePrefab ();
	}
	public void UpdatePrefab () {
		int Val = Selector.value;
		if (CurentOne != null){Destroy(CurentOne);}
		CurentOne = (GameObject)Instantiate(Prefabs[Val],spawnpos.position,spawnpos.rotation);
		CurentOne.transform.SetParent(spawnpos);
		buildman.selectedTower = Prefabs[Val];
		Turret V = CurentOne.GetComponent<Turret>();
		cost = V.cost;
		radius = V.radius;
		damage = V.damage;
		fireRate = V.fireCooldown;
		range = V.FireRange;
		V.enabled = false;
		updateText(Val);
	}
	void updateText(int i) {
		InfoText[0].text = "Turret: " + Prefabs[i].name;
		InfoText[1].text = "Cost: " + cost.ToString() + "Q";
		InfoText[2].text = "Damage: " + damage.ToString();
		InfoText[3].text = "Range: " + range.ToString();
		InfoText[4].text = "Fire Rate: " + fireRate.ToString();
		InfoText[5].text = "Radius: " + radius.ToString();
	}
}
