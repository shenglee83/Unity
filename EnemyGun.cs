using UnityEngine;
using System.Collections;

public class EnemyGun : MonoBehaviour {
	public GameObject EnemyBulletGO;

	// Use this for initialization
	void Start () {
		//fire an enemy bullet after 1 second
		Invoke("FireEnemyBullet", 1f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//function to fire an enemy bullet
	void FireEnemyBullet(){
		
		GameObject playerShip = GameObject.Find ("PlayerGO");

		//if the plater is not dead
		if( playerShip != null){
			//instantiate an enemy bullet
			GameObject bullet = (GameObject) Instantiate (EnemyBulletGO);

			//set the bullet's initial position
			bullet.transform.position = transform.position;

			//compute the bullet direction towards the ship
			Vector2 direction = playerShip.transform.position - bullet.transform.position;

			//set the bullet direction by calling SetDirection public function from EnemyBullet.cs
			bullet.GetComponent<EnemyBullet>().SetDirection(direction);

		}
	}
}
