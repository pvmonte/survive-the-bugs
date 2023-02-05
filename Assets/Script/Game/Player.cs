using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {	
	public AudioSource fxSource;
	public AudioClip shotFx;
	public AudioClip bombFx;

	public GameObject bullet;
	public Transform bulletSpawn;
	public Vector3 pistalSpawn;
	public Vector3 mGunSpawn;
	private Vector3 target;
	public Sprite[] weapon;
	public SpriteRenderer sprt;

	public bool machineGun;
	public float mGunTime;
	public float hp;
	public float maxHP;
	private float fireRate = 0.75f;
	private float lastFire;

	//bomb
	public GameObject bomb;
	public int bombCount;

	//Prefab Pool
	public int pooledAmount = 10; //Bullets amount in pool
	List<GameObject> bullets;     //The pool whith the bullets

	// Use this for initialization
	void Start () {
		//creating pool
		bullets = new List<GameObject> ();
		for (int i = 0; i < pooledAmount; i++) {
			GameObject obj = (GameObject)Instantiate (bullet); //Bullet created
			obj.SetActive (false);							   //Bullets deactivated
			bullets.Add (obj);								   //Bullets added to pool
		}

		maxHP = 2 + UpgradeTable.current.maxHP;
		hp = maxHP;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (machineGun) {
			bulletSpawn.localPosition = mGunSpawn;
			sprt.sprite = weapon [1];
			fireRate = 0.2f - UpgradeTable.current.fireRate * 0.02f;
			mGunTime -= Time.deltaTime;
			if(mGunTime <= 0){
				machineGun = false;
				bulletSpawn.localPosition = pistalSpawn;
			}
		} else {
			sprt.sprite = weapon [0];
			fireRate = 0.8f - UpgradeTable.current.fireRate * 0.08f;
		}

		target = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		target.z = transform.position.z;

		if (Input.GetMouseButton (0)) {
			transform.right = (target - transform.position);

			if (Time.time >= lastFire + fireRate){
				Shot ();
				transform.right = (target - transform.position);
				lastFire = Time.time;
			}
		}

		if (Input.GetButtonDown ("Jump")) {
			Bomb ();
		}
	}

	void Shot(){		
		
		for(int i = 0; i < bullets.Count; i++){
			if (!bullets [i].activeInHierarchy) {					 //if the bullet "bullets[i]" isn't active in hierarchy
				bullets [i].transform.position = bulletSpawn.position; //bullets[i] = spawn position
				bullets [i].transform.rotation = transform.rotation; //bullets[i] = player's rotation
				bullets [i].SetActive (true);						 //bullets[i] is activated
				fxSource.PlayOneShot(shotFx);
				return;												 //the system won't repeat the process
			}
		}

		fxSource.PlayOneShot(shotFx);
		GameObject obj = (GameObject)Instantiate (bullet, bulletSpawn.position, transform.rotation);
		bullets.Add (obj);
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.CompareTag ("Bug")) {			
			hp -= 1;
			print ("Hit");

			if (hp <= 0) {
				if (InGameAds.countForAds == 2) {					
					InGameAds.instance.ShowAd ();
				}

				InGameAds.countForAds += 1;
				Achievements.instance.timesPlayed += 1;
				PlayerPrefs.SetInt ("timesPlayed", Achievements.instance.timesPlayed);
				PlayerPrefs.SetInt ("bugsKilled", Achievements.instance.bugsKilled);
				PlayerPrefs.SetInt ("bossKilled", Achievements.instance.bossKilled);
				PlayerPrefs.SetInt ("boxPicked", Achievements.instance.boxPicked);
				PlayerPrefs.SetFloat ("exp", UpgradeTable.exp);
				SceneManager.LoadScene ("GameOver");
			}
		}
	}

	public void Bomb(){
		if (bombCount > 0) {
			fxSource.PlayOneShot (bombFx);
			bomb.SetActive (true);
			bombCount -= 1;
		}
	}
}