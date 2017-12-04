using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PotionParser : MonoBehaviour
{
    public GameObject MessageBox;
    public Text TargetText;
    public Cauldron Cauldron;
    public GameObject ZalgoMessage;

    private Objective _objective;
    
    private void Start()
    {
        var objectiveGameObject = GameObject.FindGameObjectWithTag("Objective");
        if (objectiveGameObject != null)
        {
            _objective = objectiveGameObject.GetComponent<Objective>();
        }
    }

    public void ParsePotion()
    {
        Dictionary<Reagent.ReagentType, int> reagents = Cauldron.Reagents;

        /*String debug = "";
        foreach (KeyValuePair<Reagent.ReagentType, int> rea in reagents)
        {
            debug += rea.Value + " : ";
        }
        Debug.Log("Regent input = " + debug);*/

        /*
         *T͉o̖͔̬̲͙̲ ̬̱͇̘͔̗in̲̦͇̫͚̼v̡͍̜o̧̲̥͈͕k͝e̹̞͎ ̩̩̦͇̹͠ͅt̠̣̟̘̟̣͉h̛̹̹̻͓̺̞̖e͓̭̣͍͙̰̻͠ ̺̯̲ͅͅḥ̬͖̩̫̣i͕͈v̷͓̬̝̬e̙̲͝-m̷͍̹̠̣̯͕̣i̷̳͎̼̰͓ͅn̘̱̟̪͡d̯̬͚ ̻͖̫̥r̡e̶̩̮̦̥̰̙ͅp̱r̦͍̪̪͢ẹ̟̟͎̻̭̲s̱̕e̷̺̝̘͉̭͈ͅn̼͈͎t̶̝i̺̲̰͕͍̫n̸̮͈g͇̙̱̝̠͇͘ ̟̬̹̻͉c̬͉̰̖͖̩̩h̠̺̲a̼̬o̺͕̳ș.͕̺̩͔͠
         * ̛̥̪̜I̥͟n̷̼̻̼v̭̀o̷̱̩̟̯̼k̷͈i̭͢n̟̩̟͙g̞̖̭͕̘ ͞ͅt͈͈́ͅh̟̩e̸̟͎̝ͅ f̷̞͖̲̺e͇͇e̶̤l̟̭̪̕i̘̜̫̘̞̣̯ņg̟̝ ̺͕o̻͇̪͚͇̬f͎̮̟̝̗ ͏͈̜͉͍̮c̥̮̜̥̙̘̞ha͍̣͔̥̺ͅo̖̮̭̣̥ṣ̳͙̲͈̘͜.̥͚̟͜
         * W̴̠̞̯i͈͈̫t̵̺͙͚̙̝h̘̩͍̣ ̫̺͙̣̪ͅo̺u͚̭̘̰̟t̢͇͓͈͖̹ ̨ǫ͈̻͇r̦d͔̜̝̲̺̩e̸͓̝̠̼͖̬r̥͙̯.̘̠͓̣̗̥ͅ
         * ̟̺̣T̴̰͖͍̙͚ͅh̼̟̙e̪̥̼̤͎̯͝ ̢̺͖̘̭̲̻N̰̪̰e̢̯̬͚̣̩͍ẕ̰̬̲p̶͍̙̤̰̠͉ͅe̫̮̰̲r͏̫d̜i̵͇͇a̶̜͓̤͍̬͇͔ṇ̶̮͚̹̗̳ ̶̟h̝͈̳͈̣ͅi̢͕v̦͇͈̫̮̺ͅe͢-̳͇̝̭m͙̩͚̰̘i̪̺̜̭n̯̣ḍ̩̱̦̘ ̴̗o̭̭͔̹̳̹̳f̝̘̪̼̬͔̱ ̱c̲͈h͡a̘o̮̲̖̗̬̜s̥̖͕̜.̨̬̫̪̼̭̰͍ ̳Ẓ̪̥a͓̗l͙̯̩̻̮g͕͓͓͘ò̬̳͍̦ͅ.̪͇
         * ̜̺͉̳́H̬͠e̟ ͔͔̹̩̲̣͖w̸̬h̙̖̣o͔̠ ̤W̱̟̘̲͢ạḭ͝t̥̬̠̼̞̺̳ṣ̱͖̩̱̼ ͇̖͔̲͢B̡̤ͅe̺h̪̖̜͍͇̞͔͢i͓̝̞͉͉̙̤n̸̲̫̝̣̦͉̱d͟ ̠̗̮̘T̰͔͎̦̳̤͙́h̯͈̯̯̩̘ḛ̠̞̝ ̷͎͖̬W̼̤̫a͖̠͢l̰̠͘l͚̹̻͓.̰͕͉̞͈̪
         * ̹͙̠̭͇Z̞͙A̗͈͈̠̦L̷G̤͔O!̻́ 
         */
        if (reagents[Reagent.ReagentType.Urn] > 10)
        {
            ZALGO();
            Cauldron.Clear();
            return;
        }
        
        int[] effectSchema = CalcEffectSchema(reagents);

        String mes = CalcMessage(effectSchema);

        Message(mes);

        Cauldron.Clear();

        if (_objective != null)
        {
            _objective.CheckObjective(effectSchema);
        }
    }

    private string CalcMessage(int[] es)
    {
        string his = SelectPronoun();
        
        String output = "The customer ";
        int effects = 0;

        /*String debug = "";
        for (int i = 0; i < es.Length; i++)
        {
            debug += es[i] + " : ";
        }
        Debug.Log("Count = " + debug);*/


        int effectCount = es.Where(x => x != 0).Count();

        //Debug.Log("Eff Count = " + effectCount);

        for (int i = 0; i < Effect.effectCount; i++)
        {
            // Overdose message
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
                switch ((Effect.EffectType)i)
                {
                    case Effect.EffectType.Fire:
                        output += "has burst into bright flames";
                        break;
                    case Effect.EffectType.Health:
                        output += "became so healthy that " + his + " heart exploded";
                        break;
                    case Effect.EffectType.Age:
                        output += "aged rapidly until only a pile of dust remains";
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
            // Underdose message
            else if (es[i] < -1)
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
                        output += "is now a block of ice";
                        break;
                    case Effect.EffectType.Health:
                        output += "has died";
                        break;
                    case Effect.EffectType.Age:
                        output += "reverse-ages into first an infant and then into a single point of brief light";
                        break;
                    case Effect.EffectType.Size:
                        output += "is now a giant";
                        break;
                }

                effects++;
            }
            // Effect message
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
                        output += "is being healed";
                        break;
                    case Effect.EffectType.Age:
                        output += "is aging unsettlingly fast";
                        break;
                    case Effect.EffectType.Petrification:
                        output += "has turned to stone";
                        break;
                    case Effect.EffectType.Size:
                        output += "is becoming taller";
                        break;
                    case Effect.EffectType.Sprout:
                        output += "has begun sprouting leaves";
                        break;
                }

                effects++;
            }
            // Reverse effect message
            else if (es[i] == -1)
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
                        output += "is freezing and has blue lips";
                        break;
                    case Effect.EffectType.Health:
                        output += "is not feeling well";
                        break;
                    case Effect.EffectType.Age:
                        output += "has reverted back to the peak of " + his + " youth";
                        break;
                    case Effect.EffectType.Size:
                        output += "is shrinking a bit";
                        break;
                }

                effects++;
            }

        }
        output += ".";
        return output;
    }

    private string SelectPronoun()
    {
        float r = Random.Range(0, 1);
        
        if (r < 0.47)
        {
            return "his";
        }
        else if ((0.47 <= r) && (r < 0.94))
        {
            return "her";
        }
        else
        {
            return "their";
        }
    }

    private int[] CalcEffectSchema(Dictionary<Reagent.ReagentType, int> reagents)
    {
            int[] output = new int[Effect.effectCount];

        foreach (KeyValuePair<Reagent.ReagentType, int> rea in reagents)
        {

            //Debug.Log("Next reagent = " + rea.Value);

            switch (rea.Key)
            {
                case Reagent.ReagentType.Crystal:
                    //Debug.Log("Fire = " + (int)Effect.EffectType.Fire);
                    //Debug.Log("output[0] = " + output[(int)Effect.EffectType.Fire]);
                    output[(int)Effect.EffectType.Fire] += rea.Value * -1;
                    output[(int)Effect.EffectType.Sprout] += rea.Value * -1;
                    //Debug.Log("output[0] = " + output[(int)Effect.EffectType.Fire]);
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

            output[(int)Effect.EffectType.Sprout] = Mathf.Max(0, output[(int)Effect.EffectType.Sprout]);
            output[(int)Effect.EffectType.Petrification] = Mathf.Max(0, output[(int)Effect.EffectType.Petrification]);
        }

        /*String debug = "";
        for (int i = 0; i < output.Length; i++)
        {
            debug += output[i] + " : ";
        }
        Debug.Log("Count = " + debug);*/

        return output;
    }

    public void Message(string message)
    {
        MessageBox.gameObject.SetActive(true);
        TargetText.text = message;
    }

    void      ZALGO     (         )
    {
        if (ZalgoMessage != null)
        {
            ZalgoMessage.SetActive(true);
        }
    }
}