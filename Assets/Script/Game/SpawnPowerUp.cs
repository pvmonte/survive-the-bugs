using UnityEngine;
using System.Collections;

public class SpawnPowerUp : MonoBehaviour {
	[SerializeField]private GameObject create;
	[SerializeField]private float spawnRate;

	public float rndPosX;
	public float rndPosY;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("SpawnCreate", spawnRate, spawnRate);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void SpawnCreate(){		
		rndPosX = Random.Range (0.0f, 5.0f); 
		rndPosY = Random.Range (-2.65f, 2.65f);

		transform.position = new Vector3 (rndPosX, rndPosY, 0);
		create.SetActive (true);
	}
}
