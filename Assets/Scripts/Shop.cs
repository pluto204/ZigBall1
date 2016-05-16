using UnityEngine;
using System.Collections;

public class Shop : MonoBehaviour {
	
	public GameObject[] buyBtn;
	public UnityEngine.UI.Text coin;

	// Use this for initialization
	void Start () {
		coin.text = PlayerPrefs.GetInt ("totalCoin").ToString ();
		for (int i = 0; i < 10; i++) {
			if (PlayerPrefs.GetInt ("itemUnlock" + i) == 1) {
				buyBtn [i].SetActive (false);
			}
		}
	
	}
}
