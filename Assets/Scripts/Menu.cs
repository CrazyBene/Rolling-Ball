using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	// function to start the game
	public void startGame() {
		SceneManager.LoadScene("Game");
		GameManager.gameState = GameManager.State.STARTING;
	}

	// function to get help information
	public void help() {

	}

	// function to exit the game
	public void exit() {
		Application.Quit();
	}

}
