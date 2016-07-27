using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SpawnController : MonoBehaviour {

    public float _spawnTime = 5.0f;
    public float _decay = 0.95f;
    public GameObject _asteroidPrefab;
    private int _asteroidNumber;

    private float next = 1.0f;

	void Start () {
	    if (next > 0) {
            next = next - Time.deltaTime;
        } else {
            next = next + _spawnTime;
            _spawnTime = _spawnTime * _decay;
            //Instantiate(_asteroidPrefab, new Vector3(0, 20, 0), new Quaternion());
        }


        for (int i = 0; i < 20; i++) {
            spawnAsteroid();
        }
	}

	void Update () {
        GameObject player = GameObject.Find("Player");

        if (!player) {
            Destroy(this);
        }
        if (next > 0) {
            next = next - Time.deltaTime;
        } else {
            next = next + _spawnTime;
            _spawnTime = _spawnTime * _decay;
            _asteroidNumber = Random.Range(0, 4);
            //spawnAsteroid();
			if (SceneManager.GetActiveScene().buildIndex == 4) {
				spawnAsteroid();
			}
        }
    }

    void spawnAsteroid() {
        _asteroidNumber = Random.Range(0, 4);
        switch (_asteroidNumber) {
            case 0:
                Instantiate(Resources.Load("Prefabs/Asteroid1") as GameObject, new Vector3(Random.Range(-7, 7), Random.Range(-5, 5), 0), new Quaternion());
                break;
            case 1:
                Instantiate(Resources.Load("Prefabs/Asteroid2") as GameObject, new Vector3(Random.Range(-7, 7), Random.Range(-5, 5), 0), new Quaternion());
                break;
            case 2:
                Instantiate(Resources.Load("Prefabs/Asteroid3") as GameObject, new Vector3(Random.Range(-7, 7), Random.Range(-5, 5), 0), new Quaternion());
                break;
            case 3:
                Instantiate(Resources.Load("Prefabs/Asteroid4") as GameObject, new Vector3(Random.Range(-7, 7), Random.Range(-5, 5), 0), new Quaternion());
                break;
            default:
                break;
        }
    }
}
