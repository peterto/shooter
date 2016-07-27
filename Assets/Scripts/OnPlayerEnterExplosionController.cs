using UnityEngine;
using System.Collections;

public class OnPlayerEnterExplosionController : MonoBehaviour {

	private Renderer _renderer;
	private Animator _animator;

	void Start() {
		_renderer = this.gameObject.GetComponent<Renderer>();
		_animator = this.gameObject.GetComponent<Animator>();
	}

	void Update () {
		if (_renderer.isVisible) {
			_animator.enabled = true;
			Camera.main.GetComponent<CameraController> ().ShakeCamera (0.3f, 0.3f);
			Destroy (this.gameObject, 0.5f);
		}
	}
}
