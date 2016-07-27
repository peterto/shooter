using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class RestartGameController : MonoBehaviour {

	public void StartOver () {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		if(Time.timeScale == 0)
			Time.timeScale = 1;
	}

	public void ExitLevel() {
		SceneManager.LoadScene (0);
		if(Time.timeScale == 0)
			Time.timeScale = 1;
	}
}
