using UnityEngine;
using UnityEngine.Assertions;
using System.Collections;
using System.Collections.Generic;

public class DifficultyManager : MonoBehaviour {

	public GameObject dragonEnemy;
	public GameObject tigerNinja;

	public void spawn(GameObject level){

		SpriteRenderer spriteRenderer = level.GetComponent<SpriteRenderer>();
		Vector3 max = spriteRenderer.bounds.max;
		Vector3 center = spriteRenderer.bounds.center;
		Vector3 min = spriteRenderer.bounds.min;

		// try to extract path points to place enemies
		List<Transform> pathPoints = new List<Transform> ();
		Transform pathTransform = level.transform.FindChild ("Path");
		if (pathTransform != null) {
			foreach(Transform child in pathTransform){
				pathPoints.Add(child);
			}
		}

		// Check if this level has place for more enemies
		LevelSegment levelSegment = level.GetComponent<LevelSegment> ();

		if (levelSegment.EnemyCount < levelSegment.MaxEnemyCount) {
		
			int choice = Random.Range (0, 3);
			choice = 2;
			switch (choice) {
			case 0:
				break; // spawn nothing
			case 1:
				spawnDragon (level.transform, min, center, max);
				levelSegment.EnemyCount += 1;
				break;
			case 2:
				spawnTigerNinja (level.transform, min, center, max, pathPoints);
				levelSegment.EnemyCount += 1;
				break;
			}
		}
	}

	private void spawnDragon(Transform levelTransform, Vector3 min, Vector3 center, Vector3 max){
		GameObject dragon = (GameObject) Instantiate(dragonEnemy, new Vector3(max.x, Random.Range(min.y, max.y), center.z), Quaternion.identity);
		dragon.transform.SetParent(levelTransform);

	}

	private void spawnTigerNinja(Transform levelTransform, Vector3 min, Vector3 center, Vector3 max, List<Transform> pathPoints){
		Vector3 position;

		// Create initial position
		Assert.IsTrue (pathPoints.Count >= 2); // Two points are needed for the ninja
		int index = Random.Range (0, pathPoints.Count);
		Transform posTransform = pathPoints [index];
		pathPoints.Remove(posTransform);
		position = posTransform.position;

		GameObject ninja = (GameObject) Instantiate(tigerNinja, position, Quaternion.identity);
		ninja.transform.SetParent(levelTransform);

		// Create second position to move back and forth from
		Transform pathPointTransform = pathPoints[Random.Range(0, pathPoints.Count)];
		ninja.GetComponent<TigerNinjaEnemy>().pointB = pathPointTransform.localPosition;

	}
}
