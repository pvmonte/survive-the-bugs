using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnCreate : MonoBehaviour {
	public static SpawnCreate current;

	public GameObject box;
	public float pooledAmount;

	List<GameObject> boxList;

	void Awake(){
		current = this;
	}

	// Use this for initialization
	void Start () {
		boxList = new List<GameObject> ();
		for (int i = 0; i < pooledAmount; i++) {
			GameObject obj = (GameObject)Instantiate (box);
			obj.SetActive (false);
			boxList.Add (obj);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public GameObject GetPooledBox(){
		for (int i = 0; i < boxList.Count; i++) {
			if (!boxList [i].activeInHierarchy) {
				return boxList [i];
			}
		}

		GameObject obj = (GameObject)Instantiate (box);
		boxList.Add (obj);
		return obj;
	}
}
