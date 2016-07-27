using UnityEngine;
using System.Collections;

public class InGameMenuController : MonoBehaviour {

	public Transform _gameoverCanvas;

	// Use this for initialization
	void Start () {
	
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			if (Time.timeScale == 0) {
				if (_gameoverCanvas.gameObject.activeInHierarchy) {
					Time.timeScale = 1;
					_gameoverCanvas.gameObject.SetActive(false);
					StartPlayerMovement ();
				}
			}
			else if (Time.timeScale == 1) {
				if (!_gameoverCanvas.gameObject.activeInHierarchy) {
					StopPlayerMovement ();
					Time.timeScale = 0;
					_gameoverCanvas.gameObject.SetActive(true);
				}

			}
		}
	}

	void StopPlayerMovement(){
		GameObject player = GameObject.Find ("Player");
		player.GetComponent<MouseMovementController> ()._stopMovement = true;
		player.GetComponent<PlayerScript> ()._stopMovement = true;
	}

	void StartPlayerMovement(){
		GameObject player = GameObject.Find ("Player");
		player.GetComponent<MouseMovementController> ()._stopMovement = false;
		player.GetComponent<PlayerScript> ()._stopMovement = false;
	}
}
