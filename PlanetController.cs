using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlanetController : MonoBehaviour {
	public GameObject[] Planets; //array of planet game objects

	//queue to hold the planets
	Queue<GameObject> availablePlanets = new Queue <GameObject>();
	// Use this for initialization
	void Start () {
		availablePlanets.Enqueue (Planets [0]);
		availablePlanets.Enqueue (Planets [1]);
		availablePlanets.Enqueue (Planets [2]);

		//call the MovePlanetDown function every 20 seconds
		InvokeRepeating("MovePlanetDown", 0, 20f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//function to dequeue a planet and set its isMoving flag to true
	//so that the planet starts scrolling down the screen
	void MovePlanetDown(){
		EnqueuePlanets ();

		//if queue is empty, then return
		if (availablePlanets.Count == 0)
			return;

		//get a planet from the queue
		GameObject aPlanet = availablePlanets.Dequeue();

		//set the planet isMoving flag to true
		aPlanet.GetComponent<PlanetScript> ().isMoving = true;
	}

	//function to Enqueue planets that are below the screen and are not moving
	void EnqueuePlanets(){
		foreach(GameObject aPlanet in Planets){
			//if the planet is below the screen and the planet is not moving
			if((aPlanet.transform.position.y < 0) && (!aPlanet.GetComponent<PlanetScript> ().isMoving)){
				//reset the planet position
				aPlanet.GetComponent<PlanetScript>().ResetPosition();

				//enqueue the planet
				availablePlanets.Enqueue(aPlanet);
			}
		}
	}
}
