using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{

    public const int effectCount = 6;

    public enum EffectType
    {
        Fire = 0,
        Sprout = 1,
        Health = 2,
        Petrification = 3,
        Size = 4,
        Age = 5
	}

	public EffectType Type;
    public int Value;
        	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
