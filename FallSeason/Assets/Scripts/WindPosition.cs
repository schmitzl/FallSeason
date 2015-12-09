using UnityEngine;
using System.Collections;

public class WindPosition : MonoBehaviour {

	private Vector3 windDir;
	private GameObject mainCharacter;

	void Start () {
		mainCharacter = GameObject.FindGameObjectWithTag("Player");
	}

	void Update () {
		this.transform.position = mainCharacter.transform.position - windDir;
		Debug.Log("Char" + mainCharacter.transform.position);
		Debug.Log("Wind" + this.transform.position);
	}

	public Vector3 scaledDir {
		get { return windDir; }
		set { windDir = value; }
	}

}
