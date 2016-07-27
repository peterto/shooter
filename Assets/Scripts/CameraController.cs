using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {


	public float _shakeTimer;
	public float _shakeAmount;
	public AudioClip[] _audioClips;

    private GameObject _playerObject;
    private Vector3 _newPosition;

	void Start () {
        _playerObject = GameObject.Find("Player");
	}

    void Update () {
        if (_playerObject) {
            _newPosition = _playerObject.gameObject.transform.position;
            _newPosition.z = -10;
            this.gameObject.transform.position = _newPosition;
            //this.gameObject.transform.rotation = playerObject.gameObject.transform.rotation;
        }


		if (Input.GetKey (KeyCode.F)) {
			ShakeCamera (0.3f, 0.3f);
		}

		if (_shakeTimer >= 0) {
			Vector2 shakePosition = Random.insideUnitCircle * _shakeAmount;

			this.gameObject.transform.position = new Vector3 (transform.position.x + shakePosition.x, transform.position.y + shakePosition.y, transform.position.z);

			_shakeTimer -= Time.deltaTime;
		}
	}

	public void ShakeCamera(float shakePower, float shakeDuriation){
		_shakeAmount = shakePower;
		_shakeTimer = shakeDuriation;
	}

	void PlaySound(int clip) {
		//AudioSource audio = this.gameObject.GetComponent<AudioSource>();
		//audio.clip = audioClips[clip];
		//audio.Play();

		AudioSource audio = gameObject.AddComponent<AudioSource>();
		audio.clip = _audioClips[clip];
		audio.Play();
		Destroy(gameObject.GetComponent<AudioSource>());
	}
}


