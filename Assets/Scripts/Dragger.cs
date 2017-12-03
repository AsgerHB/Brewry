using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragger : MonoBehaviour
{
	private Camera _main;
	
	public Draggable ThingBeingDragged;
	public Vector3 TargetPosition;
	
	
	// Use this for initialization
	void Start ()
	{
		_main = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 mousePosition = _main.ScreenToWorldPoint(Input.mousePosition);
		
		TargetPosition = new Vector3(mousePosition.x, mousePosition.y);

		if (Input.GetButtonDown("Fire1"))
		{
			Grab(mousePosition);
		}

		if (ThingBeingDragged != null && Input.GetButtonUp("Fire1"))
		{
			Release();
		}
	}

	void Grab(Vector3 mousePosition)
	{
		RaycastHit2D ray = Physics2D.Raycast(mousePosition, Vector2.zero);

		if (ray.transform == null)
			return;
			
		ThingBeingDragged = ray.transform.GetComponent<Draggable>();

		if (ThingBeingDragged == null)
			return;
			
		ThingBeingDragged.DraggedBy = this;
	}


	void Release()
	{
		ThingBeingDragged.DraggedBy = null;
		
		ThingBeingDragged = null;
	}
}
