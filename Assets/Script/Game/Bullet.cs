using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (50* Time.deltaTime, 0, 0);
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.CompareTag("Bug") || col.CompareTag("Box")){
			this.gameObject.SetActive (false);
		}
	}

	void OnBecameInvisible(){
		this.gameObject.SetActive (false);
	}
}
