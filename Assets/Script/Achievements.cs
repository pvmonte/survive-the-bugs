using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Achievements : MonoBehaviour {
	public static Achievements instance;

	public Image bugsKilledImg;
	public Image timesPlayedImg;
	public Image timesWatchedImg;
	public Image bossKilledImg;
	public Image boxPickedImg;
	public Image survivedImg;

	public Text bugsKilledTxt;
	public Text timesPlayedTxt;
	public Text timesWatchedTxt;
	public Text bossKilledTxt;
	public Text boxPickedTxt;
	public Text survivedTxt;

	public int bugsKilled;
	public int timesPlayed;
	public int timesWatched;
	public int bossKilled;
	public int boxPicked;
	public int survived;

	// Use this for initialization
	void Start () {
		instance = this;

		bugsKilled = PlayerPrefs.GetInt("bugsKilled");
		timesPlayed = PlayerPrefs.GetInt("timesPlayed");
		timesWatched = PlayerPrefs.GetInt("timesWatched");
		bossKilled = PlayerPrefs.GetInt("bossKilled");
		boxPicked = PlayerPrefs.GetInt("boxPicked");
		survived = PlayerPrefs.GetInt("survived");

		if (PlayerPrefs.GetInt ("bugsKilled") <= 1000) {
			bugsKilledTxt.text = PlayerPrefs.GetInt ("bugsKilled").ToString () + "/1000";
		} else {
			bugsKilledTxt.gameObject.SetActive (false);
		}

		if (PlayerPrefs.GetInt ("timesPlayed") <= 50) {
			timesPlayedTxt.text = PlayerPrefs.GetInt ("timesPlayed").ToString () + "/50";
		} else {
			timesPlayedTxt.gameObject.SetActive (false);
		}

		if (PlayerPrefs.GetInt ("timesWatched") <= 10) {
			timesWatchedTxt.text = PlayerPrefs.GetInt ("timesWatched").ToString () + "/10";
		} else {
			timesWatchedTxt.gameObject.SetActive (false);
		}

		if (PlayerPrefs.GetInt ("bossKilled") <= 25) {
			bossKilledTxt.text = PlayerPrefs.GetInt ("bossKilled").ToString () + "/25";
		} else {
			bossKilledTxt.gameObject.SetActive (false);
		}

		if (PlayerPrefs.GetInt ("boxPicked") <= 100) {
			boxPickedTxt.text = PlayerPrefs.GetInt ("boxPicked").ToString () + "/100";
		} else {
			boxPickedTxt.gameObject.SetActive (false);
		}

		if (PlayerPrefs.GetInt ("survived") <= 1) {
			survivedTxt.text = PlayerPrefs.GetInt ("survived").ToString () + "/1";
		} else {
			survivedTxt.gameObject.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
