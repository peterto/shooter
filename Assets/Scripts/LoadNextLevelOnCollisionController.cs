using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadNextLevelOnCollisionController : MonoBehaviour {

	[SerializeField] Transform _fadeOut;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col) {
		if(col.gameObject.CompareTag("Player")) {
			GameObject scoreDisplayController = GameObject.Find("Canvas");
			int playerHealth = scoreDisplayController.GetComponent<ScoreDisplayController>()._playerHealth;
			PlayerPrefs.SetInt ("playerHealth", playerHealth);
			PlayerPrefs.Save ();
			_fadeOut.gameObject.SetActive (true);
			Invoke ("LoadNextScene", 1f);
		}
	}

	void LoadNextScene() {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}
}
