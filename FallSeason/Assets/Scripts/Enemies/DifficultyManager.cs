using UnityEngine;
using System.Collections;

public class DifficultyManager : MonoBehaviour {

	public GameObject dragonEnemy;
	public GameObject tigerNinja;

	public void spawn(GameObject level){

		SpriteRenderer spriteRenderer = level.GetComponent<SpriteRenderer>();
		Vector3 max = spriteRenderer.bounds.max;
		Vector3 center = spriteRenderer.bounds.center;
		Vector3 min = spriteRenderer.bounds.min;

		int choice = Random.Range(0,3);
		switch(choice){
		case 0:
			break; // spawn nothing
		case 1:
			spawnDragon(level.transform, min, center, max);
			break;
		case 2:
			spawnTigerNinja(level.transform, min, center, max);
			break;
		}
	}

	private void spawnDragon(Transform levelTransform, Vector3 min, Vector3 center, Vector3 max){
		GameObject dragon = (GameObject) Instantiate(dragonEnemy, new Vector3(max.x, Random.Range(min.y, max.y), center.z), Quaternion.identity);
		dragon.transform.SetParent(levelTransform);

	}

	private void spawnTigerNinja(Transform levelTransform, Vector3 min, Vector3 center, Vector3 max){
		GameObject ninja = (GameObject) Instantiate(tigerNinja, new Vector3(Random.Range(min.x,max.x), Random.Range(min.y, max.y), center.z), Quaternion.identity);
		ninja.transform.SetParent(levelTransform);
		
	}
}
