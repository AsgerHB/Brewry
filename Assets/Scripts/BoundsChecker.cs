using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsChecker : MonoBehaviour
{
	public Vector2 XBounds;
	public Vector2 YBounds;
	public Vector2 ZBounds;
	
	
	// Update is called once per frame
	void Update ()
	{
		if (transform.position.x < XBounds.x || transform.position.x > XBounds.y ||
		    transform.position.y < YBounds.x || transform.position.y > YBounds.y ||
		    transform.position.z < ZBounds.x || transform.position.z > ZBounds.y)
		{
			Destroy(gameObject);
		}
		
	}
}
