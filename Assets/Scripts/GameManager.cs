using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {


	// get the time/score
	private float time;
	public static int score;


	// Speed of ball and path
	public static float speed = 0.02f;

	// get the score object
	public GameObject scoreObj;

	// enum for the state of the game
	public enum State { MENU, STARTING, PLAYING, END };

	// which state are we in?
	public static State gameState = State.MENU;

	// wait time so that the game doesnt start automatically
	public static float waitTime = 0.02f;

	// Player
	public GameObject player;

	// Path
	public GameObject path;


	// FIXME: Maybe do this in different methods and a case switch state
	// same for the other update functions
	void Update() {

		switch(gameState) {
		case State.MENU:
			break;
		case State.STARTING:
			starting();
			break;
		case State.PLAYING:
			playing();
			break;
		case State.END:
			break;
		}
	}


	private void initGame() {
		time = 0;
		score = 0;
	}

	private void starting() {
		// Option to start a game with a tap
		// if we are in the starting state and
		// only if we arent already playing
		if(Input.touchCount > 0 && waitTime <= 0) {
			gameState = State.PLAYING;
			initGame();
		}


		if(waitTime > 0) 
			waitTime -= Time.deltaTime;
	}


	private void playing() {
		// if we are playing, then look how
		// long we are already playing and 
		// increase the score after each second
		time += Time.deltaTime;

		if(time > 1) {
			time--;
			score++;
			scoreObj.GetComponent<Text>().text = score.ToString();
		}

		// player movement script playing
		player.GetComponent<PlayerMovement>().playing();
		path.GetComponent<PathMovement>().playing();
		path.GetComponent<PathSpawer>().playing();
	}

}
