using UnityEngine;
using System.Collections;

public enum BugType{
	Normal,
	Fast,
	Boss
}

public class Bug : MonoBehaviour {
	public BugType type;
	public Vector3 target;
	public SpriteRenderer sptRenderer;
	private float speed;

	// Use this for initialization
	void Start () {
		//sptRenderer = GetComponent<SpriteRenderer> ();
		target = FindObjectOfType<Player> ().transform.position;
		Physics.IgnoreLayerCollision (8, 8);
	}

	void OnEnable(){
		int rnd = Random.Range (0, 100);
		if (rnd < 10) {
			type = BugType.Fast;
			sptRenderer.color = Color.green;
			speed = 15.0f;
		} else {
			type = BugType.Normal;
			sptRenderer.color = Color.red;
			speed = 10.0f;
		}
	}
	
	// Update is called once per frame
	void Update () {
		transform.right = (target - transform.position);	
		transform.Translate (speed * Time.deltaTime, 0, 0);
	}

	void OnTriggerEnter2D(Collider2D col){		
		if (col.CompareTag ("Bullet") || col.CompareTag("Bomb")) {			
			int rnd = Random.Range (1, 101);
			if (rnd <= 5 + UpgradeTable.current.boxRate) {
				SpawnBox ();
			}

			SpawnParticle ();
			Achievements.instance.bugsKilled += 1;
			UpgradeTable.exp += 10;
			this.gameObject.SetActive (false);

		} else if (col.CompareTag("Player") || col.CompareTag("Barrier")) {
			SpawnParticle ();
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
		particle.SetActive (true);
	}
}
