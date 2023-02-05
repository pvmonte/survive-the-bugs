using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ConfigPanel : MonoBehaviour {
	public GameController gameController;
	public Animator anim;

	public Slider musicVolume;
	public Slider fxVolume;

	public float mscVol;
	public float fxVol;

	//public GameObject panel;

	// Use this for initialization
	void Start () {
		gameController = FindObjectOfType<GameController> ();
		anim = GetComponent<Animator> ();

		gameController.musicSrc = 1f;
		gameController.fxSrc = 1f;

		PlayerPrefs.SetFloat ("music", gameController.musicSrc);    // 0 = off, 1 = on
		PlayerPrefs.SetFloat ("fx", gameController.fxSrc);		// 0 = off, 1 = on
		PlayerPrefs.SetInt ("language", 1); // 0 = português, 1 = inglês
	}

	void Update(){
		mscVol = gameController.musicSrc;
		fxVol = gameController.fxSrc;
	}

	public void CallPanel(){
		GameController.current.buttonSrc.Play ();
		anim.enabled = true;
		anim.SetBool ("goUp", false);
	}

	public void TurnOffPanel(){
		GameController.current.buttonSrc.Play ();
		anim.SetBool ("goUp", true);
	}

	public void MusicVolume(){
		gameController.musicSrc = musicVolume.value;
		PlayerPrefs.SetFloat ("music", gameController.musicSrc);		
	}

	public void SoundFXVolume(){
		gameController.fxSrc = fxVolume.value;
		PlayerPrefs.SetFloat ("fx", gameController.fxSrc);
	}

	public void SwitchLanguage(){
		gameController.english = !gameController.english;
		if (PlayerPrefs.GetInt ("language") == 0) {
			PlayerPrefs.SetInt ("language", 1);
		} else {
			PlayerPrefs.SetInt ("language", 0);
		}
	}
}
