using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	Paddle paddle;
	Vector3 paddleToBallVector;
	bool hasStarted = false;
	public AudioClip clip;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle> ();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasStarted) {
			// Lock ball to paddle
			this.transform.position = paddle.transform.position + paddleToBallVector;
		
			// Wait for LMB to launch
			if (Input.GetMouseButtonDown (0)) {
				print ("LMB");
				this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (2f, 10f);
				hasStarted = true;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		Vector2 tweak = new Vector2 (Random.Range (0f, 0.2f), Random.Range (0f, 0.2f));

		if (hasStarted) {
			AudioSource.PlayClipAtPoint (clip, this.transform.position);
			GetComponent<Rigidbody2D> ().velocity += tweak;
		}
	}
}
