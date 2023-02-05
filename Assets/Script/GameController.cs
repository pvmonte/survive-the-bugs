using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameController : MonoBehaviour {
	public static GameController current;
	public float musicSrc;
	public float fxSrc;
	public bool english;
	public AudioSource buttonSrc;

	// Use this for initialization
	void Start () {
		current = this;
		english = false;
		DontDestroyOnLoad (gameObject);
		buttonSrc = GetComponent<AudioSource> ();
		buttonSrc.volume = PlayerPrefs.GetFloat ("music");
		/*musicSrc = 1f;
		fxSrc = 1f;*/
	}
	
	//SceneManagement
	public void QuitGame () {
		buttonSrc.Play ();
		Application.Quit ();
	}

	public void LoadGame(){
		buttonSrc.Play ();
		SceneManager.LoadScene ("Game");
	}

	public void LoadGameOver(){
		buttonSrc.Play ();
		SceneManager.LoadScene ("GameOver");
	}

	public void LoadUpgradeTable(){
		buttonSrc.Play ();
		SceneManager.LoadScene ("UpgradeTable");
	}

	public void LoadMainMenu(){
		buttonSrc.Play ();
		SceneManager.LoadScene ("MainMenu");
	}

	public void ClearAll(){
		buttonSrc.Play ();
		PlayerPrefs.DeleteAll ();
	}
}
