using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour {
	private float speed;
	Vector2 _direction; //direction of the bullet
	bool isReady;

	//Set default value in Awake
	void Awake() {
		speed = 5;
		isReady = false;
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (isReady) {
			//Get the bullet's current position
			Vector2 position = transform.position;

			//Compute the bullet new position
			position += _direction * speed * Time.deltaTime;

			// Update the bullet position
			transform.position = position;

			//We need to remove the bullet from the game
			//if the bullet goes outside the screen

			//this is the bottom-left point of the screen
			Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

			//this is the top-right point of the screen
			Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

			//if the bullet went outside the screen at the bottom, then destroy the bullet
			if (transform.position.x < min.x || transform.position.x > max.x || 
				transform.position.y < min.y || transform.position.y > max.y ) {
				Destroy(gameObject);
			}
		}
	}

	public void SetDirection (Vector2 direction){
		//Set the direction nomalized, to get an unit vector
		_direction = direction.normalized;

		isReady = true; // set flag to true

	}

	void OnTriggerEnter2D(Collider2D col){
		//Detect collision of the enemy bullet with the player ship
		if(col.tag == "PlayerShipTag"){
			Destroy(gameObject); //Destroy the player ship
		}
	}
}
