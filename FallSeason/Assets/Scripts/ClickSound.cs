using UnityEngine;
using System.Collections;
using UnityEngine.UI;


[RequireComponent(typeof(Button))]
public class ClickSound : MonoBehaviour {



	public AudioClip sound;

	private Button button { get { return GetComponent<Button>(); } }
	private AudioSource source { get { return GetComponent<AudioSource>(); } }

	// Use this for initialization
	void Start () {

		gameObject.AddComponent<AudioSource> ();
		source.clip = sound;
		source.playOnAwake = false;

		button.onClick.AddListener(()=> PlaySound ());
	
	}
	
	// Update is called once per frame
	void PlaySound(){

		source.PlayOneShot (sound);

	}


	//To make sure the coroutine is executed only once
	bool LoadingInitiated=false;
	
	void OnMouseUp()
	{
		if (!LoadingInitiated) 
		{
			StartCoroutine(DelayedLoad());
			LoadingInitiated=true;
		}
	}
	
	IEnumerator DelayedLoad()
	{
		//Play the clip once
		source.PlayOneShot (sound);
		
		//Wait until clip finish playing
		yield return new WaitForSeconds (1);    
		
		//Load scene here
		Application.LoadLevel("level 1");
		
	}




}
