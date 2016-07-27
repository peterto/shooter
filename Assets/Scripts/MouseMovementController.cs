using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MouseMovementController : MonoBehaviour {

    public float _playerSpeed = 10.0f;
    public AudioClip[] _audioClips;
    public GameObject _BulletPrefab;
    public float _fireRate = 1f;
	public bool _stopMovement = false;

    private Vector2 _mousePosition;
    private Vector2 _direction;
    private Transform _transform;
    private float _angle;
    private ParticleSystem _flames;
    private float next = 0f;
    private Rigidbody2D _rBody;


    void Start() {
        _transform = transform;
        _flames = this.gameObject.GetComponentInChildren<ParticleSystem>();
        _rBody = this.gameObject.GetComponent<Rigidbody2D>();
    }

    void Update () {

		if (!_stopMovement) {
			_mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			_direction = (_mousePosition - (Vector2)_transform.position).normalized;

			_angle = Mathf.Atan2 (_direction.y, _direction.x) * Mathf.Rad2Deg + -90;
			_transform.rotation = Quaternion.AngleAxis (_angle, Vector3.forward);

			if (Input.GetKey (KeyCode.W)) {
				PlaySound (1);
				_flames.Emit (1);
				Vector3 direction = this.transform.up;
				_rBody.AddForce (direction * _playerSpeed);
			}

//			if (Input.GetMouseButton (1)) {
////				List<GameObject> visibleAsteroids = new List<GameObject>();
//				GameObject[] visibleAsteroids = GameObject.FindGameObjectsWithTag("Asteroid");
//
//				for (int i = 0; i < visibleAsteroids.Length; i++) {
//					Renderer rderer = visibleAsteroids [i].GetComponent<Renderer> ();
//					if (rderer.isVisible) {
//						visibleAsteroids [i].GetComponent<AsteroidController> ().DestroyAsteroid ();
//					}
//				}
//			}

			if (Input.GetMouseButton (1)) {
				//				List<GameObject> visibleAsteroids = new List<GameObject>();
				PlaySound (1);
				_flames.Emit (1);
				Vector3 direction = this.transform.up;
				_rBody.AddForce (direction * 20);
			}

			if (next > 0) {
				next = next * Time.deltaTime;
			} else if (Input.GetKey (KeyCode.RightControl) || (Input.GetMouseButton (0))) {
				PlaySound (0);
				Vector3 direction = this.transform.up;
				_rBody.AddForce (-direction * 50f);
//				_rBody.AddForce (direction * 50f);
				next = next + _fireRate;
				Instantiate (_BulletPrefab, transform.position, transform.rotation);
			}
		}
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
