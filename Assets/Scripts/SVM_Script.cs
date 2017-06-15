using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SVM_Script : MonoBehaviour
{ 
	//public static GameObject advanceDifficulty;
	//public static GameObject advanceDifficultyLock;
	//public static GameObject expertDifficulty;
	//public static GameObject expertDifficultyLock;

	public static string gameDifficulty;
	public bool isBonus;
	public static int targetScore = 50;
	public static bool advanceIsLocked = true;
	public static bool expertIsLocked = true;
	public static bool InstructionSeen = false;
	public static bool gameSetup;
	// Make global instance, need to check if the instance is being used by external sources
	public static SVM_Script Instance
	{
		get;
		set;
	}
		
	public GameObject canvas;
	private GameObject loadingScreen;

	//taget time to beat in seconds
	public int targetTime;
	//the total score from the game
	public int currentTotalScore;
	//the time left over to be used for the bonus stage
	public int bonusTime;
	//the index for the highscore that we beat, may have to recode the saving of the highscore to ensure we don't change the high score list then beat an even higher score
	public int highScoreIndex;

	void Awake ()
	{
		DontDestroyOnLoad (transform.gameObject);
		if (Instance == null)
		{
			Instance=this;
		}
		else if(Instance != this)
		{
			Destroy (gameObject);
		}
		//Debug.Log("Rawr means I love you in Dinosaur");
		SceneManager.sceneLoaded += SceneLoadListener;
		SetUpLoadingScreen();			//Establish the loading screen and attach it to the canvas while fixing strange value artifacts
		InitializeSavedVariables();		//Initialize variables that needs to be saved when APP is closed
		LoadSavedVariables();			//Load the variables from Playerprefs
		isBonus = false;
	}

	void SetUpLoadingScreen()
	{
		canvas = GameObject.FindGameObjectWithTag("Canvas");
		loadingScreen = Instantiate(Resources.Load("prefabs/LoadingScreen"))as GameObject;
		loadingScreen.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.5f);
		loadingScreen.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.5f);
		loadingScreen.GetComponent<RectTransform>().sizeDelta = new Vector2(800, 450);;
		loadingScreen.transform.SetParent(canvas.transform);
		loadingScreen.GetComponent<RectTransform>().localPosition = Vector3.zero;
		loadingScreen.GetComponent<RectTransform>().localScale = Vector3.one;
		loadingScreen.SetActive(false);
	}
	/// <summary>
	/// Listener for scene changes, used to setup the loading screen for use when a loadscene call happens
	/// </summary>
	/// <param name="scene"> required input param for listeners </param>
	/// <param name="loadMode"> required input param for listeners </param>
	void SceneLoadListener(Scene scene, LoadSceneMode loadMode)
	{
		isBonus = false;
		bonusTime = 0;
		SetUpLoadingScreen();
	}

	public void InitializeSavedVariables(){
		if (!PlayerPrefs.HasKey("EE_advance"))
		{
			PlayerPrefs.SetInt("EE_advance", 0);
		}
		if (!PlayerPrefs.HasKey("EE_expert"))
		{
			PlayerPrefs.SetInt("EE_expert", 0);
		}
		if (!PlayerPrefs.HasKey("Instructions_Dismissed"))
		{
			PlayerPrefs.SetInt("Instructions_Dismissed", 0);
		}
	}

	public void LoadSavedVariables(){
		if (PlayerPrefs.GetInt("EE_advance") == 1)
		{
			advanceIsLocked = false;
		}
		else
		{
			advanceIsLocked = true;
		}

		if (PlayerPrefs.GetInt("EE_expert") == 1)
		{
			expertIsLocked = false;
		}
		else
		{
			expertIsLocked = true;
		}
		if (PlayerPrefs.GetInt("Instructions_Dismissed") == 1)
		{
			InstructionSeen = true;
		}
		else
		{
			InstructionSeen = false;
		}
	}

	public void LoadLevel(string levelName)
	{
		loadingScreen.SetActive(true);
		StartCoroutine(LevelLoader(levelName));
	}

	IEnumerator LevelLoader(string levelName)
	{
		yield return new WaitForSeconds(0.5f);
		AsyncOperation async = SceneManager.LoadSceneAsync(levelName);
		yield return async;
	}
}
