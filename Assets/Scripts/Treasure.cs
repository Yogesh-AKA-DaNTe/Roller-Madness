using UnityEngine;
using System.Collections;

public class Treasure : MonoBehaviour
{
	public int value = 10; // Value of Treasure
	public GameObject explosionPrefab; // For storing the explosion of treasure

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			if (GameManager.gm!=null)
			{
				// Tells the game manager to Collect
				GameManager.gm.Collect (value);
			}
			
			// Explode if specified
			if (explosionPrefab != null)
			{
				Instantiate (explosionPrefab, transform.position, Quaternion.identity);
			}
			
			// Destroy after collection
			Destroy (gameObject);
		}
	}
}
