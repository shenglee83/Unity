﻿using UnityEngine;
using System.Collections;

public class PlayerBulletScript : MonoBehaviour {
    float speed;
	// Use this for initialization
	void Start () {
        speed = 5f;
	}
	
	// Update is called once per frame
	void Update () {
        //Get the bullet current position
        Vector2 position = transform.position;
        //compute the bullet's new position
        position = new Vector2(position.x, position.y + speed * Time.deltaTime);

        //update the bullet's position
        transform.position = position;
        
        //this is the top-right point of the screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));

        //if the bullet went outside the screen on the top, then destroy the bullet
        if (transform.position.y > max.y) {
            Destroy(gameObject);
        }
	}

	void OnTriggerEnter2D(Collider2D col){
		//Detect collision of the player bullet with an enemy ship
		if(col.tag == "EnemyShipTag"){
			Destroy(gameObject); //Destroy this enemy ship
		}
	}

    
}
