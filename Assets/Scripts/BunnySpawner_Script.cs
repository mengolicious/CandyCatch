using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class BunnySpawner_Script : MonoBehaviour {

	[SerializeField]
	List<Transform> spawnPoints;
	[SerializeField]
	List<int> indexList;
	[SerializeField]
	Object BunnyPrefab;

	// Use this for initialization
	void Start()
	{
		spawnPoints = new List<Transform>();
		indexList = new List<int>();
		for( int i = 0; i < this.transform.childCount; i ++)
		{
			spawnPoints.Add(transform.GetChild(i));
			indexList.Add(i);
		}
		BunnyPrefab = Resources.Load("Prefabs/Bunny");
		StartCoroutine(BunnySpawner());
	}

	IEnumerator BunnySpawner()
	{
		GameObject tempBunny = null;
		int tempI;
		while(true)
		{
			tempI = Random.Range(0, indexList.Count);
			if(tempBunny == null)
			{
				//do the bubble spawning code here since it's almost 4
				tempBunny = Instantiate(BunnyPrefab, spawnPoints[indexList[tempI]].position, Quaternion.identity) as GameObject;
				tempBunny.transform.localScale = spawnPoints[indexList[tempI]].localScale;
				tempBunny.GetComponent<BunnyScript>().SetIndex(indexList[tempI], this);
				indexList.RemoveAt(tempI);
			}
			yield return new WaitForSeconds(1.5f);
			if (SVM_Script.Instance.isBonus)
			{
				Destroy(this.gameObject);
				break;
			}
		}
	}

	public void BunnyGone(int spawnIndex)
	{
		indexList.Add(spawnIndex);
	}
}
