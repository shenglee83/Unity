using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public GameObject playButton;
	public GameObject playerShip;
	public GameObject enemySpawner; 
	public GameObject GameOverGO;// reference to the game over image

	public enum GameManagerState {
		Opening, Gameplay, GameOver
	}

	GameManagerState GMState;
	// Use this for initialization
	void Start () {
		GMState = GameManagerState.Opening;
	}
	
	// fucntion to Update Game Manager State
	void UpdateGameManagerState () {
		switch (GMState) {
			case GameManagerState.Opening:
				//hide game over
				GameOverGO.SetActive(false);
				//set play button active
				playButton.SetActive(true);
				break;

			case GameManagerState.Gameplay:
				//hide play button on game play state
				playButton.SetActive (false);
				// set the player active and int the player lives
				playerShip.GetComponent<Player2DMoveScript> ().Init ();
				//start enemy spawner
				enemySpawner.GetComponent<EnemySpawner>().ScheduleEnemySpawner();
				break;

			case GameManagerState.GameOver:
				//stop the enemy spawner
				enemySpawner.GetComponent<EnemySpawner>().UnscheduleEnemySpawner();
				//display game over
				GameOverGO.SetActive(true);
				//change game manager state to opening after 8 seconds
				Invoke("ChangeToOpeningState",  5f);
				break;
		}
	}

	// function to set the game manager state
	public void SetGameManagerState(GameManagerState state){
		GMState = state;
		UpdateGameManagerState ();
	}

	//Play button will call this function when the user click the button
	public void StartGamePlay() {
		GMState = GameManagerState.Gameplay;
		UpdateGameManagerState ();
	}

	//function to change game manager state to opening state
	public void ChangeToOpeningState(){
		SetGameManagerState (GameManagerState.Opening);
	}
}
