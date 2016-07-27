using UnityEngine;
using System.Collections;

//Adds new life to player upon touching power up.
public class AddNewLifeController : MonoBehaviour {


	private ScoreDisplayController _sdc;

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.CompareTag ("Player")) {
			_sdc = GameObject.Find ("Canvas").GetComponent<ScoreDisplayController> ();
			_sdc.AddLife ();
			Destroy (this.gameObject);
		}
	}
}
