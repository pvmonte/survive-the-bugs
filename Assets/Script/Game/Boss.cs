using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {
	public Vector3 target;
	public SpriteRenderer sptRenderer;
	public GameObject bigExplosion;
	private int hp = 5;

	// Use this for initialization
	void Start () {		
		target = FindObjectOfType<Player> ().transform.position;
		Physics.IgnoreLayerCollision (8, 8);
	}

	void OnEnable(){
		hp = 5;
	}

	// Update is called once per frame
	void Update () {
		transform.right = (target - transform.position);	
		transform.Translate (8 * Time.deltaTime, 0, 0);
	}

	void OnTriggerEnter2D(Collider2D col){		
		if (col.CompareTag ("Bullet") || col.CompareTag("Bomb") || col.CompareTag("Barrier")) {			
			hp -= 1;
			if (hp == 0) {
				SpawnBox ();
				Achievements.instance.bugsKilled += 1;
				Achievements.instance.bossKilled += 1;
				UpgradeTable.exp += 50;
				bigExplosion.transform.position = transform.position;
				bigExplosion.SetActive (true);
				this.gameObject.SetActive (false);
			} else {
				SpawnParticle ();
			}

		} else if (col.CompareTag("Player") ) {
			this.gameObject.SetActive (false);			
		}


	}

	void SpawnBox(){
		GameObject box = SpawnCreate.current.GetPooledBox ();

		if (box == null) return;

		box.transform.position = transform.position;
		box.SetActive (true);
	}

	void SpawnParticle(){
		GameObject particle = BloodParticle.current.GetPooledParticle();

		if (particle == null) return;

		particle.transform.position = transform.position;
		particle.transform.rotation = transform.rotation;
		if (hp == 0) {
			particle.transform.localScale = new Vector2 (2, 2);
		}
		particle.SetActive (true);
	}
}
