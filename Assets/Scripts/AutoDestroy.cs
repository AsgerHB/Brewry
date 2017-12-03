using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
	public float Delay;
	
	// Use this for initialization
	void Start () {
		Destroy(gameObject, Delay);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
