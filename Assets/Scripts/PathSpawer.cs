using UnityEngine;
using System.Collections;

public class PathSpawer : MonoBehaviour {

	public GameObject pathPrefab;

	public GameObject player;

	// x position of the new/last tile placed
	private float xpos = 0;


	void Start() {
		// creating tiles until the screen is completely full
		// before th game starts we need the first 24 tiles?
		for(int i = 0; i < 24; i++) {
			Vector3 pos = new Vector3(xpos, 0, i*0.5f);
			Instantiate(pathPrefab, pos, Quaternion.identity, transform);

			// generate a new xpos depending on the last xpos
			// and a random factor for the direction for the 
			// new xpos
			int rnd = Random.Range(0, 2);
			xpos += (rnd == 0) ? -0.5f : 0.5f;

			if(xpos < -2)
				xpos++;
			if(xpos > 2)
				xpos--;


			// set the direction in the player script
			// depending where the second tile spawned
			if(i == 0){
				if(rnd == 0)
					player.GetComponent<PlayerMovement>().dir = -1;
				else 
					player.GetComponent<PlayerMovement>().dir = 1;
			}
		}

	}


	// Update is called once per frame
	public void playing () {

		GameObject go = transform.GetChild(transform.childCount-1).gameObject;

		// creating a tile every 0.5f units the other tiles move

		if(go.transform.position.z <=  11) {

			Vector3 pos = new Vector3(xpos, 0, 11.5f);
			Instantiate(pathPrefab, pos, Quaternion.identity, transform);

			// generate a new xpos depending on the last xpos
			// and a random factor for the direction for the 
			// new xpos
			int rnd = Random.Range(0, 2);
			xpos += (rnd == 0) ? -0.5f : 0.5f;

			if(xpos < -2)
				xpos++;
			if(xpos > 2)
				xpos--;

		}

		destroyTile();

	}


	private void destroyTile() {
		// look through all the path tiles 
		// and see if anyone is not in the view ANYMORE
		// it is lower than the view min
		foreach(Transform child in transform) {
			if(child.position.z < -5)
				Destroy(child.gameObject);
		}
	}

}
