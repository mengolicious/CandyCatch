using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBee : MonoBehaviour 
{
	[SerializeField]
	private BeeMScript BeeManager;

	private void Start()
	{
		BeeManager = GameObject.FindGameObjectWithTag("BeeM") ? GameObject.FindGameObjectWithTag("BeeM").GetComponent<BeeMScript>()  : null;
	}

	private void SpawnWave()
	{
		if(BeeManager)
		{
			BeeManager.SpawnBeeWave();
		}
	}
}
