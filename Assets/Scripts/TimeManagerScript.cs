using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TimeManagerScript : MonoBehaviour
{

	public float timeStarted;
	public int elapsedTime;
	public string timeInString;
	public char tempChar;
	public int tempLength;
	public GameObject tempNumDisplay;
	public GameObject timeCanvas;

	//Start this is for Displaying Time in gameplay
	public int tempNum;
	public int tempNumV2;
	public Image firstNum;
	public Image secondNum;
	public Image thirdNum;
	public Image fourthNum;
	//END this is for Displaying Time in gameplay

	//Start this is for Displaying Target Time
	public int tempTargetTime;
	public Image firstNumTime;
	public Image secondNumTime;
	public Image thirdNumTime;
	public Image fourthNumTime;
	//END this is for Displaying Target Time

	public string minutesStr;
	public string secondsStr;

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
	public List<Image> listDisplayImagesTargetTime;

	public Object timePrefabNum;
	public GameObject timeStartingPos;

	public int BonusTime;
	// Use this for initialization

	void Awake()
	{
		InitializeTime();
	}

	void Start()
	{

		listNumImages = new List<Sprite>();
		listNumImages.Add(num0);
		listNumImages.Add(num1);
		listNumImages.Add(num2);
		listNumImages.Add(num3);
		listNumImages.Add(num4);
		listNumImages.Add(num5);
		listNumImages.Add(num6);
		listNumImages.Add(num7);
		listNumImages.Add(num8);
		listNumImages.Add(num9);
		listNumImages.Add(period);

		listDisplayImages = new List<Image>();
		listDisplayImages.Add(firstNum);
		listDisplayImages.Add(secondNum);
		listDisplayImages.Add(thirdNum);
		listDisplayImages.Add(fourthNum);


		listDisplayImagesTargetTime = new List<Image>();
		listDisplayImagesTargetTime.Add(firstNumTime);
		listDisplayImagesTargetTime.Add(secondNumTime);
		listDisplayImagesTargetTime.Add(thirdNumTime);
		listDisplayImagesTargetTime.Add(fourthNumTime);

		DisplayTargetTime ();
		StartCoroutine(UpdateTime());


	}

	public void InitializeTime()
	{
		timeStarted = Time.time;
	}

	IEnumerator UpdateTime()
	{
		int minutes;
		int seconds;
		while (true)
		{
			if (!SVM_Script.Instance.isBonus)
			{
				elapsedTime = (int)(Time.time - timeStarted);
				
			}
			else
			{
				//elapsedTime = //bonus time - time elasped since last check; BonusTime - (int)(Time.time - timeStarted); InitializeTime();
				BonusTime = (int)(BonusTime - 0.5f);
				elapsedTime = BonusTime;
			}
			minutes = elapsedTime / 60;
			seconds = elapsedTime % 60;

			DisplayTime (listDisplayImages, minutes, seconds);

			if(!SVM_Script.Instance.isBonus)
				yield return new WaitForSeconds(0.5f);
			else
				yield return new WaitForSeconds(1.0f);
		}
	}

	public void DisplayTargetTime(){

		int minutes;
		int seconds;

		tempTargetTime = SVM_Script.Instance.targetTime;
		minutes = tempTargetTime / 60;
		seconds = tempTargetTime % 60;

		DisplayTime (listDisplayImagesTargetTime, minutes, seconds);


	}



	public void DisplayTime(List<Image> targetImageList, int min, int sec)
	{ //Function to call on any part of Game that wants to display time
	  // targetImageList is a List of GameObject Images to Display Time
	  // min is minutes and sec is seconds 
	
		if (sec > 9)
		{

			secondsStr = sec.ToString();
		}
		else
		{
			secondsStr = "0" + sec.ToString();
		}

		if (min > 9)
		{
			if (min > 99)
			{
				min = 99;   // temporary fix for exceeding 99 minutes
			}
			minutesStr = min.ToString();
		}
		else
		{
			minutesStr = "0" + min.ToString();
		}





		tempNum = (int)char.GetNumericValue(secondsStr[1]);
		targetImageList[3].sprite = listNumImages[tempNum];

		tempNum = (int)char.GetNumericValue(secondsStr[0]);
		targetImageList[2].sprite = listNumImages[tempNum];

		tempNum = (int)char.GetNumericValue(minutesStr[1]);
		targetImageList[1].sprite = listNumImages[tempNum];

		tempNum = (int)char.GetNumericValue(minutesStr[0]);
		targetImageList[0].sprite = listNumImages[tempNum];

		
	}
}
