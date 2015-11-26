using UnityEngine;
using System.Collections;

public class ParticleSortingLayerFix : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingLayerName = "Foreground";
		GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingOrder = 4; //dont display on top of jetpack
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
