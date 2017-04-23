using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ScoreMan : MonoBehaviour {
public GameObject panel,winpanel;
public Text LivesText, MoneyText;
public int lives = 20, money = 500;
bool display = false;
	
	// Use this for initialization

	void Start () {
		UpdateText();
	}
	void Update (){
		if (GameObject.FindObjectOfType<Spawner>().getwavenum() > 10 && GameObject.FindObjectOfType<EnemyUnit>() == null && display == false) {
			display = true;
			winpanel.SetActive(true);
		}
	}
	
	// Update is called once per frame
	void UpdateText () {
		LivesText.text = "Lives: " + lives.ToString();
		MoneyText.text = "Quillings: " + money.ToString();
	}
	public void LoseLife (int i) {
		lives -= i;
		UpdateText();
		if (lives <= 0) {
			gameover();
		}
	}
	public void GainMoney(int i) {
		money += i;
		UpdateText();
	}
	public void LoseMoney(int i) {
		money -= i;
		UpdateText();
	}
	void gameover(){
		panel.SetActive(true);

	}
	public void TryAgian(bool i){
		if (i) {SceneManager.LoadScene(0);}
		if (i == false) {Application.Quit();}
	}

	
}
