using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EasyObjectsScript : MonoBehaviour {



	public GameObject tumbleWeedClone;
	public Object tumbleweedPrefab;


	public GameObject StartPos;
	public GameObject EndPos;

	public Vector3 RightStartPos;
	public Vector3 LeftEndPos;

	public GameObject cloudsClone;
	public Object cloudsPrefab;
	public Sprite cloudsSprite;
	public int tempIndexCloud;
	public List<Object> listCloudObjects;

	// Use this for initialization
	void Start () {
	
		//matBallList.Add(Resources.Load<Material>("Materials/Ball_MAT"+i));
		InitializeObjects ();


		StartCoroutine (InstantiateTumbleweed ());
		StartCoroutine (InstantiateClouds ());


	}

	void InitializeObjects(){

		tumbleweedPrefab = Resources.Load<Object> ("Prefabs/BG/ExpertObjects/Tumbleweed");
		cloudsPrefab = Resources.Load<Object> ("Prefabs/BG/ExpertObjects/Cloud");



		RightStartPos = StartPos.transform.position;
		LeftEndPos = EndPos.transform.position;

		//Start for Clouds
		listCloudObjects = new List<Object>();


		//END for Clouds

	}

	IEnumerator InstantiateTumbleweed(){
		while (true) {
			tumbleWeedClone = Instantiate(tumbleweedPrefab, RightStartPos + new Vector3(0,0,0), Quaternion.identity) as GameObject;
			tumbleWeedClone.transform.localScale = new Vector3(0.4f,0.4f,0.4f);
			yield return new WaitForSeconds(15.0f);
		}
	}

	IEnumerator InstantiateClouds(){
		while (true) {

			//Start set the sprite for clouds
			tempIndexCloud = (int)(Random.Range(0.0f, 6.0f));
			Debug.Log (tempIndexCloud);
			cloudsSprite = Resources.Load<Sprite> ("Sprites/Clouds/Cloud-0"+tempIndexCloud) as Sprite;

			//END set the sprite for clouds

			cloudsClone = Instantiate(cloudsPrefab, RightStartPos + new Vector3(0,4.0f,0), Quaternion.identity) as GameObject;
			cloudsClone.GetComponent<SpriteRenderer>().sprite = cloudsSprite;
			cloudsClone.transform.localScale = new Vector3(0.5f+(tempIndexCloud/8),0.5f+(tempIndexCloud/8),1f);
			yield return new WaitForSeconds(3.0f*tempIndexCloud);


		}

	}
}

