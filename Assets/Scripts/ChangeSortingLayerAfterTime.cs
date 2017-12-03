using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ChangeSortingLayerAfterTime : MonoBehaviour
{

	public float TimeToWait;

	public int OrderInLayer;
	
	
	// Use this for initialization
	void Start ()
	{
		StartCoroutine(DoTheThing());
	}

	IEnumerator DoTheThing()
	{
		yield return new  WaitForSeconds(TimeToWait);
		gameObject.GetComponent<SpriteRenderer>().sortingOrder = OrderInLayer;
	}
}
