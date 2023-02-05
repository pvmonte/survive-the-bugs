using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UpgradeTable : MonoBehaviour {
	public static UpgradeTable current;
	public float fireRate;
	public float machineGunTime;
	public float maxBomb;
	public float maxHP;
	public float boxRate;
	public float maxBarrierHP;

	public static float exp;
	public Text expNum;

	//UpgradeTable
	public Text expText;
	public Image fireRateImg;
	public Image machineGunTimeImg;
	public Image maxBombImg;
	public Image maxHPImg;
	public Image boxRateImg;
	public Image maxBarrierHPImg;

	void Awake(){
		
	}

	void Start(){
		current = this;

		fireRate = PlayerPrefs.GetFloat ("fireRate");
		machineGunTime = PlayerPrefs.GetFloat ("machineGunTime");
		maxBomb = PlayerPrefs.GetFloat ("maxBomb");
		maxHP = PlayerPrefs.GetFloat ("maxHP");
		boxRate = PlayerPrefs.GetFloat ("boxRate");
		maxBarrierHP = PlayerPrefs.GetFloat ("maxBarrierHP");
		exp = PlayerPrefs.GetFloat ("exp");

		if(SceneManager.GetActiveScene().name == "UpgradeTable"){
			expText = GameObject.Find("ExpText").GetComponent<Text>();
			fireRateImg = GameObject.Find("FireRateLevel").GetComponent<Image>();
			machineGunTimeImg = GameObject.Find("MGunTimeLevel").GetComponent<Image>();
			maxBombImg = GameObject.Find("MaxBombLevel").GetComponent<Image>();
			maxHPImg = GameObject.Find("MaxHPLevel").GetComponent<Image>();
			boxRateImg = GameObject.Find("BoxRateLevel").GetComponent<Image>();
			maxBarrierHPImg = GameObject.Find("MaxBarrierLevel").GetComponent<Image>();

			expNum = GameObject.Find ("ExpNum").GetComponent<Text>();


			fireRateImg.fillAmount = fireRate / 5;
			machineGunTimeImg.fillAmount = machineGunTime / 5;

			if (PlayerPrefs.GetFloat ("maxBomb") < 1) {
				maxBomb = 1;
			}
			maxBombImg.fillAmount = (maxBomb - 1) / 5;

			maxHPImg.fillAmount = maxHP / 5;
			boxRateImg.fillAmount = boxRate / 5;
			maxBarrierHPImg.fillAmount = maxBarrierHP / 5;
		}
	}

	void Update(){
		if (SceneManager.GetActiveScene ().name == "UpgradeTable") {
			expNum.text = exp.ToString ();
		}
	}

	public void PlusFireRate(){
		if((exp - (200 * Mathf.Pow(2.0f, fireRate))) >= 0 && fireRate <= 4){
			exp -= (200 * Mathf.Pow(2.0f, fireRate));
			fireRate += 1;
			fireRateImg.fillAmount += 0.20f;
			PlayerPrefs.SetFloat ("fireRate", fireRate);
			PlayerPrefs.SetFloat ("exp", exp);
			GameController.current.buttonSrc.Play ();
		}
	}

	public void PlusMachineGunTime(){
		if ((exp - (200 * Mathf.Pow(2.0f, machineGunTime))) >= 0 && machineGunTime <= 4) {
			exp -= (200 * Mathf.Pow (2.0f, machineGunTime));
			machineGunTime += 1;
			machineGunTimeImg.fillAmount += 0.20f;
			PlayerPrefs.SetFloat ("machineGunTime", machineGunTime);
			PlayerPrefs.SetFloat ("exp", exp);
			GameController.current.buttonSrc.Play ();
		}
	}

	public void PlusMaxBomb(){
		if ((exp - (200 * Mathf.Pow(2.0f, maxBomb))) >= 0 && maxBomb <= 5) {
			exp -= (200 * Mathf.Pow(2.0f, maxBomb));
			maxBomb += 1;
			maxBombImg.fillAmount += 0.20f;
			PlayerPrefs.SetFloat ("maxBomb", maxBomb);
			PlayerPrefs.SetFloat ("exp", exp);
			GameController.current.buttonSrc.Play ();
		}
	}

	public void PlusMaxHP(){
		if ((exp - (200 * Mathf.Pow(2.0f, maxHP))) >= 0 && maxHP <= 4) {
			exp -= (200 * Mathf.Pow(2.0f, maxHP));
			maxHP += 1;
			maxHPImg.fillAmount += 0.20f;
			PlayerPrefs.SetFloat ("maxHP", maxHP);
			PlayerPrefs.SetFloat ("exp", exp);
			GameController.current.buttonSrc.Play ();
		}
	}

	public void PlusBoxRate(){
		if ((exp - (200 * Mathf.Pow(2.0f, boxRate))) >= 0 && boxRate <= 4) {
			exp -= (200 * Mathf.Pow(2.0f, boxRate));
			boxRate += 1;
			boxRateImg.fillAmount += 0.20f;
			PlayerPrefs.SetFloat ("boxRate", boxRate);
			PlayerPrefs.SetFloat ("exp", exp);
			GameController.current.buttonSrc.Play ();
		}
	}

	public void PlusMaxBarrierHP(){
		if ((exp - (200 * Mathf.Pow(2.0f, maxBarrierHP))) >= 0 && maxBarrierHP <= 4) {
			exp -= (200 * Mathf.Pow(2.0f, maxBarrierHP));
			maxBarrierHP += 1;
			maxBarrierHPImg.fillAmount += 0.20f;
			PlayerPrefs.SetFloat ("maxBarrierHP", maxBarrierHP);
			PlayerPrefs.SetFloat ("exp", exp);
			GameController.current.buttonSrc.Play ();
		}
	}
}