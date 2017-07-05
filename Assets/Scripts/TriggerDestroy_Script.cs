using UnityEngine;
using System.Collections;

public class TriggerDestroy_Script : MonoBehaviour
{
	public void OnTriggerEnter(Collider other)
	{
		if(other.name == "Bonus Bee")
		{
			other.GetComponent<BonusBeeScript>().Kill();
		}
		else
		{
			Destroy(other.gameObject);
		}
	}
}
