using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOver : MonoBehaviour {
	public Text ranking;
	public Text obs;

	public Image[] achieveImg = new Image[6];

	private int numOfAchieve;
	private float alpha;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt ("bugsKilled") >= 1000) {
			StartCoroutine (ShowAchiev (0));
			numOfAchieve += 1;
		}

		if (PlayerPrefs.GetInt ("timesPlayedImg") >= 50) {
			StartCoroutine (ShowAchiev (1));
			numOfAchieve += 1;
		}

		if (PlayerPrefs.GetInt ("timesWatchedImg") >= 10) {
			StartCoroutine (ShowAchiev (2));
			numOfAchieve += 1;
		}

		if (PlayerPrefs.GetInt ("bossKilledImg") >= 25) {
			StartCoroutine (ShowAchiev (3));
			numOfAchieve += 1;
		}

		if (PlayerPrefs.GetInt ("boxPickedImg") >= 100) {
			StartCoroutine (ShowAchiev (4));
			numOfAchieve += 1;
		}

		if (PlayerPrefs.GetInt ("survivedImg") >= 1) {
			StartCoroutine (ShowAchiev (5));
			numOfAchieve += 1;
		}

		switch (numOfAchieve) {
		case 0:
			ranking.text = "Recruta";
			break;
		case 1:
			ranking.text = "Soldade";
			break;
		case 2:
			ranking.text = "Sargento";
			break;
		case 3:
			ranking.text = "Tenente";
			break;
		case 4:
			ranking.text = "Capitão";
			break;
		case 5:
			ranking.text = "Major";
			break;
		case 6:
			ranking.text = "Coronel";
			obs.text = "Você conseguiu todos os Troféus!";
			break;
		}

		Achievements.instance.survived = 1;
		PlayerPrefs.SetInt ("survived", 1);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Cancel")) {
			Application.Quit ();
		}
	}

	public void LoadMainMenu(){
		SceneManager.LoadScene ("MainMenu");
	}

	public void LoadUpgradeTable(){
		SceneManager.LoadScene ("UpgradeTable");
	}

	public void LoadGame(){
		SceneManager.LoadScene ("LoadScreen");
	}

	IEnumerator ShowAchiev(int i){
		yield return new WaitForSeconds (6f);

		for (float j = 0; j < 1f; j += 0.05f) {
			alpha = j;
			achieveImg[i].color = new Color (255, 255, 255, alpha);
			yield return null;
		}

		yield return null;
	}
}
