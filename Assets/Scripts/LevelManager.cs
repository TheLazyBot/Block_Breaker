using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void LoadLevel (string name) {
		Debug.Log ("Load Requested for: " + name);
		SceneManager.LoadScene (name);
	}

	public void BrickDestroyed () {
		if (Brick.brickCount <= 0) {
			LoadNextLevel();
		}
	}

	public void LoadNextLevel () {
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
	}
}
//Comment
