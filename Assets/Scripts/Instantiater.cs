using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiater : MonoBehaviour
{
	public GameObject ThingToInstantiate;
	
	public void DoTheThing()
	{
		GameObject thing = Instantiate(ThingToInstantiate);
		thing.transform.position = transform.position;
	}
}
