using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

    public float _speed = 10f;
    private Rigidbody2D _rBody;
    private Renderer _renderer;

	void Start () {
        _rBody = this.gameObject.GetComponent<Rigidbody2D>();
        _rBody.velocity = transform.up * _speed;
        _renderer = this.gameObject.GetComponent<Renderer>();
    }
    
    void Update () {
        if(!_renderer.isVisible) {
            Destroy(this.gameObject);
        }
    }
        
}
