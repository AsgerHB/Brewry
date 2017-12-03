using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Objective : MonoBehaviour {

	public List<int> CorrectEffect;
	public List<string> EffectName;


	public UnityEvent LoadingNextLevel;
	public string NextLevel;

	private Cauldron _cauldron;
	
	
	public void CheckObjective(int[] effect)
	{
		StringBuilder sb = new StringBuilder("Comparing:\n");
		sb.Append(string.Join(" ", effect.Select(x => x.ToString()).ToArray()));
		sb.Append(string.Join(" ", CorrectEffect.Select(x => x.ToString()).ToArray()));
		Debug.Log(sb);
		
		
		//If effects are all correct
		for (int i = 0; i < Effect.effectCount; i++)
		{
			if (CorrectEffect[i] != effect[i])
				return;
		}
		
		LoadingNextLevel.Invoke();
		SceneManager.LoadScene(NextLevel);
	}
	
	
	// Use this for initialization
	void Start ()
	{
		_cauldron = GameObject.FindGameObjectWithTag("Cauldron").GetComponent<Cauldron>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
