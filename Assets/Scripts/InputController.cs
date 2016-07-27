using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {

	public float _playerSpeed = 10.0f;
	public AudioClip[] _audioClips;
	public GameObject _BulletPrefab;
	public float _fireRate = 1f;

	private Vector2 _mousePosition;
	private Vector2 _direction;
	private Transform _transform;
	private float _angle;
	private Rigidbody2D _rBody;
	private float next = 0f;
	private ParticleSystem _flames;

	// Use this for initialization
	void Start () {
		_transform = transform;
		_rBody = this.gameObject.GetComponent<Rigidbody2D> ();
		_flames = this.gameObject.GetComponentInChildren<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
	
		float rx = Input.GetAxis ("Right_Horizontal");
		float ry = Input.GetAxis ("Right_Vertical");
		_angle = Mathf.Atan2 (rx, ry) * Mathf.Rad2Deg;

		_transform.rotation = Quaternion.Euler (0, 0, _angle);

//		print (Input.GetAxis ("Left_Trigger"));
		if(Input.GetAxis("Left_Trigger") == 1) {
			PlaySound (1);
			_flames.Emit (1);
			Vector3 direction = this.transform.up;
			_rBody.AddForce (direction * _playerSpeed);
		}

		if (next > 0) {
			next = next * Time.deltaTime;
		} else if (Input.GetAxis("Right_Trigger") == 1) {
			PlaySound (0);
			Vector3 direction = this.transform.up;
			_rBody.AddForce (-direction * 50f);
			//				_rBody.AddForce (direction * 50f);
			next = next + _fireRate;
			Instantiate (_BulletPrefab, transform.position, transform.rotation);
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
