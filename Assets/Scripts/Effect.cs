using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect
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
}
