using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BloodParticle : MonoBehaviour {
	public static BloodParticle current;

	public GameObject particle;
	public int pooledAmont;
	public List<GameObject> particleList;

	void Awake(){
		current = this;
	}

	// Use this for initialization
	void Start () {
		particleList = new List<GameObject> ();
		for (int i = 0; i < pooledAmont; i++) {
			GameObject obj = (GameObject)Instantiate (particle);
			obj.SetActive (false);
			particleList.Add (obj);
		}
	}

	public GameObject GetPooledParticle(){
		for(int i = 0; i < particleList.Count; i++){
			if(particleList[i].activeInHierarchy == false){
				return particleList[i];
			}
		}

		GameObject obj = (GameObject)Instantiate(particle);
		particleList.Add(obj);
		return obj;
	}
}
