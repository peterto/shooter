using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ScoreDisplayController : MonoBehaviour {


    
    public Text _score;
    public int _playerHealth;
	//public GameObject[] _lives = new GameObject[3];
	public List<GameObject> _lives = new List<GameObject>();
	public GameObject _lifePrefab;
	public Text _gameOver;

	private float _xPos = 5;
	private float _lifeDistance = 40;
	private int _numberOfAsteroids = 0;
	float _timeLeft = 45f;

	void Start () {
		_playerHealth = PlayerPrefs.GetInt ("playerHealth");
		if (_playerHealth != 0) {
			for (int i = 0; i < _playerHealth; i++) {
//			print (i);
				_lives.Add (Instantiate (Resources.Load ("Prefabs/Life") as GameObject));
			}
			foreach (GameObject g in _lives) {
				g.transform.SetParent (this.transform, false);
				RectTransform rt = g.GetComponent<RectTransform> ();
				rt.localPosition = new Vector3 (rt.localPosition.x + _xPos, rt.localPosition.y, rt.localPosition.z);
				_xPos += _lifeDistance;
			}
		} else {
			_playerHealth = 3;
		}
	}
	
	// Update is called once per frame
	void Update () {
//        GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
//        _numberOfAsteroids = asteroids.Length;
//        GameObject text = GameObject.Find("Asteroids");
//        _score.text = _numberOfAsteroids.ToString();
		_timeLeft -= Time.deltaTime;
//		_score.text = Time.timeSinceLevelLoad.ToString();
		_score.text = _timeLeft.ToString();

		if (_timeLeft <= 0f) {
//			AsteroidController asteroid = GetC
			_playerHealth = 0;
			GameObject player = GameObject.Find ("Player");
			Destroy (player);
//			Time.timeScale = 0;
			_gameOver.text = "Time's Up!!".ToString();
			_score.text = 0f.ToString();
		}

    }

	public void DestroyLife() {
		if (_lives.Count > 0) {
			Destroy (_lives[_lives.Count-1]);
			_lives.RemoveAt (_lives.Count-1);
			_xPos -= _lifeDistance;
		}
	}

	public void AddLife() {
		_lives.Add (Instantiate (Resources.Load ("Prefabs/Life") as GameObject));
		_lives[_lives.Count-1].transform.SetParent (this.transform, false);
		RectTransform rt = _lives[_lives.Count-1].GetComponent<RectTransform> ();
		rt.localPosition = new Vector3 (rt.localPosition.x + _xPos, rt.localPosition.y, rt.localPosition.z);
		_playerHealth += 1;
		_xPos += _lifeDistance;
	}
}
