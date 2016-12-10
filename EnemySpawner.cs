using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	public GameObject EnemyGO;
	float maxSpawnRateInSeconds = 5f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//function to spawn enemy\
	void SpawnEnemy(){
		//This is the bottom-left point of the screen
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));

		//This is the top-right point of the screen
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

		//Instantiate an enemy
		GameObject anEnemy = (GameObject)Instantiate (EnemyGO);
		anEnemy.transform.position = new Vector2 (Random.Range (min.x, max.x), max.y);

		//Schedule when to spawn the next enemy
		ScheduleNextEnemySpawn();
	}

	void ScheduleNextEnemySpawn(){
		float spawnInSeconds;

		if (maxSpawnRateInSeconds > 1f) {
			//pick a number between 1 and maxSpawnRateInSeconds
			spawnInSeconds = Random.Range (1, maxSpawnRateInSeconds);
		} else {
			spawnInSeconds = 1f;
		}

		Invoke ("SpawnEnemy", spawnInSeconds);
	}
	//Funciton to increase the difficulty of the game
	void IncreaseSpawnRate() {
		if (maxSpawnRateInSeconds > 1f) {
			maxSpawnRateInSeconds--;
		} 

		if (maxSpawnRateInSeconds == 1) {
			CancelInvoke ("IncreaseSpawnRate");
		}
	}

	public void ScheduleEnemySpawner(){
		Invoke ("SpawnEnemy", maxSpawnRateInSeconds);

		//Increase spawn Rate evert 30 seconds
		InvokeRepeating("IncreaseSpawnRate", 0f, 30f);
	}

	//function to stop enemy spawner
	public void UnscheduleEnemySpawner(){
		CancelInvoke ("SpawnEnemy");
		CancelInvoke ("IncreaseSpawnRate");
	}
}
