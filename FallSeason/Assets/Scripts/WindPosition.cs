using UnityEngine;
using System.Collections;

public class WindPosition : MonoBehaviour {

	private Vector3 windDir;
	private GameObject mainCharacter;

	void Start () {
		mainCharacter = GameObject.FindGameObjectWithTag("Player");
	}

	void Update () {
//		this.transform.position = mainCharacter.transform.position - windDir;
	}

	public Vector3 scaledDir {
		get { return windDir; }
		set { windDir = value; }
	}

}
