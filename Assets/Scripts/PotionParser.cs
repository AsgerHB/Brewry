using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionParser : MonoBehaviour
{

	public Text TargetText;
	public Cauldron Cauldron;
	
	public void ParsePotion()
	{
		Dictionary<Reagent.ReagentType, int> reagents = Cauldron.Reagents;
		
		TargetText.text = "The ingredients in your laboratory are either plastic, water, or both, " +
		       "but the placebo effect keeps your customers happy";

		TargetText.gameObject.SetActive(true);
	}
}
