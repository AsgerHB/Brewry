using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSpawner : MonoBehaviour
{
	private Dragger _dragger;

	public GameObject ThingToSpawn;
	void Start ()
	{
		_dragger = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Dragger>();
		if (_dragger == null)
		{
			Debug.LogError("The Dragger component needs to be on Main Camera to keep shit from breaking :/");
		}
	}

	public void Spawn()
	{
		GameObject thing = Instantiate(ThingToSpawn);
		thing.transform.position = gameObject.transform.position;
		
		Draggable draggable = thing.GetComponent<Draggable>();
		if (draggable != null)
		{
			_dragger.ThingBeingDragged = draggable;
			draggable.DraggedBy = _dragger;
		}
	}
}
