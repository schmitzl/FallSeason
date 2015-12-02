using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class pauseScript : MonoBehaviour {

	public GameObject pausePanel;

	public bool isPaused;





	// Use this for initialization
	void Start () {

		isPaused = false;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (isPaused) {
			PauseGame (true);
		} else {
			PauseGame (false);
		}


		if (Input.GetButtonDown ("Cancel")) {
			SwitchPauase ();
		}


	
	}


	void PauseGame (bool state){
		if (state) {
			Time.timeScale = 0.0f; //paused game
		} else {
			Time.timeScale = 1.0f; //unpaused game
		}

		pausePanel.SetActive (state);


	}


	public void SwitchPauase(){
		if (isPaused) {
			isPaused = false; //changes value
		} else {
			isPaused = true;
		}

	}




	
	public void RestartGame(){
		Application.LoadLevel ("Level1");
	}

	
	public void ExitToMenu() {
		
		Application.LoadLevel ("MenuScene");
		
	}



}
