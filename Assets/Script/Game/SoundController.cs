using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour {	
	public AudioSource musicSrc;
	public AudioSource fxSrc;

	public AudioClip musicSound;
	public AudioClip shotFx;
	public AudioClip explosion;
	public AudioClip gatling;
	public AudioClip helicopter;

	public AudioClip[] dialog = new AudioClip[6];

	void Awake(){		
		musicSrc.volume = 0;
		StartCoroutine (AdjustMusic ());
		//musicSrc.volume = GameController.current.musicSrc;
		fxSrc.volume = GameController.current.fxSrc;
	}

	IEnumerator AdjustMusic(){
		for (float i = 0; i < GameController.current.musicSrc; i += 0.05f) {
			musicSrc.volume = i;

			yield return null;
		}

		musicSrc.volume = GameController.current.musicSrc;
		yield return null;
	}
}
