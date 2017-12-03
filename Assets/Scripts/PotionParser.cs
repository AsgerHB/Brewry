using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionParser : MonoBehaviour
{

    public GameObject MessageBox;
    public Text TargetText;
    public Cauldron Cauldron;

    public void ParsePotion()
    {
        Dictionary<Reagent.ReagentType, int> reagents = Cauldron.Reagents;

        EffectSchema es = CalcEffectSchema(reagents);

        String mes = CalcMessage(es);

        Message(mes);
    }

    private string CalcMessage(EffectSchema es)
    {
        String output = "The customer ";
        int effects = 0;

        for (int i = 0; i < Effect.effectCount; i++)
        {

            if (es.Values[i] > 1)
            {
                if (effects > 0)
                {
                    output += ", ";
                }
                // Overdose message
                switch ((Effect.EffectType) i)
                {
                    case Effect.EffectType.Fire:
                        output += "is on fire"
                        break;
                    case Effect.EffectType.Health:
                        output += "is on ?"
                        break;
                    case Effect.EffectType.Age:
                        output += "is turning to dust"
                        break;
                    case Effect.EffectType.Petrification:
                        output += "is on ?"
                        break;
                    case Effect.EffectType.Size:
                        output += "is on ?"
                        break;
                    case Effect.EffectType.Sprout:
                        output += "is on ?"
                        break;
                }
                

                effects++;
            }
            else if (es.Values[i] < -1)
            {
                if (effects > 0)
                {
                    output += ", ";
                }

                // Underdose message
                effects++;
            }
            else if (es.Values[i] == 1)
            {
                if (effects > 0)
                {
                    output += ", ";
                }

                // Effect message
                effects++;
            }
            else if (es.Values[i] == -1)
            {
                if (effects > 0)
                {
                    output += ", ";
                }

                // Unfect message
                effects++;
            }

            output += ".";
        }
    }

    private EffectSchema CalcEffectSchema(Dictionary<Reagent.ReagentType, int> reagents)
    {
        EffectSchema output = new EffectSchema();

        foreach (KeyValuePair<Reagent.ReagentType, int> rea in reagents)
        {

            switch (rea.Key)
            {
                case Reagent.ReagentType.Crystal:
                    output.FireValue--;
                    output.SproutValue--;
                    break;
                case Reagent.ReagentType.Eyeball:
                    output.PetrificationValue++;
                    break;
                case Reagent.ReagentType.Mushroom:
                    output.SizeValue++;
                    break;
                case Reagent.ReagentType.Root:
                    output.SproutValue++;
                    output.SizeValue++;
                    break;
                case Reagent.ReagentType.Rose:
                    output.FireValue++;
                    output.HealthValue++;
                    break;
                case Reagent.ReagentType.Skull:
                    output.SizeValue--;
                    output.AgeValue++;
                    break;
                case Reagent.ReagentType.Spider:
                    output.HealthValue--;
                    output.PetrificationValue--;
                    break;
                case Reagent.ReagentType.Urn:
                    output.AgeValue--;
                    break;
            }
        }

        return output;
    }

    void Message(string message)
    {
        MessageBox.gameObject.SetActive(true);
        TargetText.text = message;
    }
}