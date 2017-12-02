using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragger : MonoBehaviour
{
	private Camera _main;
	private Draggable _draggable;
	private Vector3 _mousePosition;
	private Vector3 _previousMousePosition;
	
	public Vector3 TargetPosition;
	
	
	// Use this for initialization
	void Start ()
	{
		_main = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		_mousePosition = _main.ScreenToWorldPoint(Input.mousePosition);
		
		TargetPosition = new Vector3(_mousePosition.x, _mousePosition.y);

		if (Input.GetButtonDown("Fire1"))
		{
			Grab();
		}

		if (_draggable != null && Input.GetButtonUp("Fire1"))
		{
			Release();
		}
		
		_previousMousePosition = _mousePosition;
	}

	void Grab()
	{
		RaycastHit2D ray = Physics2D.Raycast(_main.transform.position, _mousePosition);

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
		
		/*if (_draggable.Rigidbody2D != null)
		{
			_draggable.Rigidbody2D.velocity = 
				new Vector2(
					(_mousePosition.x - _previousMousePosition.x) * Time.deltaTime,
					(_mousePosition.y - _previousMousePosition.y) * Time.deltaTime)
				*100;
		}*/
		
		_draggable = null;
	}
}
