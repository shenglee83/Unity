using UnityEngine;
using System.Collections;

public class PlanetScript : MonoBehaviour {
	public float speed;
	public bool isMoving; //flag to make the planet scroll down the screen

	Vector2 min;
	Vector2 max;

	void Awake(){
		isMoving = false;

		min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
		max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

		//add the planet sprite half height to max y
		max.y = max.y + GetComponent<SpriteRenderer> ().sprite.bounds.extents.y;

		//subtract the planet sprite half height to min y
		min.y = min.y - GetComponent<SpriteRenderer> ().sprite.bounds.extents.y;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!isMoving) {
			return;
		}

		//get the current position of the planet
		Vector2 position = transform.position;

		//compute the planet's position;
		position = new Vector2 (position.x, position.y + speed * Time.deltaTime);
	
		//Update the planet's position
		transform.position = position;

		//if the planet gets to the minimum y position. then stop moving the planet
		if(transform.position.y < min.y){
			isMoving = false;
		}
	}

	//function to reset the planet's position
	public void ResetPosition(){
		//reset the position of the planet to random.x, and max y
		transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
	}

}
