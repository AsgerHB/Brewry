using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
	public Dictionary<Reagent.ReagentType, int> Reagents = new Dictionary<Reagent.ReagentType, int>();

	private void Start()
	{
		Reagents.Add(Reagent.ReagentType.Crystal, 0);
		Reagents.Add(Reagent.ReagentType.Eyeball, 0);
		Reagents.Add(Reagent.ReagentType.Mushroom, 0);
		Reagents.Add(Reagent.ReagentType.Root, 0);
		Reagents.Add(Reagent.ReagentType.Rose, 0);
		Reagents.Add(Reagent.ReagentType.Skull, 0);
		Reagents.Add(Reagent.ReagentType.Urn, 0);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		Reagent reagent = other.GetComponent<Reagent>();
		
		if (reagent == null)
			return;

		Reagents[reagent.Type]++;
		Destroy(reagent.gameObject);
	}
}
