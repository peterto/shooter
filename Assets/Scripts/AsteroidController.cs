using UnityEngine;
using System.Collections;

public class AsteroidController : MonoBehaviour {

    public GameObject nextAsteroid;
    public float _speed = 1f;
    public float _torqueSpeed = 10.0f;
    public int _randomDirection;
    public AudioClip[] _audioClips;
    public Animator _animator;
	public Animator _playerAnimator;

    private Rigidbody2D _rBody;
    private Renderer _renderer;

    void Start () {
        _rBody = this.gameObject.GetComponent<Rigidbody2D>();
        _renderer = this.gameObject.GetComponent<Renderer>();
        _animator = this.gameObject.GetComponent<Animator>();

		//determines random direction for asteroids to move in space.
        _randomDirection = Random.Range(0, 3);
        switch (_randomDirection) {
            case 0:
                _rBody.velocity = transform.right * _speed;
                break;
            case 1:
                _rBody.velocity = transform.right * -_speed;
                break;
            case 2:
                _rBody.velocity = transform.up * _speed;
                break;
            case 3:
                _rBody.velocity = transform.up * -_speed;
                break;
            default:
                _rBody.velocity = transform.right * _speed;
                break;
        }
		//Gives a random rotational speed of new asteroids
        _rBody.AddTorque(Random.Range(-_torqueSpeed, _torqueSpeed));
	}
	
	void Update() {
	}

	//Plays referenced audio clip
    void PlaySound(int clip) {
        AudioSource audio = this.gameObject.GetComponent<AudioSource>();
        audio.clip = _audioClips[clip];
        audio.Play();
    }

    void OnTriggerEnter2D(Collider2D col) {
		//Checks for collision with projectials fired by player, if it collides with the asteroid, it'll set animation (explosion animation) to active, and if it's a larger asteroid,
		//it'll creating two more that reflect off two opposite angles. Then, it destroys its own gameobject and the bullet that hit it.
        if (col.gameObject.CompareTag("Bullet")) {
            PlaySound(0);
            _animator.enabled = true;
			this.gameObject.GetComponent<CircleCollider2D> ().enabled = false;
            if (nextAsteroid) {
                float angle = Mathf.Atan2(_rBody.velocity.y, _rBody.velocity.x) * Mathf.Rad2Deg;
                Instantiate(nextAsteroid, transform.position, Quaternion.Euler(0, 0, angle - 60));
                Instantiate(nextAsteroid, transform.position, Quaternion.Euler(0, 0, angle + 60));
            }

            Destroy(this.gameObject, 1f);
            Destroy(col.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.CompareTag("Player")) {
			//Sets up and displays the number of lives (hits) a player has left on the top right corner of the screen.
			//If player is it, screen (camera) will shake, and one of the lives will be decreased, a ship on the top right
			//will be removed until there are none left.
			GameObject scoreDisplayController = GameObject.Find("Canvas");
            int playerHealth = scoreDisplayController.GetComponent<ScoreDisplayController>()._playerHealth;

            if (playerHealth > 0) {
                playerHealth--;
				screenShake ();
				scoreDisplayController.GetComponent<ScoreDisplayController> ().DestroyLife ();
                scoreDisplayController.GetComponent<ScoreDisplayController>()._playerHealth = playerHealth;
            
            } else if (playerHealth == 0) {                      
                //Destroy(GameObject.Find("Score1"));
				//screenShake ();
				PlaySound (0);
				_playerAnimator = col.gameObject.GetComponent<Animator>();
				col.gameObject.GetComponent<PolygonCollider2D>().enabled = false;
				_playerAnimator.SetBool ("dead", true);
				Destroy(col.gameObject, 0.5f);
				PlayerPrefs.SetInt ("playerHealth", 3);
            }
        }
    }

	void screenShake() {
		Camera.main.GetComponent<CameraController> ().ShakeCamera (0.3f, 0.3f);
		PlaySound (1);
	}

	public void DestroyAsteroid() {
		PlaySound(0);
		_animator.enabled = true;
		this.gameObject.GetComponent<CircleCollider2D> ().enabled = false;
		Destroy(this.gameObject, 1f);
	}

	void PlayerDeath(){

	}
}
