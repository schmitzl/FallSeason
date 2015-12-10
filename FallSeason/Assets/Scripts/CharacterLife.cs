using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterLife : MonoBehaviour {


	public GameObject lostPanel;
	public GameObject coinPanel;
	public GameObject lifePanel;
	public GameObject pauseButtonPanel;
	public AudioClip hitEnemy;
	private int lifeCounter;
	private AudioSource sourceEnemy;

	public int life {
		get { return lifeCounter; }
		set { lifeCounter = value; }
	}
	
	
	void Start() {
		lifeCounter = 3;
	}



	void Awake () {
		sourceEnemy = GetComponent<AudioSource> ();
	}
	
	
	
	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.CompareTag ("Enemy")) {
			sourceEnemy.PlayOneShot(hitEnemy,3F);
			if (lifeCounter == 3) {

				Destroy (GameObject.FindWithTag ("Life1"));
				lifeCounter -= 1;
				return;
			}

			if (lifeCounter == 2) {
				
				Destroy (GameObject.FindWithTag ("Life2"));
				lifeCounter -= 1;
				return;
			}

			if (lifeCounter == 1) {
				
				Destroy (GameObject.FindWithTag ("Life3"));
				DeadGame ();
			}



		}
	}


	
	
	void DeadGame (){

		Time.timeScale = 0.0f; //pauses game
		lostPanel.SetActive(true);
		coinPanel.SetActive (false);
		pauseButtonPanel.SetActive (false);


}
}
	