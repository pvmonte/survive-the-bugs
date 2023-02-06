using UnityEngine;
using UnityEngine.Advertisements;

public class InGameAds : MonoBehaviour {
	public static InGameAds instance;
	public static int countForAds;
	public int testCount;

	void Start(){
		instance = this;
		testCount = countForAds;
	}

	public void ShowAd()
	{
		//if (Advertisement.IsReady ()) {
		//	Advertisement.Show ();
		//	countForAds = 0;
		//	//Time.timeScale = 1;
		//}
		
	}
}
