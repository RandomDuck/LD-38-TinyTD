using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMan : MonoBehaviour {
public Text LivesText, MoneyText;
public int lives = 20, money = 500;
	// Use this for initialization
	void Start () {
		LivesText.text = "Lives: " + lives.ToString();
		MoneyText.text = "Quillings: " + money.ToString();
	}
	
	// Update is called once per frame
	void UpdateText () {
		LivesText.text = "Lives: " + lives.ToString();
		MoneyText.text = "Quillings: " + money.ToString();
	}
	public void LoseLife (int i) {
		lives -= i;
		UpdateText();
	}
	public void GainMoney(int i) {
		money += i;
		UpdateText();
	}
	public void LoseMoney(int i) {
		money -= i;
		UpdateText();
	}

}
