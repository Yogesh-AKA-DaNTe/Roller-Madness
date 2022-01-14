using UnityEngine;
using System.Collections;

public class SpawnGameObjects : MonoBehaviour
{
	public GameObject spawnPrefab; // Object to spawn

	public float minSecondsBetweenSpawning = 3.0f;
	public float maxSecondsBetweenSpawning = 6.0f;
	
	public Transform chaseTarget; // Target for chasing
	
	private float savedTime; // For saving time before spawning
	private float secondsBetweenSpawning; // Time interval between spawns

	void Start ()
	{
		savedTime = Time.time;
		secondsBetweenSpawning = Random.Range (minSecondsBetweenSpawning, maxSecondsBetweenSpawning);
	}
	
	void Update ()
	{
		if (Time.time - savedTime >= secondsBetweenSpawning)
		{
			MakeThingToSpawn();
			savedTime = Time.time;
			secondsBetweenSpawning = Random.Range (minSecondsBetweenSpawning, maxSecondsBetweenSpawning);
		}	
	}

	// Function to spawn objects
	void MakeThingToSpawn()
	{
		GameObject clone = Instantiate(spawnPrefab, transform.position, transform.rotation) as GameObject;

		// Set chaseTarget if specified
		if ((chaseTarget != null) && (clone.gameObject.GetComponent<Chaser> () != null))
		{
			clone.gameObject.GetComponent<Chaser>().SetTarget(chaseTarget);
		}
	}
}
