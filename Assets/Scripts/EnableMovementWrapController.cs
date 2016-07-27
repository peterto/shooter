using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EnableMovementWrapController : MonoBehaviour {

    private GameObject[] asteroids;
	
	void Start () {


        //print(SceneManager.GetActiveScene().name);

    }

    // Update is called once per frame
    void Update () {
        if (SceneManager.GetActiveScene().name == "scene_main_menu") {
            asteroids = GameObject.FindGameObjectsWithTag("Asteroid");

            foreach (GameObject asteroid in asteroids) {
                asteroid.GetComponent<MovementWrapController>().enabled = true;
            }
        }
    }
}
