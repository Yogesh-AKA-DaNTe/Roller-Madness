using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour
{
	public float moveSpeed = 5f;		// Enemy move speed
	public GameObject[] myWaypoints;	// All waypoints
	private int myWaypointId = 0;		// Used as index for MyWaypoints
	
	void Update ()
	{
		EnemyMovement();
	}

	void EnemyMovement()
	{
		if (myWaypoints.Length != 0)
		{
			// If the enemy is close enough to waypoint, make it's new target the next waypoint
			if (Vector3.Distance(myWaypoints[myWaypointId].transform.position, transform.position) <= 0)
			{
				myWaypointId++;
			}

			if (myWaypointId >= myWaypoints.Length)
			{
				myWaypointId = 0;
			}

			// Move towards the waypoint
			transform.position = Vector3.MoveTowards(transform.position, myWaypoints[myWaypointId].transform.position, moveSpeed * Time.deltaTime);
		}
	}
}