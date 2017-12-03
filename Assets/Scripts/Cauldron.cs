using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
	public Dictionary<Reagent.ReagentType, int> Reagents = new Dictionary<Reagent.ReagentType, int>();
	public SpriteRenderer Glow;

	private void Start()
	{
        Clear();

		Glow = GameObject.FindGameObjectWithTag("CauldronGlow").GetComponent<SpriteRenderer>();
	}

    public void Clear()
    {
        Reagents = new Dictionary<Reagent.ReagentType, int>();
        Reagents.Add(Reagent.ReagentType.Crystal, 0);
        Reagents.Add(Reagent.ReagentType.Eyeball, 0);
        Reagents.Add(Reagent.ReagentType.Mushroom, 0);
        Reagents.Add(Reagent.ReagentType.Root, 0);
        Reagents.Add(Reagent.ReagentType.Rose, 0);
        Reagents.Add(Reagent.ReagentType.Skull, 0);
        Reagents.Add(Reagent.ReagentType.Spider, 0);
        Reagents.Add(Reagent.ReagentType.Urn, 0);
    }

	private void OnTriggerEnter2D(Collider2D other)
	{
		Reagent reagent = other.GetComponent<Reagent>();
		
		if (reagent == null)
			return;
        
        System.String debug = "";
        foreach (KeyValuePair<Reagent.ReagentType, int> rea in Reagents)
        {
            debug += rea.Value + " : ";
        }
        Debug.Log("Reagents Before: " + debug);

        Reagents[reagent.Type]++;

        debug = "";
        foreach (KeyValuePair<Reagent.ReagentType, int> rea in Reagents)
        {
            debug += rea.Value + " : ";
        }
        Debug.Log("Reagents After: " + debug);


        Glow.color = new Color(
			(Glow.color.r*2 + reagent.Colour.r)/3, 
			(Glow.color.g*2 + reagent.Colour.g)/3, 
			(Glow.color.b*2 + reagent.Colour.b)/3,
			175);
		
		Destroy(reagent.gameObject);
	}
}
