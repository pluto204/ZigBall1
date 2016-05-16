using UnityEngine;
using System.Collections;
using System.Globalization;

public class CameraMove : MonoBehaviour {
	public Transform ball;
	float offsetX, offsetZ;

	// Use this for initialization
	void Start () {
		int camColorIndex = Random.Range (0, 10);
		this.GetComponent<Camera> ().backgroundColor = ParseHex (GameColor.cam_color [camColorIndex]);
		offsetX = transform.position.x - ball.position.x;
		offsetZ = transform.position.z - ball.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		if (ball != null) {
			Vector3 pos = transform.position;
			pos.x = ball.position.x + offsetX;
			pos.y = 7;
			pos.z = ball.position.z + offsetZ;
			transform.position = pos;
		};
	}

	public Color ParseHex(string hexstring) {
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
