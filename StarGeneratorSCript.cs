using UnityEngine;
using System.Collections;

public class StarGeneratorSCript : MonoBehaviour {
	public GameObject StarGO;// star game object
	public int MaxStars; // maximum number of the stars

	//Array of colors
	Color[] starColors = { new Color (0.5f, 0.5f, 1f),//blue
		new Color (0.5f, 1f, 1f), //green
		new Color(1f, 1f, 0), //yellow
		new Color(1f, 0, 0) //red
	};
	// Use this for initialization
	void Start () {
		//Bottom-left of the screen
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));

		//top-right of the screen
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

		//Loop to create the stars
		for (int i = 0; i < MaxStars; ++i) {
			GameObject star = (GameObject)Instantiate (StarGO);

			//set the star color
			star.GetComponent<SpriteRenderer> ().color = starColors [i % starColors.Length];

			//set the position of the star (random x and random y)
			star.transform.position = new Vector2 (Random.Range (min.x, max.x), Random.Range (min.y, max.y));

			//set random speed for the star
			star.GetComponent<StarScript>().speed = -(1f * Random.value + 0.5f);  

			//make star game object child of Star Generator
			star.transform.parent = transform;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
