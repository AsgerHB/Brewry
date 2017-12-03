using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reagent : MonoBehaviour
{
	public enum ReagentType
	{
		Urn,
		Rose,
		Crystal,
		Mushroom,
		Skull,
		Root,
		Eyeball,
        Spider
	}

	public ReagentType Type;
	public Color Colour;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
