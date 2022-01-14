using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIButtonLevelLoad : MonoBehaviour
{
	public string LevelToLoad; // For storing the Level to load
	
	public void loadLevel()
	{
		// Load the level from LevelToLoad
		SceneManager.LoadScene(LevelToLoad);
	}
}
