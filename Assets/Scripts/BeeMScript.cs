using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BeeMScript : MonoBehaviour
{
	[SerializeField]
	private List<GameObject> beeList;
	[SerializeField]
	private GM_1 gm;
	private int numberOfBEES;
	private GameObject tempBall;
	private float beeSpeed;
	private float queenBeeSpeed;
	private int beeValue;
	private List<Vector3> SpawnPoints;
	private List<int> SpawnIndices;
	private Object BeePrefab;
	private Object BeeBurstPrefab;
	private Object ScoreChangeSpritePrefab;
	private GameObject Hive;
	private bool isExpert;
	private Vector3 AngryBeeSpawnPoint;
	private Object AngryBeePrefab;
	private Object QueenBeePrefab;
	private GameObject BossBee;
	private Vector3 DirChangeLeft;
	private Vector3 DirChangeRight;
	private List<Material> bonusBallMattList;
	private int waveCount;
	private bool isSpawningWave;
	public GameObject tapBees;
	public GameObject tapQueenBee;
	public GameObject avoidSoldierBee;
	// Use this for initialization
	void Start ()
	{
		waveCount = 0;
		beeList = new List<GameObject>();
		SpawnPoints = new List<Vector3>();
		SpawnIndices = new List<int>();
		beeValue = 1;
		BeePrefab = Resources.Load("Prefabs/BeeEnemy");
		BeeBurstPrefab = Resources.Load("Prefabs/BeeBurst");
		ScoreChangeSpritePrefab = Resources.Load("Prefabs/ScoreChangeSprite");
		AngryBeePrefab = Resources.Load("Prefabs/SoldierBee");
		QueenBeePrefab = Resources.Load("Prefabs/QueenBee");
		//---------------------should be null checking in this region----------------------------------//
		AngryBeeSpawnPoint = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<Transform>().position;
		Hive = GameObject.FindGameObjectWithTag("BeeHive"); //So we can move the BeeHive and not worry about it's position-Need to instantiate the Background with BeeHive
		gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GM_1>();
		//---------------------end of where null checking should be done-------------------------------//
		for( int x = 0; x < 5; ++x)
		{
			SpawnPoints.Add(transform.GetChild(x).position);
			SpawnIndices.Add(x);
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
		tapBees.SetActive(true);
		StartCoroutine(ReleaseTheBees());
	}

	public void SwitchToBonusRound()
	{
		//load the prefab for the bonus round bees, whatever they bee called cap'n
		BeePrefab =			Resources.Load("prefabs/BonusWave/BonusBee");//Load the bonus round bee
		QueenBeePrefab =	Resources.Load("prefabs/BonusWave/BossBee");//Load the boss queen bee to spawn the bonus bee waves
		bonusBallMattList = new List<Material>
		{
			Resources.Load<Material>("Materials/BonusAnswers/Ball_add"),
			Resources.Load<Material>("Materials/BonusAnswers/Ball_sub")
		};
		if(SVM_Script.gameDifficulty == "advance")
		{
			bonusBallMattList.Add(Resources.Load<Material>("Materials/BonusAnswers/Ball_mul"));
		}
		else if(SVM_Script.gameDifficulty == "expert")
		{
			bonusBallMattList.Add(Resources.Load<Material>("Materials/BonusAnswers/Ball_mul"));
			bonusBallMattList.Add(Resources.Load<Material>("Materials/BonusAnswers/Ball_div"));
		}
		Destroy(Hive);
		BossBee = Instantiate(QueenBeePrefab) as GameObject;
		SpawnPoints.Clear();
		SpawnIndices.Clear();
		for(int i = 0; i < BossBee.transform.childCount; i++)
		{
			SpawnPoints.Add(BossBee.transform.GetChild(i).position);
		}
	}

	public void EndBonuStage()
	{
		for(int i = 0; i < beeList.Count; i++)
		{
			Destroy(beeList[i]);
		}
		beeList.Clear();
		StopAllCoroutines();
	}

	public void SpawnBeeWave()
	{
		if(!isSpawningWave)
		{
			StartCoroutine(BeeWaveSpawner());
			isSpawningWave = true;
		}
	}

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
			tI = Random.Range(0, SpawnIndices.Count);
			//Vector3 shiftPos = new Vector3(0f, Random.Range (-2.5f,2.5f), 0f);
			tempBee = Instantiate(BeePrefab, SpawnPoints[SpawnIndices[tI]], Quaternion.identity) as GameObject;
			tempBee.name = "Bee";
			tempBee.GetComponent<Bee_Script>().InitialiseVariables(tempBall, beeSpeed, beeValue, BeeBurstPrefab, ScoreChangeSpritePrefab, Hive.transform.position, this);
			//tempBee.GetComponent<Bee_Script>().value = tempValue;
			beeList.Add(tempBee);
			SpawnIndices.RemoveAt(tI);
			yield return null;
		}

		//---------------------------Start of Queen Bee--------------------------//
		if(isExpert)
		{
			//Debug.Log("The Queen cometh");
			tI = Random.Range(0, SpawnPoints.Count);
			//Vector3 shiftPos = new Vector3(0f, Random.Range (-2.5f,2.5f), 0f);
			tempQueenBee = Instantiate(QueenBeePrefab, SpawnPoints[SpawnIndices[tI]], Quaternion.identity) as GameObject;
			tempQueenBee.name = "Queen Bee";
			tempQueenBee.transform.GetChild(0).GetComponent<QueenBeeScript>().InitialiseVariables(tempBall, queenBeeSpeed, beeValue, BeeBurstPrefab, ScoreChangeSpritePrefab, Hive.transform.position, this);
			//tempBee.GetComponent<Bee_Script>().value = tempValue;
			beeList.Add(tempQueenBee);
			SpawnIndices.RemoveAt(tI);
		}
		//---------------------------END of Queen Bee--------------------------//
	}

	IEnumerator BeeWaveSpawner()
	{
		GameObject tempBee;
		int tV;
		waveCount++;
		if(waveCount > 5)
		{
			gm.ResetQuestion();
			waveCount = 1;
			yield return new WaitForSeconds(3f);
		}
		BossBee.GetComponent<Animator>().Play("QueenBossSpawn");
		//Debug.Log ("Spawning " + numberOfBEES + " Bees");
		for(int x = 0; x < SpawnPoints.Count; x++)
		{
			//beeValue = Random.Range(1, maxBeeValue+1);
			tV = /*x < bonusBallMattList.Count ? x : */Random.Range(0, bonusBallMattList.Count);
			//Vector3 shiftPos = new Vector3(0f, Random.Range (-2.5f,2.5f), 0f);
			tempBee = Instantiate(BeePrefab, SpawnPoints[x], Quaternion.identity) as GameObject;
			tempBee.name = "Bonus Bee";
			tempBee.GetComponent<BonusBeeScript>().InitialiseVariables(beeSpeed, tV+1, BeeBurstPrefab, ScoreChangeSpritePrefab, this, bonusBallMattList[tV]);
			//tempBee.GetComponent<Bee_Script>().value = tempValue;
			beeList.Add(tempBee);
			//yield return new WaitForSeconds(0.3f);
			yield return new WaitForSeconds(0.6f);
		}
		isSpawningWave = false;
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
		if (!SVM_Script.Instance.isBonus)
		{
			StartCoroutine(ClearListCoRoutine());
		}
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
		bool notPopped = true;
		GameObject tempAngryBee = null;
		while(!SVM_Script.Instance.isBonus)
		{
			if(!tempAngryBee)
			{
				tempAngryBee = Instantiate(AngryBeePrefab, AngryBeeSpawnPoint, Quaternion.identity) as GameObject;
				tempAngryBee.name = "Angry Bee";
				tempAngryBee.GetComponent<AngryBee_Script>().isExpert = isExpert;
				tempAngryBee.GetComponent<AngryBee_Script>().scoreChangeSpritePos = transform.position;
				tempAngryBee.GetComponent<AngryBee_Script>().ScoreChangeSpritePrefab = Resources.Load("Prefabs/ScoreChangeSprite");
				tempAngryBee.GetComponent<AngryBee_Script>().DirChangeLeft = DirChangeLeft;
				tempAngryBee.GetComponent<AngryBee_Script>().DirChangeRight = DirChangeRight;
			}
			yield return new WaitForSeconds(1.0f);
			if(notPopped)
			{
				avoidSoldierBee.SetActive(true);
				notPopped = false;
			}
		}
		if(tempAngryBee)
		{
			tempAngryBee.GetComponent<AngryBee_Script>().DestroySelf();
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
		SpawnIndices.Clear();
		//Reset the indicies for the spawning of new bees
		for ( int x = 0; x < 5; ++x)
		{
			SpawnIndices.Add(x);
		}
	}

	IEnumerator ClearBonusListCoRoutine()
	{
		yield return null;
		/*for (int x = 0; x < beeList.Count; x++)
		{
			if (!beeList[x])
				beeList.RemoveAt(x);
			else
				beeList[x].GetComponent<Bee_Script>().ClearTarget();
			yield return null;
		}// */
	}

	public void ReduceTime()
	{
		gm.TM.ReduceTime();
	}
}
