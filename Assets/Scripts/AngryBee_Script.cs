using UnityEngine;
using System.Collections;

public class AngryBee_Script : MonoBehaviour
{
	public bool isCollected;
	public bool isExpert;
	public Vector3 scoreChangeSpritePos;
	public Object ScoreChangeSpritePrefab;
	void Start()
	{
		isCollected = false;
		
		StartCoroutine (Movement());
	}

	IEnumerator Movement()
	{
		float dir = -1f;
		transform.eulerAngles = new Vector3(0,180,0);
		while(!isCollected)
		{
			if(isExpert)
			{
				//Code for expert to be done to move the Angry Bee in a different manner to normal
				if(transform.position.x < -10)
				{
					dir = 1f;
					transform.eulerAngles = new Vector3(0,0,0);
				}
				if(transform.position.x > 10)
				{
					dir = -1f;
					transform.eulerAngles = new Vector3(0,180,0);
				}
				/*while(transform.position.x > -12)
				{
					transform.position -= new Vector3(0.1f,0,0);
					yield return new WaitForSeconds(0.03f);
				}
				while(transform.position.x < 12)
				{
					transform.position += new Vector3(0.1f,0,0);
					yield return new WaitForSeconds(0.03f);
				}//*/
			}
			transform.position += new Vector3(0.1f,0,0) * dir;
			yield return new WaitForSeconds(0.03f);
		}
	}

	public void SpawnScoreSprite()
	{
		GameObject tempParticle = Instantiate(ScoreChangeSpritePrefab, scoreChangeSpritePos, Quaternion.identity) as GameObject;
		tempParticle.GetComponent<ScoreModifierSprite>().SetNumber(5, false, false);
	}

	public void DestroySelf()
	{
		Destroy (this.gameObject);
	}

}
