using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
	
	public Text scoreText;
	public Text distanceText;
	public Text coinText;

	private int score;
	private int distance;
	private int coins;

	// Use this for initialization
	void Start () {
		score = distance = coins = 0;
		UpdateTexts();
	}
	
	// Update is called once per frame
	void Update () {
		UpdateValues();
		UpdateTexts();
	}

	void UpdateValues () {
		distance = GetComponent<ScrollingManager>().distance;
		coins = GetComponent<PickCoins>().coins;
		score = distance * 10 + coins;
	}

	void UpdateTexts () {
		scoreText.text 		= "Score : " 	+ score.ToString ();
		distanceText.text 	= "Distance : " + distance.ToString ();
		coinText.text 		= "Coins : " 	+ coins.ToString ();
	}
}
