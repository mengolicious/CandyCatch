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
	private GM_1 GameManager;
	// Use this for initialization

	void Awake()
	{
		InitializeTime();
	}

	void Start()
	{
		GameManager = GameObject.FindGameObjectWithTag("GM").GetComponent<GM_1>();
		listNumImages = new List<Sprite>
		{
			num0,
			num1,
			num2,
			num3,
			num4,
			num5,
			num6,
			num7,
			num8,
			num9,
			period
		};
		listDisplayImages = new List<Image>
		{
			firstNum,
			secondNum,
			thirdNum,
			fourthNum
		};
		listDisplayImagesTargetTime = new List<Image>
		{
			firstNumTime,
			secondNumTime,
			thirdNumTime,
			fourthNumTime
		};
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
				BonusTime = BonusTime - 1;
				elapsedTime = BonusTime;
				if(elapsedTime < 1 )
				{
					GameManager.EndBonusStage();
					minutes = elapsedTime / 60;
					seconds = elapsedTime % 60;

					DisplayTime (listDisplayImages, minutes, seconds);

					break;
					//call some GM_1 Function to make it end the bonus time game
				}
			}
			minutes = elapsedTime / 60;
			seconds = elapsedTime % 60;

			DisplayTime(listDisplayImages, minutes, seconds);

			if(!SVM_Script.Instance.isBonus)
				yield return new WaitForSeconds(0.5f);
			else
				yield return new WaitForSeconds(1.0f);
		}
	}

	public void SwitchToBonusRound()
	{
		elapsedTime = BonusTime;
		int minutes = elapsedTime / 60;
		int seconds = elapsedTime % 60;

		DisplayTime (listDisplayImages, minutes, seconds);
	}

	public void ReduceTime()
	{
		BonusTime = BonusTime - 1;
		if(BonusTime < 0)
		{
			BonusTime = 0;
		}
		int minutes = elapsedTime / 60;
		int seconds = elapsedTime % 60;

		DisplayTime (listDisplayImages, minutes, seconds);
		if(BonusTime < 1)
		{
			GameManager.EndBonusStage();
		}
	}

	public void DisplayTargetTime()
    {
		int minutes;
		int seconds;

		tempTargetTime = SVM_Script.Instance.targetTime;
		minutes = tempTargetTime / 60;
		seconds = tempTargetTime % 60;

		DisplayTime(listDisplayImagesTargetTime, minutes, seconds);


	}

    /// <summary>
    /// Function to call on any part of Game that wants to display time.
    /// </summary>
    /// <param name="targetImageList">List of GameObject Images to Display Time.</param>
    /// <param name="min">Minutes.</param>
    /// <param name="sec">Seconds.</param>
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
