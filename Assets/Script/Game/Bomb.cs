using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {
	private float scale;

	void OnEnable(){
		scale = 0.0f;
		Invoke ("Deactivate", 1.0f);
		print ("Enable");
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale = new Vector3 (scale, scale, 1);
		scale += 45 * Time.deltaTime;
	}

	void Deactivate(){
		scale = 0.0f;
		gameObject.SetActive (false);
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.CompareTag ("Bug")) {
			col.gameObject.SetActive (false);
		}
	}
}
