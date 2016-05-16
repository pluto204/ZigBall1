using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

	public GameObject[] ground;
	public float GROUND_X = 0;
	public float GROUND_Z = 0;

	// Use this for initialization
	void Start () {
		Instantiate (ground [Random.Range (0, 7)], new Vector3 (0, 0, 0), Quaternion.Euler(0, 180, 0));
		Instantiate (ground [Random.Range (0, 7)], new Vector3 (21, 0, 15), Quaternion.Euler(0, 180, 0));
		Instantiate (ground [Random.Range (0, 7)], new Vector3 (42, 0, 30), Quaternion.Euler(0, 180, 0));
		Instantiate (ground [Random.Range (0, 7)], new Vector3 (63, 0, 45), Quaternion.Euler(0, 180, 0));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "ground") {
			Vector3 colPos = col.gameObject.transform.position;
			Vector3 newPos = new Vector3 (GROUND_X + 84.0f, 0, GROUND_Z + 60.0f);
			GROUND_X += 21;
			GROUND_Z += 15;
			Destroy (col.gameObject);
			Instantiate (ground [Random.Range (0, 7)], newPos, Quaternion.Euler(0, 180, 0));
		}
	}
}
