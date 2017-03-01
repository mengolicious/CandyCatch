using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SoundManagerScript : MonoBehaviour {
	
	//public AudioSource BGMusic_Player;
	public AudioSource FX_Player;
	public AudioSource BG_FX_Player;
	public AudioSource BG_FX_Loop_Player;

	

	public float lowPitchRange;              //The lowest a sound effect will be randomly pitched.
	public float highPitchRange;            //The highest a sound effect will be randomly pitched.



	public bool isMute;
	
	public Sprite audioSprite;
	public Sprite audioMuteSprite;
	public GameObject audioButton;
	public Image audioButtonImage;

	public static SoundManagerScript Instance {
		get;
		set;
	}
	// Use this for initialization

	void Awake () {
		
		DontDestroyOnLoad (transform.gameObject);
		if (Instance == null) {
			Instance=this;
		}
		else if(Instance != this){
			Destroy (gameObject);
		}
		
		
	}

	void Start () {
		audioButton = GameObject.FindGameObjectWithTag("MuteButton");
		audioButtonImage = audioButton.GetComponent<Image> ();

		lowPitchRange = .95f;              //The lowest a sound effect will be randomly pitched.
		highPitchRange = 1.05f;            //The highest a sound effect will be randomly pitched.
		
	
	}
	
	public void Play_SFX (string tempStringName)
	{
		FX_Player.clip = Resources.Load<AudioClip> ("SFX/"+ tempStringName);
		FX_Player.Play ();
		//FX_Player.PlayOneShot (Resources.Load<AudioClip> ("Voices/Set" + setNum + "/" + fileName + ballNum));
	}

	public void Play_BG_SFX (string tempStringName)
	{
		BG_FX_Player.clip = Resources.Load<AudioClip> ("SFX/"+ tempStringName);
		BG_FX_Player.loop = true;
		BG_FX_Player.Play ();
		//FX_Player.PlayOneShot (Resources.Load<AudioClip> ("Voices/Set" + setNum + "/" + fileName + ballNum));
	}

	public void Play_BG_loop (string tempStringName)
	{
		BG_FX_Loop_Player.clip = Resources.Load<AudioClip> ("SFX/"+ tempStringName);
		BG_FX_Loop_Player.loop = true;
		BG_FX_Loop_Player.Play ();
		//FX_Player.PlayOneShot (Resources.Load<AudioClip> ("Voices/Set" + setNum + "/" + fileName + ballNum));
	}

	public void Stop_BG_SFX ()
	{
		BG_FX_Player.Stop ();
		//FX_Player.PlayOneShot (Resources.Load<AudioClip> ("Voices/Set" + setNum + "/" + fileName + ballNum));
	}



	
	public void ChangeBGMusic(string tempBGMusic){
	FX_Player.clip = Resources.Load<AudioClip> ("Voices/BGM/"+tempBGMusic);
	FX_Player.loop = true;
	FX_Player.Play ();
	
	}
	// Update is called once per frame
	void Update () {
		
	}

	public void ButtonAudio () {
		
		isMute = !isMute;
		if (isMute == true) {
			AudioListener.volume = 0.0f;
			//audioSpriteRenderer.sprite = audioMuteSprite;
			audioButtonImage.sprite = audioMuteSprite;
			
		} else {
			AudioListener.volume = 1.0f;
			audioButtonImage.sprite = audioSprite;
			
		}
		
		
		
	}
}
