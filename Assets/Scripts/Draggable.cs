using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Draggable : MonoBehaviour
{
	[HideInInspector]
	public Rigidbody2D Rigidbody2D;
	public Dragger DraggedBy;
	public float Eagerness = 10;
	public float CarryDrag = 2.5f;

	private void Start()
	{
		Rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		if (DraggedBy != null)
		{
			//transform.position = DraggedBy.TargetPosition;
			if (Rigidbody2D != null)
			{
				Rigidbody2D.AddForce(
					new Vector2(
						DraggedBy.TargetPosition.x - transform.position.x,
						DraggedBy.TargetPosition.y - transform.position.y)
					* Eagerness * Time.deltaTime);
				//Rigidbody2D.Sleep();
				//Rigidbody2D.velocity = Vector3.zero;
				Rigidbody2D.gravityScale = 0;
				Rigidbody2D.drag = CarryDrag;
			}
		}
		else
		{
			Rigidbody2D.gravityScale = 1;
			Rigidbody2D.drag = 0;
		}
	}
}
