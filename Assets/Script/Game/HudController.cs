using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class HudController : MonoBehaviour {
	//UI Elements
	public Text timeLabel;
	public Text expLabel;
	public Text bombCount;
	public Text maxBomb;
	public Image hpImage;
	public Image mGunImg;

	//Fade
	public Image fadePanel;
	public float alpha;

	//Timer
	private int minutes = 5;
	private int seconds = 0;
	public int timeSinceStart = 0;
	private string secondsString;

	//Scripts
	private Player playerScript;
	private SoundController sndScript;
	private BugSpawn bugSpawnScript;

	//Dialog
	public GameObject dialogPanel;
	public Text dialog;
	private string[] dialogText = new string[6];
	private bool[] soundPlayed = new bool[7];
	private bool helicPlayed;
	private int index = 0;

	// Use this for initialization
	void Start () {
		playerScript = FindObjectOfType<Player> ();
		sndScript = FindObjectOfType<SoundController> ();
		bugSpawnScript = FindObjectOfType<BugSpawn> ();

		//Dialog
		dialogText [0] = "2º Batedor: - Aqui é 2º Batedor. Estou cercado. Envie ajuda!";
		dialogText [1] = "Falcão Peregrino: - Aqui é Falcão Peregrino. Temos sua localização. Chegada em cinco minutos.";
		dialogText [2] = "Falcão Peregrino: - Chegada em dois minutos. Quantos sobreviventes?";
		dialogText [3] = "2º Batedor: - Somente eu. Estão todos Mortos";
		dialogText [4] = "Falcão Peregrino: - Estamos sob ataque. Aguenta firme.";
		dialogText [5] = "Falcão Peregrino: - Estamos aqui, Batedor! Anda logo, Vamos cair fora!";

		dialog.text = dialogText [0];
		sndScript.fxSrc.PlayOneShot (sndScript.dialog [0]);

		InvokeRepeating ("Timer", 1.0f, 1.0f);

		maxBomb.text = UpgradeTable.current.maxBomb.ToString();
	}
	
	// Update is called once per frame
	void FixedUpdate () {		
		if (seconds > 9) {
			secondsString = seconds.ToString ();
		} else {
			secondsString = "0" + seconds.ToString ();
		}

		timeLabel.text = minutes.ToString () + ":" + secondsString;
		bombCount.text = playerScript.bombCount.ToString ();
		expLabel.text = "Exp: " + UpgradeTable.exp.ToString();
		hpImage.fillAmount = playerScript.hp / playerScript.maxHP;
		mGunImg.fillAmount = playerScript.mGunTime / (5 + (3 * UpgradeTable.current.machineGunTime));

		Dialog ();
	}

	void Timer(){
		seconds -= 1;
		if (seconds < 0) {
			seconds = 59;
			minutes -= 1;
		}
		timeSinceStart += 1;
	}

	void Dialog(){
		switch (timeSinceStart) {
		case 4: 
			index = 1;
			UpdateDialog ();
			break;
		case 9:
			dialogPanel.SetActive (false);
			bugSpawnScript.canSpawn = true;
			break;
		case 150:
			index = 2;
			UpdateDialog ();
			dialogPanel.SetActive (true);
			bugSpawnScript.canSpawn = false;
			break;
		case 154:
			index = 3;
			UpdateDialog ();
			dialogPanel.SetActive (true);
			break;
		case 159:
			dialogPanel.SetActive (false);
			bugSpawnScript.canSpawn = true;
			break;
		case 300:
			index = 4;
			UpdateDialog ();
			dialogPanel.SetActive (true);
			bugSpawnScript.canSpawn = false;
			timeLabel.gameObject.SetActive (false);
			break;
		case 304:
			dialogPanel.SetActive (false);
			bugSpawnScript.canSpawn = true;
			break;
		case 312:			
			if (!helicPlayed) {
				sndScript.fxSrc.PlayOneShot (sndScript.helicopter);
				helicPlayed = true;
			}
			break;
		case 315:
			index = 5;
			UpdateDialog ();
			dialogPanel.SetActive (true);
			bugSpawnScript.canSpawn = false;
			break;
		case 319:
			StartCoroutine (Fade ());
			break;
		case 320:
			PlayerPrefs.SetFloat ("exp", UpgradeTable.exp);
			SceneManager.LoadScene ("End");
			break;
		}
	}

	void UpdateDialog(){
		if(!soundPlayed[index]){				
			dialog.text = dialogText [index];
			sndScript.fxSrc.PlayOneShot (sndScript.dialog [index]);
			soundPlayed[index] = true;
		}
	}

	IEnumerator Fade(){
		alpha += 0.005f;
		fadePanel.color = new Color (0, 0, 0, alpha);

		yield return new WaitForSeconds(0.1f);

		StartCoroutine (Fade ());
	}
}