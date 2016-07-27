using UnityEngine;
using System.Collections;

public class ShipAnimationController : MonoBehaviour {

    private Animator _animator;
	private int _playerShip;
	private SpriteRenderer _spriteRenderer;

	public Sprite[] _ships;
	// Use this for initialization
	void Awake () {
		_animator = this.gameObject.GetComponent<Animator> ();
		_playerShip = PlayerPrefs.GetInt ("Ship");
		_animator.SetInteger ("ship", _playerShip);
		_spriteRenderer = GetComponent<SpriteRenderer> ();

		switch (_playerShip) {
			case 0:
                _animator.Play("lightningShip");
				this.gameObject.GetComponent<SpriteRenderer>().sprite = _ships[0];
				break;
			case 1:
                _animator.Play("ligherShip");
                this.gameObject.GetComponent<SpriteRenderer> ().sprite = _ships [1];
				break;
			case 2:
                _animator.Play("doveShip");
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = _ships [2];
				break;
			case 3:
                _animator.Play("ninjaShip");
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = _ships [3];
				break;
			case 4:
                _animator.Play("paranoidShip");
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = _ships [4];
				break;
			case 5:
                _animator.Play("saboteurShip");
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = _ships [5];
				break;
			case 6:
                _animator.Play("ufoShip");
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = _ships [6];
				break;
			default:
				break;
		}


	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown(KeyCode.Alpha1)) {
            _animator.SetInteger("ship", 0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            _animator.SetInteger("ship", 1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            _animator.SetInteger("ship", 2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4)) {
            _animator.SetInteger("ship", 3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5)) {
            _animator.SetInteger("ship", 4);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6)) {
            _animator.SetInteger("ship", 5);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7)) {
            _animator.SetInteger("ship", 6);
        }

    }
}
