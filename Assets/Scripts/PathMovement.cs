using UnityEngine;
using System.Collections;

public class PathMovement : MonoBehaviour {

	// speed must be the same as the ball speed
	private float speed = GameManager.speed;

		
	// Update is called once per frame
	public void playing () {

		// Get all the children and move them downwards
		// together with the ball movement, it looks like 
		// the ball is moving in an angle of 45 degrees

		foreach(Transform child in transform) {
			child.Translate(0, 0, -speed);
		}

	}
}
