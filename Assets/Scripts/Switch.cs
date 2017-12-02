using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Switch : MonoBehaviour
{
	private Camera _main;

	public UnityEvent Pulled;
	
	void Start ()
	{
		_main = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
	}
	
	void Update ()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			Vector3 mousePosition = _main.ScreenToWorldPoint(Input.mousePosition);
			RaycastHit2D ray = Physics2D.Raycast(mousePosition, Vector2.zero);

			if (ray.transform != gameObject.transform)
				return;
			
			Pulled.Invoke();
		}
	}
}
