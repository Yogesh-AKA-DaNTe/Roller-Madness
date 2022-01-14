using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TriggerLevelLoad : MonoBehaviour
{
	public string nameOfLevelToLoad  = ""; // For storing the name of Level to load

	void OnTriggerEnter (Collider other)
	{
		// Loads level when the object which produced trigger event is tagged "Player"
		if(other.gameObject.tag == "Player" )
		{
			SceneManager.LoadScene(nameOfLevelToLoad);
		}
	}
}
