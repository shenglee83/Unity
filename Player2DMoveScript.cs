using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player2DMoveScript : MonoBehaviour {
    private float movex;
    private float movey;
    private float speed = 10f;

	public GameObject GameManagerGO;//refernce to game managerGO

    public Transform playerTransform;
	public GameObject playerBulletGO; //player's bullet prefab
	public GameObject bulletPosition1;
	public GameObject bulletPosition2;
	public GameObject explosionGO;//the explosion prefab 
	//Reference to Live UI text
	public Text LivesUIText;

	const int MaxLives = 3;
	int lives;

	public void Init(){
		lives = MaxLives;

		//update the lives UI text
		LivesUIText.text = lives.ToString();

		//Reset the player Game object position to center of the screen
		transform.position = new Vector2(0, 0);

		//set this player game object active
		gameObject.SetActive(true);
	}

    // Use this for initialization
    void Start () {
	
	}

    void Update() {
        PlayerShoot();
    }
    // FixedUpdate more suitable in dealing with
    // physics properties
    void FixedUpdate()
    {
        movex = Input.GetAxis("Horizontal") * speed;
        movey = Input.GetAxis("Vertical") * speed;

        //to control how fast the rigidbody move across the screen
        //Must set the gravity to '0'
		//Must add Rigidbody2D to the player game object
        GetComponent<Rigidbody2D>().velocity = new Vector2(movex, movey);
    }

    //Shoot bullet using button key
    void PlayerShoot() {
        if (Input.GetKeyDown("space")) {
        	//play the laser sound effect
			GetComponent<AudioSource>().Play();

			//Instantiate the 1st bullet
			GameObject bullet01 = (GameObject) Instantiate (playerBulletGO);
			bullet01.transform.position = bulletPosition1.transform.position; //Set the bullet initial position

			//Instantiate the 2nd bullet
			GameObject bullet02 = (GameObject) Instantiate (playerBulletGO);
			bullet02.transform.position = bulletPosition2.transform.position;
		}
    }

	void OnTriggerEnter2D(Collider2D col){
		//Detect collision of the player ship with an enemy ship or enemy bullet
		if((col.tag == "EnemyShipTag") || (col.tag == "EnemyBulletTag")){
			PlayExplosion ();

			lives--; //subtract one live
			LivesUIText.text = lives.ToString();

			if (lives == 0) {
				//change game manager state	to game over state
				GameManagerGO.GetComponent<GameManager>().SetGameManagerState(GameManager.GameManagerState.GameOver);
				//hide the player's ship   
				gameObject.SetActive(false);
			}
		}
	}

	//Function to instantiate an explosion
	void PlayExplosion(){
		GameObject explosion = (GameObject)Instantiate (explosionGO);

		//set the position of the explosion
		explosion.transform.position = transform.position;
	}
}
