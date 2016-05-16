using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public GameObject startBtn, shopBtn, soundBtn, gameName;
	public GameObject ball;
	public GameObject[] buyBtn;
	public UnityEngine.UI.Text coinText;
	public GameObject score, coin;

	public void Retry(){
		Application.LoadLevel ("Game");
	}

	public void startGame(){
		ball.GetComponent<BallController> ().setStart (true);
		startBtn.SetActive (false);
		soundBtn.SetActive (false);
		shopBtn.SetActive (false);
		gameName.SetActive (false);
		score.SetActive (true);
		coin.SetActive (true);
	}

	public void loadShop(){
		Application.LoadLevel ("Shop");
	}
		
	public void buyItem(int cost){
		int temp = PlayerPrefs.GetInt ("totalCoin");
		if (cost > PlayerPrefs.GetInt ("totalCoin")) {
			Debug.Log ("deo du tien");
		} else {
			PlayerPrefs.SetInt ("totalCoin", PlayerPrefs.GetInt ("totalCoin") - cost);
			coinText.text = PlayerPrefs.GetInt ("totalCoin").ToString ();
			int itemIndex = cost / 50 - 1;
			buyBtn [itemIndex].SetActive (false);
			PlayerPrefs.SetInt ("itemUnlock" + itemIndex, 1);
		}
	}

	public void useItem(int index){
		PlayerPrefs.SetString ("currentColor", GameColor.game_color[index]);
	}

	public void soundOff(){
		if (PlayerPrefs.GetInt ("soundOff") == 0) {
			ball.GetComponent<AudioSource> ().volume = 0;
			PlayerPrefs.SetInt ("soundOff", 1);
		} else {
			ball.GetComponent<AudioSource> ().volume = 1;
			PlayerPrefs.SetInt ("soundOff", 0);
		}
	}

	public void share(){
		Application.CaptureScreenshot ("zigball.png");
	}

	public void rate(){
		#if UNITY_ANDROID
		Application.OpenURL("market://details?id=com.hai.zigball");
		#endif
	}
}
