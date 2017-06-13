using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EasyObjectsScript : MonoBehaviour
{
	private List<Transform> BubbleSpawns;
	private List<GameObject> BubbleList;
	private List<int> tempIndexList;
	//private List<string> colourList;
	private List<Color> colourList;
	private Object bubblePrefab;

	void Start()
	{
		BubbleSpawns = new List<Transform>();
		BubbleList = new List<GameObject>();
		tempIndexList = new List<int>();
		//colourList = new List<string>();
		colourList = new List<Color>();
		bubblePrefab = Resources.Load("Prefabs/Bubble");
		for (int i = 0; i < 6; i++)
		{
			BubbleSpawns.Add(transform.GetChild(i));
		}
		/*
		colourList.Add("00adef");
		colourList.Add("5ec19e");
		colourList.Add("9a519f");
		colourList.Add("fbe044");
		colourList.Add("f7964f");
		colourList.Add("8bc75d");
		colourList.Add("7f64ac");
		colourList.Add("ee3d3b");
		colourList.Add("89d2d7");
		*/

		colourList.Add(new Color(0f, 0.7f, 0.85f, 1f));
		colourList.Add(new Color(0.4f, 0.85f, 0.1f, 1f));
		colourList.Add(new Color(0.85f, 0.55f, 0.9f, 1f));
		colourList.Add(new Color(0.95f, 0.1f, 0.85f, 1f));
		colourList.Add(new Color(0.95f, 0.8f, 0.3f, 1f));
		colourList.Add(new Color(0.75f, 0.85f, 0.3f, 1f));
		colourList.Add(new Color(0.7f, 0.6f, 0.55f, 1f));
		colourList.Add(new Color(0.93f, 0.2f, 0.19f, 1f));
		colourList.Add(new Color(0.79f, 0.85f, 0.86f, 1f));

		StartCoroutine (BubbleSpawner ());
	}

	/// <summary>
	/// Move to Easy BG Script when made
	/// </summary>
	/// <returns></returns>
	IEnumerator BubbleSpawner()
	{
		for (int i = 0; i < BubbleSpawns.Count; i++)
		{
			tempIndexList.Add(i);
		}
		int x;
		GameObject tempBubble;
		//Color tempColour;
		int tempI;
		while (true)
		{
			x = Random.Range(0, tempIndexList.Count);
			tempI = Random.Range(0, colourList.Count);
			if (BubbleList.Count < 6)
			{
				tempBubble = Instantiate(bubblePrefab, BubbleSpawns[tempIndexList[x]].position, Quaternion.identity) as GameObject;
				BubbleList.Add(tempBubble);
				tempBubble.GetComponent<BackgroundBubble_Script>().InitialiseVariables(BubbleSpawns[tempIndexList[x]].position, BubbleSpawns[tempIndexList[x]].localScale.x, tempIndexList[x], Random.Range(0.1f, 0.6f), this);
				//if(Color.TryParseHexString(colourList[tempI], out tempColour))  //this is DEPRECIATED in latest version Unity 5.6
				//{
				//tempBubble.GetComponent<SpriteRenderer>().color = tempColour;

				tempBubble.GetComponent<SpriteRenderer>().color = colourList[tempI];

				//}
				tempIndexList.RemoveAt(x);
			}
			yield return new WaitForSeconds(1.5f);
			if(SVM_Script.Instance.isBonus)
			{
				Destroy(this.gameObject);
				break;
			}
		}
	}
	
	/// <summary>
	/// Easy BG Script when made
	/// </summary>
	/// <param name="spawnIndex"></param>
	/// <param name="bubble"></param>
	public void BubbleDestroyed(int spawnIndex, GameObject bubble)
	{
		tempIndexList.Add(spawnIndex);
		BubbleList.Remove(bubble);
	}
}

