using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class HudRipple_Script : MonoBehaviour
{
	List<Sprite> RippleFrames;
	Image image;
	public void Begin(ref List<Sprite> spriteFrames)
	{
		image = GetComponent<Image>();
		RippleFrames = spriteFrames;
		StartCoroutine(Animate());
	}

	IEnumerator Animate()
	{
		for(int i =0; i < RippleFrames.Count; i++)
		{
			image.sprite = RippleFrames[i];
			yield return new WaitForSeconds(0.04f);
		}
		Destroy(gameObject);
	}
}
