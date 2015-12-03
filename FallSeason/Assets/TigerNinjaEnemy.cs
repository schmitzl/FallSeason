using UnityEngine;
using System.Collections;

public class TigerNinjaEnemy : MonoBehaviour {

	public Vector3 pointB;

	private int teleportHash = Animator.StringToHash("Teleport");
	private int cloudHash = Animator.StringToHash("Cloud");

	private Animator anim;



	IEnumerator Start () {
		anim = GetComponent<Animator>();
		Vector3 pointA = transform.localPosition;
		Vector3 pointB = transform.localPosition + new Vector3(3,-3,0);
		while(true)
		{
			yield return  StartCoroutine(Idle(Random.Range(2,3)));
			yield return StartCoroutine(MoveObject(transform, pointA, pointB, 0.8f));
			yield return  StartCoroutine(Idle(Random.Range(2,3)));
			yield return StartCoroutine(MoveObject(transform, pointB, pointA, 0.8f));
		}
	}
	
	IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
	{
		float i= 0.0f;
		float rate= 1.0f/time;

		anim.SetTrigger(teleportHash);
		yield return new WaitForSeconds(5);

		while(i < 1.0f)
		{
			i += Time.deltaTime * rate;
			thisTransform.localPosition = Vector3.Lerp(startPos, endPos, i);
			yield return null;
		}
		yield return new WaitForSeconds(1);
		anim.SetTrigger(cloudHash);
	}

	IEnumerator Idle(float time) {
		yield return new WaitForSeconds(time);
	}

}
