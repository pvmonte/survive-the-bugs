using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneLoader : MonoBehaviour {
	AsyncOperation loading;
	public Image progressBar;
	public Text loadingText;

	public bool isfakeLoadingBar = false;
	public float fakeIncrement = 0f;
	public float fakeTiming = 0f;


	// Use this for initialization
	void Start () {
		PlayGame ();
	}	

	public void PlayGame(){
		
		progressBar.gameObject.SetActive (true);
		loadingText.gameObject.SetActive (true);
		loadingText.text = "Carregando...";

		if (!isfakeLoadingBar) {
			StartCoroutine (LoadLevel ());
		} else {
		
		}
	}

	IEnumerator LoadLevel(){
		yield return new WaitForSeconds (1);

		loading = SceneManager.LoadSceneAsync ("Game");
		loading.allowSceneActivation = false;

		while (!loading.isDone) {
			progressBar.fillAmount = loading.progress;
			loadingText.text = "Carregando " + loading.progress * 100 + "%";

			if (loading.progress == 0.9f) {
				progressBar.fillAmount = 1.0f;
				loadingText.text = "Ready";
				yield return new WaitForSeconds (1);
				loading.allowSceneActivation = true;
			}

			print (loading.progress);
			yield return null;
		}

	}


}
