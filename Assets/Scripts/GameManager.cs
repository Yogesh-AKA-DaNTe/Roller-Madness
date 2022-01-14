using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public static GameManager gm;

	[Tooltip("If not set, the player will default to the gameObject tagged as Player.")]
	public GameObject player;

	public enum gameStates {Playing, Death, GameOver, BeatLevel};
	public gameStates gameState = gameStates.Playing;

	public int score=0;
	public bool canBeatLevel = false;
	public int beatLevelScore = 0;

	// Canvas related
	public GameObject mainCanvas;
	public Text mainScoreDisplay;
	public GameObject gameOverCanvas;
	public Text gameOverScoreDisplay;

	[Tooltip("Only need to set if canBeatLevel is set to true.")]
	public GameObject beatLevelCanvas;

	public AudioSource backgroundMusic;
	public AudioClip gameOverSFX;

	[Tooltip("Only need to set if canBeatLevel is set to true.")]
	public AudioClip beatLevelSFX;

	private Health playerHealth;

	void Start ()
	{
		if (gm == null)
		{
			gm = gameObject.GetComponent<GameManager>();
		}

		if (player == null)
		{
			player = GameObject.FindWithTag("Player");
		}

		playerHealth = player.GetComponent<Health>();

		// Setup score display
		Collect (0);

		// Make other UI inactive
		gameOverCanvas.SetActive (false);
		if (canBeatLevel)
		{
			beatLevelCanvas.SetActive (false);
		}
	}

	void Update ()
	{
		switch (gameState)
		{
			case gameStates.Playing:
				if (playerHealth.isAlive == false)
				{
					gameState = gameStates.Death;
					gameOverScoreDisplay.text = mainScoreDisplay.text;		
					mainCanvas.SetActive (false);
					gameOverCanvas.SetActive (true);
				}
				else if (canBeatLevel && score>=beatLevelScore)
				{
					gameState = gameStates.BeatLevel;
					player.SetActive(false);
					mainCanvas.SetActive (false);
					beatLevelCanvas.SetActive (true);
				}
				break;
			case gameStates.Death:
				backgroundMusic.volume -= 0.01f;
				if (backgroundMusic.volume<=0.0f)
				{
					AudioSource.PlayClipAtPoint (gameOverSFX,gameObject.transform.position);
					gameState = gameStates.GameOver;
				}
				break;
			case gameStates.BeatLevel:
				backgroundMusic.volume -= 0.01f;
				if (backgroundMusic.volume<=0.0f)
				{
					AudioSource.PlayClipAtPoint (beatLevelSFX,gameObject.transform.position);
					gameState = gameStates.GameOver;
				}
				break;
			case gameStates.GameOver:
				break;
		}
	}

	// Function for collecting treasure
	public void Collect(int amount)
	{
		score += amount;
		if (canBeatLevel)
		{
			mainScoreDisplay.text = score.ToString () + " of " + beatLevelScore.ToString ();
		}
		else
		{
			mainScoreDisplay.text = score.ToString ();
		}
	}
}
