using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

	// get the information of the start direction from
	// the pathspawner and where the second tile is
	public int dir = 0;

	// speed musst be the same as the path speed
	private float speed = GameManager.speed;

	// endscore hud
	public GameObject endscore;


	// Update is called once per frame
	public void playing () {

		// testing if we change direction
		changingDirection();

		// testing if we are still on the path
		pathTesting();

		// Movement of the ball
		transform.Translate(dir*speed, 0, 0);

	}


	private void changingDirection() {
		// If we press the sceen the movement direction changes
		if(Input.touchCount > 0) {

			// test for each touch, if it is the beginning of the touch
			foreach(Touch t in Input.touches) {

				if(t.phase == TouchPhase.Began) {
					dir *= -1;
				}

			}

		}
	}

	private void pathTesting() {
		Vector3 dir =  new Vector3(0, -1, 0);
		Ray ray = new Ray(transform.position, dir);
		RaycastHit hitInfo;


		if(Physics.Raycast(ray, out hitInfo)) {
		} else {
			GameManager.gameState = GameManager.State.END;
			endscore.GetComponent<Canvas>().enabled = true;
			endscore.GetComponent<EndScore>().init();
		}
	}
}
