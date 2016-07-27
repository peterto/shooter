using UnityEngine;
using System.Collections;

public class BombExplosionController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.CompareTag ("Player")) {
			GameObject[] visibleAsteroids = GameObject.FindGameObjectsWithTag ("Asteroid");

			for (int i = 0; i < visibleAsteroids.Length; i++) {
				Renderer rderer = visibleAsteroids [i].GetComponent<Renderer> ();
				if (rderer.isVisible) {
					visibleAsteroids [i].GetComponent<AsteroidController> ().DestroyAsteroid ();
				}
			}
			Camera.main.GetComponent<CameraController> ().ShakeCamera (0.3f, 0.3f);
			this.GetComponent<CircleCollider2D> ().enabled = false;
			Destroy (this.gameObject, 0.5f);
		}
	}
}
