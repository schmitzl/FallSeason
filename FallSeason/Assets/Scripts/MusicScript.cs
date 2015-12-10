using UnityEngine;
using System.Collections;
using UnityEngine.UI;
[System.Serializable]

public class MusicScript : MonoBehaviour {
	
	/*public static MusicScript Instance { get; private set; }



	[SerializeField]
	private void Awake() {
		if (Instance != null) {
			DestroyImmediate(gameObject);
		
			return;
		}

		Instance = this;
		DontDestroyOnLoad(transform.gameObject);
	} 

} */

	public static MusicScript Instance;
	void Awake()
	{
		
		if (Instance)
			DestroyImmediate (gameObject);
		else {
			DontDestroyOnLoad (gameObject);
			Instance = this;
			
		}
	}
}


