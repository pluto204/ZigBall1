using UnityEngine;
using System.Collections;

public class Splash : MonoBehaviour {
	float timeLeft = 3.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;
		if (timeLeft < 0) {
			Application.LoadLevel ("Game");
		}
	}
}
