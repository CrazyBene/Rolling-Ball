using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScore : MonoBehaviour {

	// UI info 
	public GameObject score;
	public GameObject hscore;

	public void init() {
		score.GetComponentInChildren<Text>().text = GameManager.score.ToString();
	}


	public void playAgain() {
		SceneManager.LoadScene("Game");
		GameManager.gameState = GameManager.State.STARTING;
		GameManager.waitTime = 0.02f;
	}

	public void menu () {
		SceneManager.LoadScene("Menu");
		GameManager.gameState = GameManager.State.MENU;
	}

}
