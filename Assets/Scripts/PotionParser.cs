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
            else if (es.Values[i] < -1)
            {
                if (effects > 0 && (Effect.EffectType)i != Effect.EffectType.Petrification && (Effect.EffectType)i != Effect.EffectType.Sprout)
                {
                    output += ", ";
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
            else if (es.Values[i] == 1)
            {
                if (effects > 0)
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
                        output += "has turned into stone";
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
            else if (es.Values[i] == -1)
            {
                if (effects > 0 && (Effect.EffectType)i != Effect.EffectType.Petrification && (Effect.EffectType)i != Effect.EffectType.Sprout)
                {
                    output += ", ";
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

    private EffectSchema CalcEffectSchema(Dictionary<Reagent.ReagentType, int> reagents)
    {
        EffectSchema output = new EffectSchema();

        foreach (KeyValuePair<Reagent.ReagentType, int> rea in reagents)
        {

            switch (rea.Key)
            {
                case Reagent.ReagentType.Crystal:
                    output.Values[(int)Effect.EffectType.Fire]--;
                    output.Values[(int)Effect.EffectType.Sprout]--;
                    break;
                case Reagent.ReagentType.Eyeball:
                    output.Values[(int)Effect.EffectType.Petrification]++;
                    break;
                case Reagent.ReagentType.Mushroom:
                    output.Values[(int)Effect.EffectType.Size]++;
                    break;
                case Reagent.ReagentType.Root:
                    output.Values[(int)Effect.EffectType.Sprout]++;
                    output.Values[(int)Effect.EffectType.Size]++;
                    break;
                case Reagent.ReagentType.Rose:
                    output.Values[(int)Effect.EffectType.Fire]++;
                    output.Values[(int)Effect.EffectType.Health]++;
                    break;
                case Reagent.ReagentType.Skull:
                    output.Values[(int)Effect.EffectType.Size]--;
                    output.Values[(int)Effect.EffectType.Age]++;
                    break;
                case Reagent.ReagentType.Spider:
                    output.Values[(int)Effect.EffectType.Health]--;
                    output.Values[(int)Effect.EffectType.Petrification]--;
                    break;
                case Reagent.ReagentType.Urn:
                    output.Values[(int)Effect.EffectType.Age]--;
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