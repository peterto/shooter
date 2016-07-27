using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    public GameObject _BulletPrefab;
    public float _fireRate = 1f;
	public bool _stopMovement = false;

    [SerializeField] Toggle keyboard;
    [SerializeField] Toggle mouse;
    [SerializeField] Toggle controller;

    [SerializeField]
    public int _playerDirection;
    public float _playerSpeed = 10.0f;
    public float _torqueSpeed = 0.05f;
    public float _rotationalSpeed = 1f;
    public float _dragSpeed = 1.0f;
    //public Renderer[] renderers;
    public AudioClip[] _audioClips;
    public int _currentInput;

    private ParticleSystem _flames;
    private float next = 0f;
    private Rigidbody2D _rBody;

    void Start() {
//        _currentInput = PlayerPrefs.GetInt("input");
//
//        if(keyboard.isOn) {
//            _currentInput = 1;
//            PlayerPrefs.SetInt("input", 1);
//            mouse.isOn = false;
//            controller.isOn = false;
//        } else if(mouse.isOn) {
//            _currentInput = 1;
//            PlayerPrefs.SetInt("input", 1);
//            keyboard.isOn = false;
//            controller.isOn = false;
//        } else if(controller.isOn) {
//            _currentInput = 1;
//            PlayerPrefs.SetInt("input", 1);
//            mouse.isOn = false;
//            controller.isOn = false;
//        }
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

    void Update() {

        _flames = this.gameObject.GetComponentInChildren<ParticleSystem>();
        _rBody = this.gameObject.GetComponent<Rigidbody2D>();

		if (!_stopMovement) {
			if (Input.GetKey (KeyCode.UpArrow)) {
				PlaySound (1);
				_flames.Emit (1);
				Vector3 direction = this.transform.up;
				_rBody.AddForce (direction * _playerSpeed);
			}

			if (Input.GetKey (KeyCode.RightArrow)) {
				//_rBody.AddTorque(-torqueSpeed);
				_rBody.drag = _dragSpeed;
				_rBody.transform.Rotate (0, 0, -_rotationalSpeed * _rotationalSpeed);
			}
			if (Input.GetKey (KeyCode.LeftArrow)) {
				//_rBody.AddTorque(torqueSpeed);
				_rBody.transform.Rotate (0, 0, _rotationalSpeed * _rotationalSpeed);
				_rBody.drag = _dragSpeed;
			}

			if (next > 0) {
				next = next * Time.deltaTime;
			} else if (Input.GetKey ("space")) {
				PlaySound (0);
				next = next + _fireRate;
				Instantiate (_BulletPrefab, transform.position, transform.rotation);            
			}
		}
    }


}