using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
	public enum deathAction {loadLevelWhenDead,doNothingWhenDead};
	
	public float healthPoints = 1f;
	public float respawnHealthPoints = 1f;
	
	public int numberOfLives = 1;
	public bool isAlive = true;	

	public GameObject explosionPrefab;
	
	public deathAction onLivesGone = deathAction.doNothingWhenDead;
	
	public string LevelToLoad = "";
	
	private Vector3 respawnPosition;
	private Quaternion respawnRotation;
	

	void Start () 
	{
		// Store initial position as respawn location
		respawnPosition = transform.position;
		respawnRotation = transform.rotation;
		
		if (LevelToLoad == "")
		{
			LevelToLoad = Application.loadedLevelName;
		}
	}
	
	void Update () 
	{
		// If the object is dead
		if (healthPoints <= 0)
		{
			numberOfLives--;
			
			if (explosionPrefab!=null)
			{
				Instantiate (explosionPrefab, transform.position, Quaternion.identity);
			}

			// Respawn
			if (numberOfLives > 0)
			{
				transform.position = respawnPosition;
				transform.rotation = respawnRotation;
				healthPoints = respawnHealthPoints;	
			}
			else
			{
				// Once all lives are gone
				isAlive = false;
				
				switch(onLivesGone)
				{
				case deathAction.loadLevelWhenDead:
					Application.LoadLevel (LevelToLoad);
					break;
				case deathAction.doNothingWhenDead:
					break;
				}
				Destroy(gameObject);
			}
		}
	}
	
	public void ApplyDamage(float amount)
	{	
		healthPoints = healthPoints - amount;	
	}
	
	public void ApplyHeal(float amount)
	{
		healthPoints = healthPoints + amount;
	}

	public void ApplyBonusLife(int amount)
	{
		numberOfLives = numberOfLives + amount;
	}
	
	public void updateRespawn(Vector3 newRespawnPosition, Quaternion newRespawnRotation)
	{
		respawnPosition = newRespawnPosition;
		respawnRotation = newRespawnRotation;
	}
}
