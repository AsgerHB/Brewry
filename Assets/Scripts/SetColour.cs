using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SetColour : MonoBehaviour
{

	private SpriteRenderer _sprite;
	
	private void Start()
	{
		_sprite = gameObject.GetComponent<SpriteRenderer>();
	}

	public void ResetColour()
	{
		_sprite.color = new Color(1, 1, 1, 0);
	}
}
