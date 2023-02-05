using UnityEngine;
using System.Collections;

public enum UpgradeType {
	plusHealth,
	machineGun,
	plusBomb,
	plusBarrierHP
}

public class Upgrade : MonoBehaviour {
	public AudioSource fxSource;
	public AudioClip gatlingFx;
	public AudioClip boxFx;

	public Sprite[] img;
	public SpriteRenderer sptRend;

	public UpgradeType type;
	public Player player;
	public Barrier barrier;


	// Use this for initialization
	void Start () {
		fxSource = GameObject.Find ("FxSource").GetComponent<AudioSource> ();
		player = FindObjectOfType<Player> ();
		barrier = FindObjectOfType<Barrier> ();
	}

	void OnEnable(){
		int rnd = Random.Range (1, 5);

		switch (rnd) {
		case 1:
			type = UpgradeType.machineGun;
			break;
		case 2:
			type = UpgradeType.plusBomb;
			break;
		case 3:
			type = UpgradeType.plusHealth;
			break;
		case 4:
			type = UpgradeType.plusBarrierHP;
			break;
		}

		sptRend.sprite = img [rnd -1];
		transform.Translate (0.5f, 0, 0);
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.CompareTag ("Bullet")) {
			switch (type) {
			case UpgradeType.machineGun:				
				player.machineGun = true;
				player.mGunTime = 5 + (3 * UpgradeTable.current.machineGunTime);
				fxSource.PlayOneShot (gatlingFx);
				break;
			case UpgradeType.plusBomb:
				if (player.bombCount < UpgradeTable.current.maxBomb) {
					player.bombCount += 1;
				}
				break;
			case UpgradeType.plusHealth:
				if (player.hp < player.maxHP) {
					player.hp += 1;
				}
				break;
			case UpgradeType.plusBarrierHP:
				if (barrier.health < barrier.maxHealth) {
					if (barrier.health == 0) {
						barrier.ray1.SetActive (true);
						barrier.ray2.SetActive (true);
						barrier.bCollider.enabled = true;
					}

					barrier.health += 1;
				}
				break;
			}

			Achievements.instance.boxPicked += 1;
			fxSource.PlayOneShot (boxFx);
			gameObject.SetActive (false);
		}
	}
}
