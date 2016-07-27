using UnityEngine;
using System.Collections;

public class GameOverController : MonoBehaviour {


	public Transform _gameoverCanvas;

    private GameObject _player;
    private Animator _animator;
	// Use this for initialization

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        _player = GameObject.Find("Player");

        if (!_player) {
            //_gameoverCanvas = GameObject.Find("GameOver").transform;
			if (!_gameoverCanvas.gameObject.activeInHierarchy) {
                _gameoverCanvas.gameObject.SetActive(true);
            }
        }
	}
}
