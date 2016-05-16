using UnityEngine;
using System.Collections;

public class GameData : MonoBehaviour {

	public UnityEngine.UI.Text lastScore;
	public UnityEngine.UI.Text coin;

	// Use this for initialization
	void Start () {
		coin.text = PlayerPrefs.GetInt ("totalCoin").ToString ();
		lastScore.text = "0";
	}
	
	// Update is called once per frame
	void Update () {
		coin.text = PlayerPrefs.GetInt ("totalCoin").ToString ();
		lastScore.text = PlayerPrefs.GetInt ("lastScore").ToString ();
	}
}
