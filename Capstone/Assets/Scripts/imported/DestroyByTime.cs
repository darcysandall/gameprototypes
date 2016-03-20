using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {

	public bool DeactivateOnly = false;
	public float delay;

	void Start () 
	{
		if (DeactivateOnly == false)
		{
			Destroy (gameObject, delay); // Destroys gameObject after delay
		}
	}

	void Update ()
	{
		if (DeactivateOnly == true) 
		{
			StartCoroutine (DeactivateOverTime());
		}
	}

	IEnumerator DeactivateOverTime ()
	{
		yield return new WaitForSeconds (delay); // Time to wait until it deactivates itself
		gameObject.SetActive (false); // Deactivates the gameObject
	}
}
