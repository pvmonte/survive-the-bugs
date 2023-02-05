using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Barrier : MonoBehaviour {
	public float health;
	public float maxHealth;
	public Image healthImg;

	public GameObject ray1;
	public GameObject ray2;
	public BoxCollider2D bCollider;


	// Use this for initialization
	void Start () {
		bCollider = GetComponent<BoxCollider2D> ();
		maxHealth = 1 + UpgradeTable.current.maxBarrierHP;
		health = maxHealth;
	}

	void Update(){
		healthImg.fillAmount = health / maxHealth;
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.CompareTag ("Bug")) {
			health -= 1;

			col.gameObject.SetActive (false);

			if (health <= 0) {
				ray1.SetActive(false);
				ray2.SetActive(false);
				bCollider.enabled = false;
			}
		}
	}
}
