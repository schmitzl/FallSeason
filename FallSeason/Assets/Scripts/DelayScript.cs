using UnityEngine;
using System.Collections;

public class DelayScript : MonoBehaviour {

	float delay = 3;
	
	
	void Update()
	{
		delay -= Time.deltaTime;
		if (delay <= 0)
			Application.LoadLevel("Trailer1");
	}
}
