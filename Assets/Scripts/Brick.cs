using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	LevelManager levelManager;

	public static int brickCount = 0;

	int maxHits;
	public int timesHit;
	public Sprite[] hitSprites;
	public AudioClip clip;
	bool isBreakable;

	// Use this for initialization
	void Awake () {
		brickCount = 0;
	}

	void Start () {
		isBreakable = (this.tag == "Breakable");
		if (isBreakable) {
			brickCount++;
		}

		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		timesHit = 0;
		maxHits = hitSprites.Length + 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D collision) {
		if (isBreakable) {
			HandleHits ();
		}
	}

	void HandleHits () {
		timesHit++;
		if (timesHit >= maxHits) {
			//AudioSource.PlayClipAtPoint (clip, this.transform.position);
			Destroy (gameObject);
			brickCount--;
			Debug.Log (brickCount);
			levelManager.BrickDestroyed ();
		} else {
			LoadSprites ();
		}
	}

	void LoadSprites () {
		int spriteIndex = timesHit - 1;
		if (hitSprites [spriteIndex]) {
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites [spriteIndex];
		}
	}
}
