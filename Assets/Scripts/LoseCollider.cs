﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

	LevelManager levelManager;

	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}

	void OnTriggerEnter2D (Collider2D collider) {
		Debug.Log ("#Triggered.");
		levelManager.LoadLevel ("Lose");
	}

	void Update () {
		
	}
}
