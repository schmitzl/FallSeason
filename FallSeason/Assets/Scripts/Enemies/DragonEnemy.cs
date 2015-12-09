using UnityEngine;
using System.Collections;

public class DragonEnemy : MonoBehaviour {

	public Vector3 pointB;
	public bool spriteFacingLeft;
	
	IEnumerator Start()
	{
		Vector3 pointA = transform.localPosition;
		Vector3 pointB = transform.localPosition + new Vector3(-10, 0,0);
		spriteFacingLeft = true;
		while(true)
		{
			yield return StartCoroutine(MoveObject(transform, pointA, pointB, 7.0f));
			turn (spriteFacingLeft, true);
			yield return StartCoroutine(MoveObject(transform, pointB, pointA, 7.0f));
			turn (spriteFacingLeft, false);
		}
	}
	
	IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
	{
		float i= 0.0f;
		float rate= 1.0f/time;
		while(i < 1.0f)
		{
			i += Time.deltaTime * rate;
			thisTransform.localPosition = Vector3.Lerp(startPos, endPos, i);
			yield return null;
		}
	}

	private void turn(bool facingLeft, bool forward){

		int forwardFactor = 1;
		if(!forward)
			forwardFactor = -1;

		if(spriteFacingLeft)
			transform.Rotate(new Vector3(0,forwardFactor*180f,0));
		else
			transform.Rotate(new Vector3(0,forwardFactor* (-180f),0));

	}
}