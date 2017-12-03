using System;
using System.Linq;
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

        String debug = "";
        foreach (KeyValuePair<Reagent.ReagentType, int> rea in reagents)
        {
            debug += rea.Value + " : ";
        }
        Debug.Log("Regent input = " + debug);

        int[] effectSchema = CalcEffectSchema(reagents);

        String mes = CalcMessage(effectSchema);

        Message(mes);

        Cauldron.Clear();

    }

    private string CalcMessage(int[] es)
    {
        String output = "The customer ";
        int effects = 0;

        String debug = "";
        for (int i = 0; i < es.Length; i++)
        {
            debug += es[i] + " : ";
        }
        Debug.Log("Count = " + debug);


        int effectCount = es.Where(x => x != 0).Count();

        Debug.Log("Eff Count = " + effectCount);

        for (int i = 0; i < Effect.effectCount; i++)
        {

            if (es[i] > 1)
            {
                if (effects == (effectCount - 1) && effectCount > 1)
                {
                    output += " and ";
                }
                else if (effects > 0)
                {
                    output += ", ";
                }
                // Overdose message
                switch ((Effect.EffectType)i)
                {
                    case Effect.EffectType.Fire:
                        output += "has burst into flames";
                        break;
                    case Effect.EffectType.Health:
                        output += "became so healthy that their heart exploded";
                        break;
                    case Effect.EffectType.Age:
                        output += "aged so rapidly that they are now a pile of dust";
                        break;
                    case Effect.EffectType.Petrification:
                        output += "is now a rock";
                        break;
                    case Effect.EffectType.Size:
                        output += "is now a giant";
                        break;
                    case Effect.EffectType.Sprout:
                        output += "is turning into a beautiful oak tree";
                        break;
                }

                effects++;
            }
            else if (es[i] < -1)
            {
                if ((Effect.EffectType)i != Effect.EffectType.Petrification && (Effect.EffectType)i != Effect.EffectType.Sprout)
                {
                    if (effects == (effectCount - 1) && effectCount > 1)
                    {
                        output += " and ";
                    }
                    else if (effects > 0)
                    {
                        output += ", ";
                    }
                }

                switch ((Effect.EffectType)i)
                {
                    case Effect.EffectType.Fire:
                        output += "is now a block of ice";
                        break;
                    case Effect.EffectType.Health:
                        output += "has died";
                        break;
                    case Effect.EffectType.Age:
                        output += "has reverse aged into an infant";
                        break;
                    case Effect.EffectType.Size:
                        output += "is now a giant";
                        break;
                }

                // Underdose message
                effects++;
            }
            else if (es[i] == 1)
            {
                if (effects == (effectCount - 1) && effectCount > 1)
                {
                    output += " and ";
                }
                else if (effects > 0)
                {
                    output += ", ";
                }

                switch ((Effect.EffectType)i)
                {
                    case Effect.EffectType.Fire:
                        output += "is on fire";
                        break;
                    case Effect.EffectType.Health:
                        output += "is healthy";
                        break;
                    case Effect.EffectType.Age:
                        output += "is visible aging";
                        break;
                    case Effect.EffectType.Petrification:
                        output += "has turned to stone";
                        break;
                    case Effect.EffectType.Size:
                        output += "is becoming taller";
                        break;
                    case Effect.EffectType.Sprout:
                        output += "has begone sprouting leaves";
                        break;
                }

                // Effect message
                effects++;
            }
            else if (es[i] == -1)
            {
                if ((Effect.EffectType)i != Effect.EffectType.Petrification && (Effect.EffectType)i != Effect.EffectType.Sprout) {
                    if (effects == (effectCount - 1) && effectCount > 1)
                    {
                        output += " and ";
                    }
                    else if (effects > 0)
                    {
                        output += ", ";
                    }
                }   

                switch ((Effect.EffectType)i)
                {
                    case Effect.EffectType.Fire:
                        output += "is freezing and have blue lips";
                        break;
                    case Effect.EffectType.Health:
                        output += "is not feeling well";
                        break;
                    case Effect.EffectType.Age:
                        output += "is feeling like they are at the peak of their youth";
                        break;
                    case Effect.EffectType.Size:
                        output += "is getting smaller";
                        break;
                }

                // Unfect message
                effects++;
            }

        }
        output += ".";
        return output;
    }

    private int[] CalcEffectSchema(Dictionary<Reagent.ReagentType, int> reagents)
    {
            int[] output = new int[Effect.effectCount];

        foreach (KeyValuePair<Reagent.ReagentType, int> rea in reagents)
        {

            Debug.Log("Next reagent = " + rea.Value);

            switch (rea.Key)
            {
                case Reagent.ReagentType.Crystal:
                    Debug.Log("Fire = " + (int)Effect.EffectType.Fire);
                    Debug.Log("output[0] = " + output[(int)Effect.EffectType.Fire]);
                    output[(int)Effect.EffectType.Fire] += rea.Value * -1;
                    output[(int)Effect.EffectType.Sprout] += rea.Value * -1;
                    Debug.Log("output[0] = " + output[(int)Effect.EffectType.Fire]);
                    break;
                case Reagent.ReagentType.Eyeball:
                    output[(int)Effect.EffectType.Petrification] += rea.Value;
                    break;
                case Reagent.ReagentType.Mushroom:
                    output[(int)Effect.EffectType.Size] += rea.Value;
                    break;
                case Reagent.ReagentType.Root:
                    output[(int)Effect.EffectType.Sprout] += rea.Value;
                    output[(int)Effect.EffectType.Size] += rea.Value;
                    break;
                case Reagent.ReagentType.Rose:
                    output[(int)Effect.EffectType.Fire] += rea.Value;
                    output[(int)Effect.EffectType.Health] += rea.Value;
                    break;
                case Reagent.ReagentType.Skull:
                    output[(int)Effect.EffectType.Size] += rea.Value * -1;
                    output[(int)Effect.EffectType.Age] += rea.Value;
                    break;
                case Reagent.ReagentType.Spider:
                    output[(int)Effect.EffectType.Health] += rea.Value * -1;
                    output[(int)Effect.EffectType.Petrification] += rea.Value * -1;
                    break;
                case Reagent.ReagentType.Urn:
                    output[(int)Effect.EffectType.Age] += rea.Value * -1;
                    break;
            }
        }

        String debug = "";
        for (int i = 0; i < output.Length; i++)
        {
            debug += output[i] + " : ";
        }
        Debug.Log("Count = " + debug);

        return output;
    }

    void Message(string message)
    {
        MessageBox.gameObject.SetActive(true);
        TargetText.text = message;
    }
}