using UnityEngine;
using System.Collections;

public class Chaser : MonoBehaviour
{	
	public float speed = 20.0f;
	public float minDist = 1f;
	public Transform target;

	void Start () 
	{
		// Sets target as Player
		if (target == null)
		{
			if (GameObject.FindWithTag ("Player")!=null)
			{
				target = GameObject.FindWithTag ("Player").GetComponent<Transform>();
			}
		}
	}
	
	void Update () 
	{
		if (target == null) { return; }

		// Look at target, calculate distance and then chase
		transform.LookAt(target);
		float distance = Vector3.Distance(transform.position,target.position);

		if(distance > minDist)
		{
			transform.position += transform.forward * speed * Time.deltaTime;	
		}
	}

	// Sets the target of the chaser
	public void SetTarget(Transform newTarget)
	{
		target = newTarget;
	}
}
