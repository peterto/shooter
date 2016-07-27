using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuController : MonoBehaviour {

	private Animator _animator;
	public Transform _fadeToBlackCanvas;
	public Transform _shipSelection;
	public Transform _mainMenu;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ShipSelection() {
//        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
//		_fadeToBlackCanvas.gameObject.SetActive(true);
//		Invoke ("StartScene", 1f);
		_shipSelection.gameObject.SetActive(true);
		_mainMenu.gameObject.SetActive (false);

    }

	public void StartFreePlay() {
		_fadeToBlackCanvas.gameObject.SetActive(true);
		Invoke ("StartSceneFreeplay", 1f);
	}

	void StartScene() {
		PlayerPrefs.SetInt ("playerHealth", 3);
		PlayerPrefs.Save ();
		SceneManager.LoadScene(1);
	}

	void StartSceneFreeplay() {
		SceneManager.LoadScene(4);
	}

	public void SetShipSelection(int ship) {
		PlayerPrefs.SetInt ("Ship", ship);
		PlayerPrefs.Save ();
		_fadeToBlackCanvas.gameObject.SetActive(true);
		Invoke ("StartScene", 1f);
	}

	public void ExitGame() {
		Application.Quit ();
	}

}
