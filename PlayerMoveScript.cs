using UnityEngine;
using System.Collections;

public class PlayerMoveScript : MonoBehaviour {
	private Vector3 lastPosition;
	private float speed = 5f;
	public Transform playerTransform;
    private float movex;
    private float movey;

	// Use this for initialization
	void Start () {
		StartCoroutine (MovePlayer());
	}

	IEnumerator MovePlayer(){
		while (true) {
			float horizontalMove = Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
			float verticalMove = Input.GetAxis ("Vertical") * speed * Time.deltaTime;
			playerTransform.Translate (Vector3.forward * verticalMove);
			playerTransform.Rotate (Vector3.up * horizontalMove);

			if(Vector3.Distance(lastPosition, transform.position) > 0.01f) {
				lastPosition = playerTransform.position;
			}
			Debug.Log ("Move");
			yield return 0;
		}
	}

    

}
