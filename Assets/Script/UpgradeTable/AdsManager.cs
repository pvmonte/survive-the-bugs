using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using System.Collections;

public class AdsManager : MonoBehaviour {		
	public int adsExp;

	public void ShowRewardedAd(){
		adsExp = 0;
		InvokeRepeating ("PlusExp", 0f, 1.0f);
		if (Advertisement.IsReady("rewardedVideo"))
		{
			var options = new ShowOptions { resultCallback = HandleShowResult };
			Advertisement.Show("rewardedVideo", options);
		}
	}

	private void HandleShowResult(ShowResult result)
	{
		switch (result)
		{
		case ShowResult.Finished:
			Debug.Log ("The ad was successfully shown.");
			CancelInvoke ("PlusExp");
			UpgradeTable.exp += adsExp;
			break;
		case ShowResult.Skipped:
			Debug.Log("The ad was skipped before reaching the end.");
			break;
		case ShowResult.Failed:
			Debug.LogError("The ad failed to be shown.");
			break;
		}
	}

	void PlusExp(){
		if (Advertisement.isShowing) {
			adsExp = 10;
		}
	}

	public void PlayGame(){
		SceneManager.LoadScene ("LoadScreen");
	}

	public void Back(){
		SceneManager.LoadScene ("MainMenu");
	}
}