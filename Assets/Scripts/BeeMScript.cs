using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BeeMScript : MonoBehaviour {
	private List<GameObject> beeList;
	private int numberOfBEES;
	private GameObject tempBall;
	private float beeSpeed;
	private int beeValue;
	private List<Vector3> SpawnPoints;
	private List<Vector3> UsedSpawnPoints;
	private Object BeePrefab;
	private Object BeeBurstPrefab;
	private Object ScoreChangeSpritePrefab;
	private int maxBeeValue;
	public GameObject Hive;
	// Use this for initialization
	void Start () {
		beeList = new List<GameObject>();
		SpawnPoints = new List<Vector3>();
		UsedSpawnPoints = new List<Vector3>();
		beeValue = 1;
		BeePrefab = Resources.Load("Prefabs/BeeEnemy");
		BeeBurstPrefab = Resources.Load("Prefabs/BeeBurst");
		ScoreChangeSpritePrefab = Resources.Load("Prefabs/ScoreChangeSprite");
		for( int x = 0; x < 5; ++x)
		{
			SpawnPoints.Add(transform.GetChild(x).position);
		}
		//Checking Difficulty and setting amount of bees to be spawned
		if (SVM_Script.gameDifficulty == "easy") {
			numberOfBEES = 2;
			//maxBeeValue = 1;
			beeSpeed = 7.0f;
		}
		else if (SVM_Script.gameDifficulty == "advance") {
			numberOfBEES = 3;
			//maxBeeValue = 2;
			beeSpeed = 7.5f;
		}
		else if (SVM_Script.gameDifficulty == "expert") {
			numberOfBEES = 5;
			//maxBeeValue = 3;
			beeSpeed = 8f;
		}
	}

	/// <summary>
	/// Starts spawning the bees and sends them after the correct answer.
	/// </summary>
	/// <param name="targetBall">The Ball with the correct answer.</param>
	public void SpawnBees(GameObject targetBall)
	{
		tempBall = targetBall;
		StartCoroutine(ReleaseTheBees());
	}

	// Update is called once per frame
	/*void Update () {
	
	}*/

	/// <summary>
	/// Spawns the bees with a delay between each, number spawned based off of member variable.
	/// </summary>
	IEnumerator ReleaseTheBees()
	{
		Debug.Log ("Spawning " + numberOfBEES + " Bees");
		for(int x = 0; x < numberOfBEES; x++)
		{
			//beeValue = Random.Range(1, maxBeeValue+1);
			int tI = Random.Range(0,SpawnPoints.Count);
			//Vector3 shiftPos = new Vector3(0f, Random.Range (-2.5f,2.5f), 0f);
			GameObject tempBee = GameObject.Instantiate(BeePrefab, SpawnPoints[tI], Quaternion.identity) as GameObject;
			tempBee.GetComponent<Bee_Script>().InitialiseVariables(tempBall, beeSpeed, beeValue,BeeBurstPrefab,ScoreChangeSpritePrefab, Hive.transform.position, this);
			//tempBee.GetComponent<Bee_Script>().value = tempValue;
			beeList.Add(tempBee);
			UsedSpawnPoints.Add(SpawnPoints[tI]);
			SpawnPoints.RemoveAt(tI);
			yield return null;
		}
	}

	/// <summary>
	/// Clears the bees.
	/// </summary>
	public void ClearBees()
	{
		StartCoroutine(ClearListCoRoutine());
	}

	public void HiveShake(int BeeValue)
	{
		//StartCoroutine(ShakeHive());
		Hive.GetComponent<Animator>().Play("HiveShake");
		/*GameObject tempParticle = Instantiate(ScoreChangeSpritePrefab, Hive.transform.position, Quaternion.identity) as GameObject;
		tempParticle.GetComponent<ScoreModifierSprite>().SetNumber(BeeValue, false, true);//*/
	}

	IEnumerator ShakeHive()
	{
		bool firstRun = true;
		while(firstRun)
		{
			Hive.GetComponent<Animator>().Play("HiveShake");
			firstRun = false;
			yield return null;
		}
	}

	IEnumerator ClearListCoRoutine()
	{
		for(int x = 0; x < beeList.Count; x++)
		{
			if(!beeList[x])
				beeList.RemoveAt(x);
			else
			{
				beeList[x].GetComponent<Bee_Script>().ClearTarget();
			}
			yield return null;
		}
		//beeList.Clear();
		SpawnPoints.Clear();
		UsedSpawnPoints.Clear();
		for( int x = 0; x < 5; ++x)
		{
			SpawnPoints.Add(transform.GetChild(x).position);
		}
	}
}
