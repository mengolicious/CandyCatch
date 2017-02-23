using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TimeManagerScript : MonoBehaviour {

	public float timeStarted;
	public int elapsedTime;
	public string timeInString;
	public char tempChar;
	public int tempLength;
	public GameObject tempNumDisplay;
	public GameObject timeCanvas;

	public int tempNum;
	public int tempNumV2;
	public Image firstNum;
	public Image secondNum;
	public Image thirdNum;
	public Image fourthNum;



	public Sprite num0;
	public Sprite num1;
	public Sprite num2;
	public Sprite num3;
	public Sprite num4;
	public Sprite num5;
	public Sprite num6;
	public Sprite num7;
	public Sprite num8;
	public Sprite num9;
	public Sprite period;

	public List<Sprite> listNumImages;
	public List<Image> listDisplayImages;

	public Object timePrefabNum;
	public GameObject timeStartingPos;


	// Use this for initialization

	void Awake(){
		InitializeTime();
	}

	void Start () {

		listNumImages = new List<Sprite>();
		listNumImages.Add (num0);
		listNumImages.Add (num1);
		listNumImages.Add (num2);
		listNumImages.Add (num3);
		listNumImages.Add (num4);
		listNumImages.Add (num5);
		listNumImages.Add (num6);
		listNumImages.Add (num7);
		listNumImages.Add (num8);
		listNumImages.Add (num9);
		listNumImages.Add (period);

		listDisplayImages = new List<Image>();
		listDisplayImages.Add (firstNum);
		listDisplayImages.Add (secondNum);
		listDisplayImages.Add (thirdNum);
		listDisplayImages.Add (fourthNum);


		StartCoroutine (UpdateTime ());

	}
	
	// Update is called once per frame
	void Update () {

	}

	public void InitializeTime(){
		timeStarted = Time.time;


	}

	IEnumerator UpdateTime(){
		while(true){

			elapsedTime = (int)(Time.time - timeStarted);
			timeInString = elapsedTime.ToString ();
			tempChar = timeInString [0];
			tempLength = timeInString.Length;

			tempNumV2 = 3;
			for(int x=timeInString.Length; x>0; x--){
				tempNum = (int)char.GetNumericValue(timeInString[x-1]);
				listDisplayImages[tempNumV2].sprite = listNumImages[tempNum];
				tempNumV2--;
			}

//			tempNumV2 = 3;
//			for(int x=0; x<timeInString.Length; x++){
//				tempNum = (int)char.GetNumericValue(timeInString[x]);
//				listDisplayImages[tempNumV2].sprite = listNumImages[tempNum];
//				tempNumV2--;
//			}

			yield return new WaitForSeconds(0.5f);
		}
	}



	public void DisplayTime(){

	}
}
