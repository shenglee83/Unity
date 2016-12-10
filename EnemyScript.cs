using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
	private float speed;

	public GameObject explosionGO;

	// Use this for initialization
	void Start () {
		speed = 2f;
	}
	
	// Update is called once per frame
	void Update () {
		//Get the enemy's current position
		Vector2 position = transform.position;

		//Compute the enemy new position
		position = new Vector2 (position.x, position.y - speed * Time.deltaTime);

		// Update the enemy position
		transform.position = position;

		//this is the bottom-left point of the screen
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

		//if the enemy went outside the screen at the bottom, then destroy the enemy
		if (transform.position.y < min.y) {
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		//Detect collision of the player ship with an Player ship or Player bullet
		if((col.tag == "PlayerShipTag") || (col.tag == "PlayerBulletTag")){
			PlayExplosion ();

			Destroy(gameObject); //Destroy this enemy ship
		}
	}

	void PlayExplosion(){
		GameObject explosion = (GameObject)Instantiate (explosionGO);

		//set the position of the explosion
		explosion.transform.position = transform.position;
	}
}
