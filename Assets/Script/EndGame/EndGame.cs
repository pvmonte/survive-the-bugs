using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {
	public Transform helicopter;
	public float scale;


	// Use this for initialization
	void Start () {
		scale = 1;
	}
	
	// Update is called once per frame
	void Update () {
		helicopter.localScale = new Vector2 (scale, scale);
		helicopter.Translate (2 * Time.deltaTime, 0, 0);

		if (scale > 0f) {
			scale -= Time.deltaTime / 6;
		}
	}
}
