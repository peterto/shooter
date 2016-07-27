using UnityEngine;
using System.Collections;

public class MovementWrapController : MonoBehaviour {

	void Update () {
        Vector3 pos = transform.position;

        if (transform.position.y < -6f) {
            pos.y = 6f;
        }
        if (transform.position.y > 6f) {
            pos.y = -6f;
        }
        if (transform.position.x < -11f) {
            pos.x = 11f;
        }
        if (transform.position.x > 11f) {
            pos.x = -11f;
        }
        transform.position = pos;
    }
}
