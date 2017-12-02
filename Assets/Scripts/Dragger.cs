using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragger : MonoBehaviour
{
	private Camera _main;
	private Draggable _draggable;
	
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

		if (_draggable != null && Input.GetButtonUp("Fire1"))
		{
			Release();
		}
	}

	void Grab(Vector3 mousePosition)
	{
		RaycastHit2D ray = Physics2D.Raycast(mousePosition, new Vector3(mousePosition.x, mousePosition.y,0));

		if (ray.transform == null)
			return;
			
		_draggable = ray.transform.GetComponent<Draggable>();

		if (_draggable == null)
			return;
			
		_draggable.DraggedBy = this;
	}


	void Release()
	{
		_draggable.DraggedBy = null;
		
		_draggable = null;
	}
}
