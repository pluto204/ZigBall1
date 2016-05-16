using UnityEngine;
using System.Collections;
using System.Globalization;

public class BallController : MonoBehaviour {
	private Vector3[] direction = {
		new Vector3 (1, 0, 0),
		new Vector3 (0, 0, 1),
		new Vector3 (-1, 0, 0),
		new Vector3 (0, 0, -1)
	};

	private float speed = 6.0f;
	private float maxSpeed = 9.0f;
	float acceleration = 0.05f;


	int index = 0;
	int yourScore = 0;
	public bool GAME_END = false;
	public bool GAME_STARTED = false;

	public GameObject[] boardItem;
	public GameObject scoreText;
	public UnityEngine.UI.Text scoreTextBoard;
	public UnityEngine.UI.Text bestTextBoard;

	public AudioClip coinSound, turnSound, dieSound;
	public AudioSource source;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt ("soundOff") == 1) {
			this.GetComponent<AudioSource> ().volume = 0;
		} else {
			this.GetComponent<AudioSource> ().volume = 1;
		}
		PlayerPrefs.SetInt ("lastScore", 0);
		string ballColor = PlayerPrefs.GetString ("currentColor");
		this.GetComponent<Renderer> ().sharedMaterial.color = ParseHex (ballColor);
		//source = this.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (GAME_STARTED && !GAME_END) {
			speed += acceleration * Time.deltaTime;
			if (speed > maxSpeed) {
				speed = maxSpeed;
			}
//			Debug.Log (speed);
			Move ();
			if (Input.GetMouseButtonDown (0)) {
				source.PlayOneShot (turnSound);
				index = (index + 1) % 4;
				yourScore++;
				PlayerPrefs.SetInt ("lastScore", yourScore);
			}
		}
		if (this.transform.position.y < 1.33f && GAME_END == false) {
			
			source.PlayOneShot (dieSound);

			GAME_END = true;
			speed = 0;
			acceleration = 0;
			scoreText.SetActive (false);
			foreach (GameObject item in boardItem) {
				item.SetActive (true);
			}
			scoreTextBoard.text = PlayerPrefs.GetInt ("lastScore").ToString ();
			bestTextBoard.text = PlayerPrefs.GetInt ("bestScore").ToString ();
		}
		if (PlayerPrefs.GetInt ("bestScore") < yourScore) {
			PlayerPrefs.SetInt ("bestScore", yourScore);
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}
	}

	void Move(){
		this.transform.Translate (direction[index] * speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "coin") {
			source.PlayOneShot (coinSound);
			Destroy (col.gameObject);
			PlayerPrefs.SetInt ("totalCoin", PlayerPrefs.GetInt ("totalCoin") + 1);
		}
	}

	public void setStart(bool start){
		this.GAME_STARTED = start;
	}

	public Color ParseHex(string hexstring) {
		if (hexstring == "") {
			hexstring = "#000000";
		}
		if (hexstring.StartsWith("#"))
		{
			hexstring = hexstring.Substring(1);
		}

		if (hexstring.StartsWith("0x"))
		{
			hexstring = hexstring.Substring(2);
		}

		byte r = byte.Parse(hexstring.Substring(0, 2), NumberStyles.HexNumber);
		byte g = byte.Parse(hexstring.Substring(2, 2), NumberStyles.HexNumber);
		byte b = byte.Parse(hexstring.Substring(4, 2), NumberStyles.HexNumber);

		return new Color32(r, g, b, 1);
	}

}
