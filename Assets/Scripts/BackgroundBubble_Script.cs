using UnityEngine;
using System.Collections;

public class BackgroundBubble_Script : MonoBehaviour
{
	private EasyObjectsScript easyObjectManger;
	private Animator anim;
	private float targetScale;
	private bool Poppable;
	private int SpawnIndex;
	[SerializeField]
	private float bobSpeed;
	private ScoreManagerScript SM;
	private Object ScoreModifierPrefab;

	void Start()
	{
		anim = GetComponent<Animator>();

		Poppable = false;
		transform.localScale = Vector3.zero;
		SM = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManagerScript>();
		ScoreModifierPrefab = Resources.Load("Prefabs/ScoreChangeSprite");
	}

	public void InitialiseVariables(Vector3 position, float intendedScale, int spawnIndex, float a_bobSpeed, EasyObjectsScript a_EasyObjectManager)
	{
		//transform.position = position;
		targetScale = intendedScale;
		Poppable = false;
		transform.localScale = Vector3.zero;
		SpawnIndex = spawnIndex;
		bobSpeed = a_bobSpeed;
		StartCoroutine(ExpandBubble());
		easyObjectManger = a_EasyObjectManager;
	}

	IEnumerator ExpandBubble()
	{
		while(!Poppable)
		{
			if(transform.localScale.x < targetScale)
			{
				transform.localScale += Vector3.one * 0.025f;
			}
			else
			{
				Poppable = true;
			}
			yield return new WaitForSeconds(0.03f);
		}
		//bool up = false;
		Vector3 startPos = transform.position;
		//float startY = startPos.y;
		float tempY = 1f;
		while(Poppable)
		{
			tempY = Mathf.PingPong(Time.time * bobSpeed, 0.1f);
			transform.position = new Vector3(startPos.x, startPos.y + (tempY - 0.05f), startPos.z);
			//Debug.Log(tempY);
			yield return new WaitForSeconds(0.03f);
		}
	}

	public void OnMouseOver()
	{
		if(anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && Poppable)
		{
			if(Input.GetMouseButtonDown(0))
			{
				transform.GetChild(0).gameObject.SetActive(false);
				anim.Play("Burst");
				Poppable = false;
				if(SM.EditScore(1, ScoreManagerScript.ScoreSource.BackGroundObj))
				{
					GameObject scoreSprite = Instantiate(ScoreModifierPrefab, transform.position, Quaternion.identity) as GameObject;
					scoreSprite.GetComponent<ScoreModifierSprite>().SetNumber(1, true, true);
				}
				StartCoroutine(SelfDestroy());
				//JUST DO IT, DON'T LET YOUR DREAMS JUST BE DREAMS - SHIA LABEOUF
			}
		}
	}

	IEnumerator SelfDestroy()
	{
		float waitTime = 0.3f;
		while(true)
		{
			waitTime -= 0.03f;
			if(waitTime < 0f)
			{
				easyObjectManger.BubbleDestroyed(SpawnIndex, gameObject);
				Destroy(gameObject);
			}
			yield return new WaitForSeconds(0.03f);
		}
	}
}