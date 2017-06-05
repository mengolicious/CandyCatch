using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BeeMScript : MonoBehaviour
{
	[SerializeField]
	private List<GameObject> beeList;
	private int numberOfBEES;
	private GameObject tempBall;
	private float beeSpeed;
	private float queenBeeSpeed;
	private int beeValue;
	private List<Vector3> SpawnPoints;
	private List<Vector3> UsedSpawnPoints;
	private Object BeePrefab;
	private Object BeeBurstPrefab;
	private Object ScoreChangeSpritePrefab;
	public GameObject Hive;
	private bool isExpert;
	private Vector3 AngryBeeSpawnPoint;
	private Object AngryBeePrefab;
	private Object QueenBeePrefab;
	private Vector3 DirChangeLeft;
	private Vector3 DirChangeRight;
	// Use this for initialization
	void Start ()
	{
		beeList = new List<GameObject>();
		SpawnPoints = new List<Vector3>();
		UsedSpawnPoints = new List<Vector3>();
		beeValue = 1;
		BeePrefab = Resources.Load("Prefabs/BeeEnemy");
		BeeBurstPrefab = Resources.Load("Prefabs/BeeBurst");
		ScoreChangeSpritePrefab = Resources.Load("Prefabs/ScoreChangeSprite");
		AngryBeePrefab = Resources.Load("Prefabs/SoldierBee");
		QueenBeePrefab = Resources.Load("Prefabs/QueenBee");
		AngryBeeSpawnPoint = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<Transform>().position;

		Hive = GameObject.FindGameObjectWithTag("BeeHive"); //So we can move the BeeHive and not worry about it's position-Need to instantiate the Background with BeeHive

		for( int x = 0; x < 5; ++x)
		{
			SpawnPoints.Add(transform.GetChild(x).position);
		}
		DirChangeLeft = transform.GetChild(5).position;
		DirChangeRight = transform.GetChild(6).position;
		//Checking Difficulty and setting amount of bees to be spawned
		if(SVM_Script.gameDifficulty == "easy")
		{
			numberOfBEES = 2;
			//maxBeeValue = 1;
			beeSpeed = 6.0f;
			isExpert = false;
		}
		else if(SVM_Script.gameDifficulty == "advance")
		{
			numberOfBEES = 3;
			//maxBeeValue = 2;
			beeSpeed = 6.5f;
			isExpert = false;
			StartCoroutine(AngryBeeSpawner());
		}
		else if(SVM_Script.gameDifficulty == "expert")
		{
			numberOfBEES = 2;
			//maxBeeValue = 3;
			beeSpeed = 7f;
			queenBeeSpeed = 5.5f;

			isExpert = true;
			StartCoroutine(AngryBeeSpawner());
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
		GameObject tempBee;
		GameObject tempQueenBee;
		int tI;
		//Debug.Log ("Spawning " + numberOfBEES + " Bees");
		for(int x = 0; x < numberOfBEES; x++)
		{
			//beeValue = Random.Range(1, maxBeeValue+1);
			tI = Random.Range(0,SpawnPoints.Count);
			//Vector3 shiftPos = new Vector3(0f, Random.Range (-2.5f,2.5f), 0f);
			tempBee = GameObject.Instantiate(BeePrefab, SpawnPoints[tI], Quaternion.identity) as GameObject;
			tempBee.GetComponent<Bee_Script>().InitialiseVariables(tempBall, beeSpeed, beeValue,BeeBurstPrefab,ScoreChangeSpritePrefab, Hive.transform.position, this);
			//tempBee.GetComponent<Bee_Script>().value = tempValue;
			beeList.Add(tempBee);
			UsedSpawnPoints.Add(SpawnPoints[tI]);
			SpawnPoints.RemoveAt(tI);
			yield return null;
		}

		//---------------------------Start of Queen Bee--------------------------//
		if(isExpert){
			Debug.Log ("The Queen cometh");
			tI = Random.Range(0,SpawnPoints.Count);
			//Vector3 shiftPos = new Vector3(0f, Random.Range (-2.5f,2.5f), 0f);
			tempQueenBee = GameObject.Instantiate(QueenBeePrefab, SpawnPoints[tI], Quaternion.identity) as GameObject;
			tempQueenBee.transform.GetChild(0).GetComponent<QueenBeeScript>().InitialiseVariables(tempBall, queenBeeSpeed, beeValue,BeeBurstPrefab,ScoreChangeSpritePrefab, Hive.transform.position, this);
			//tempBee.GetComponent<Bee_Script>().value = tempValue;
			//beeList.Add(tempBee); //add this back ***
			UsedSpawnPoints.Add(SpawnPoints[tI]);
			SpawnPoints.RemoveAt(tI);

		}
		//---------------------------END of Queen Bee--------------------------//
	}

	public bool BeesAlive()
	{
		if (beeList.Count > 0)
		{
			return true;
		}
		else
		{
			return false;
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

	public void RemoveBee(GameObject bee)
	{
		beeList.Remove(bee);
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

	IEnumerator AngryBeeSpawner()
	{
		GameObject tempAngryBee = null;
		while(true)
		{
			if(!tempAngryBee)
			{
				tempAngryBee = GameObject.Instantiate(AngryBeePrefab, AngryBeeSpawnPoint, Quaternion.identity) as GameObject;
				tempAngryBee.GetComponent<AngryBee_Script>().isExpert = isExpert;
				tempAngryBee.GetComponent<AngryBee_Script>().scoreChangeSpritePos = transform.position;
				tempAngryBee.GetComponent<AngryBee_Script>().ScoreChangeSpritePrefab = Resources.Load("Prefabs/ScoreChangeSprite");
				tempAngryBee.GetComponent<AngryBee_Script>().DirChangeLeft = DirChangeLeft;
				tempAngryBee.GetComponent<AngryBee_Script>().DirChangeRight = DirChangeRight;
			}
			yield return new WaitForSeconds(1.0f);
		}
	}

	IEnumerator ClearListCoRoutine()
	{
		for(int x = 0; x < beeList.Count; x++)
		{
			if(!beeList[x])
				beeList.RemoveAt(x);
			else
				beeList[x].GetComponent<Bee_Script>().ClearTarget();
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
