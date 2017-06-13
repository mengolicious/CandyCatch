using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ExpertObjectsScript : MonoBehaviour {

	public GameObject tumbleWeedClone;
	public Object tumbleweedPrefab;
	public int tempIndexTumbleweed;
	public float tempZ;
	public float tempY;
	public float tempScale;
	public Color tempColor;
	public int lifeTest1;
	public int tempValue1;
	
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

			tempIndexTumbleweed = (int)(Random.Range(1.0f, 4.0f));
			Debug.Log (tempIndexTumbleweed);

			if(tempIndexTumbleweed<2){
				tempZ = -0.05f;
				tempY = 2.0f;
				tempScale = 0.15f;
				lifeTest1 = 2;
				tempValue1 = 1;
				tempColor = new Color(0.5f,0.4f,0.0f,1.0f);

			}
			else if(tempIndexTumbleweed<3){
				tempZ = -0.15f;
				tempY = 0.5f;
				tempScale = 0.25f;
				lifeTest1 = 3;
				tempValue1 = 2;
				tempColor = new Color(0.4f,0.3f,0.0f,1.0f);
			}
			else{
				tempZ = -0.25f;
				tempY = 0;
				tempScale = 0.4f;
				lifeTest1 = 4;
				tempValue1 = 3;
				tempColor = new Color(0.2f,0.1f,0.0f,1.0f);
			}

			tumbleWeedClone = Instantiate(tumbleweedPrefab, RightStartPos+new Vector3(0,tempY,tempZ), Quaternion.identity) as GameObject;
			tumbleWeedClone.transform.localScale = new Vector3(tempScale,tempScale,tempScale);
			tumbleWeedClone.GetComponent<TumbleweedScript>().lifeTest = lifeTest1;
			tumbleWeedClone.GetComponent<TumbleweedScript>().tempValue = tempValue1;
			tumbleWeedClone.GetComponent<TumbleweedScript>().StartRolling();
			tumbleWeedClone.GetComponent<SpriteRenderer>().color = tempColor;

			yield return new WaitForSeconds(4.0f);

			if(SVM_Script.Instance.isBonus)
			{
				Destroy(this.gameObject);
				break;
			}
		}
	}
	
	IEnumerator InstantiateClouds(){
		while (true) {
			
			//Start set the sprite for clouds
			tempIndexCloud = (int)(Random.Range(0.0f, 6.0f));

			cloudsSprite = Resources.Load<Sprite> ("Sprites/Clouds/Cloud-0"+tempIndexCloud) as Sprite;
			
			//END set the sprite for clouds
			
			cloudsClone = Instantiate(cloudsPrefab, RightStartPos + new Vector3(0,4.0f,0), Quaternion.identity) as GameObject;
			cloudsClone.GetComponent<SpriteRenderer>().sprite = cloudsSprite;
			cloudsClone.transform.localScale = new Vector3(0.5f+(tempIndexCloud/8),0.5f+(tempIndexCloud/8),1f);
			yield return new WaitForSeconds(3.0f*tempIndexCloud);
			
			
		}
		
	}
}
