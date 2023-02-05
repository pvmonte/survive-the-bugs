using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BugSpawn : MonoBehaviour {
	public GameObject bug;
	public GameObject boss;
	public float spawnRate;
	public bool canSpawn;

	//Pool
	public int pooledAmount = 100;
	public List<GameObject> bugsList;

	// Use this for initialization
	void Start () {		
		bugsList = new List<GameObject> ();
		for (int i = 0; i < pooledAmount; i++) {
			GameObject obj = Instantiate (bug);
			obj.SetActive (false);
			bugsList.Add (obj);
		}

		InvokeRepeating ("Spawn", 0, spawnRate);
		InvokeRepeating ("UpdateSpawnRate15s", 15.0f, 15.0f);
		InvokeRepeating ("SpawnBoss", 60.0f, 60.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Spawn(){
		if (canSpawn) {
			float rnd = Random.Range (-12.0f, 12.0f);
			transform.position = new Vector3 (22, rnd, 0);

			for (int i = 0; i < bugsList.Count; i++) {
				if (!bugsList [i].activeInHierarchy) {
					bugsList [i].transform.position = transform.position;
					bugsList [i].transform.rotation = transform.rotation;
					bugsList [i].SetActive (true);
					return;
				}
			}

			GameObject obj = (GameObject)Instantiate (bug, transform.position, transform.rotation);
			bugsList.Add (obj);
		}
	}

	void SpawnBoss(){
		boss.transform.position = transform.position;
		boss.SetActive (true);
	}

	void UpdateSpawnRate15s(){
		spawnRate -= 0.05f;
		CancelInvoke ("Spawn");
		InvokeRepeating ("Spawn", 0, spawnRate);
	}
}