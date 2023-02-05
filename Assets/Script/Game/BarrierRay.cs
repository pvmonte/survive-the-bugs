using UnityEngine;
using System.Collections;

public class BarrierRay : MonoBehaviour {
	public MeshRenderer materialRend;
	public float id;
	public float speed;
	public float y;

	// Use this for initialization
	void Start () {
		materialRend = GetComponent<MeshRenderer> ();
		y = id;
		InvokeRepeating ("MoveTexture", 0, 0.15f);
	}
	
	// Update is called once per frame
	void Update () {
		if (id == 0) {
			//y += speed;
		} else {
			//y -= speed;
		}
		materialRend.material.SetTextureOffset ("_MainTex", new Vector2 (0, y));
	}

	void MoveTexture(){
		y = Random.Range (0.0f, 1.0f);
	}
}
