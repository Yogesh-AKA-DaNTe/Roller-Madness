using UnityEngine;
using System.Collections;

public class TimedObjectDestructor : MonoBehaviour
{
	public float timeOut = 1.0f; // Wait time before Destroy
	public bool detachChildren = false; // To detach the children before destroying or not

	// Used for initialization
	void Awake ()
	{
		// Invoke the DestroyNow function to run after timeOut seconds
		Invoke ("DestroyNow", timeOut);
	}
	
	void DestroyNow ()
	{
		// Detach the children before destroying if specified
		if (detachChildren)
		{
			transform.DetachChildren ();
		}
		DestroyObject (gameObject);
	}
}
