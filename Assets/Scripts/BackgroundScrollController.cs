using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BackgroundScrollController : MonoBehaviour {

    private Vector2 _uvSpeed = new Vector2(0.0f, -0.5f);
    private Vector2 _uvOffset = Vector2.zero;
    private GameObject _player;

	public GameObject _musicPlayer;

	void Awake() {
		_musicPlayer = GameObject.Find ("music");
		if (_musicPlayer == null) {
			_musicPlayer = this.gameObject;
			_musicPlayer.name = "music";
			DontDestroyOnLoad (this.gameObject);
		} else {
			if (this.gameObject.name != "music") {
				Destroy (this.gameObject);
			}
		}

	}

	void Update () {
        _uvOffset += (_uvSpeed * Time.deltaTime);
        this.gameObject.GetComponent<Renderer>().materials[0].SetTextureOffset("_MainTex", _uvOffset);
        _player = GameObject.Find("Player");
        if (_player) {
            this.transform.position = _player.transform.position;
        }
	}
}
