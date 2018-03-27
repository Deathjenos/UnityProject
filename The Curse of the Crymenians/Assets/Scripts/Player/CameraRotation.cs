using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour {

	public float Y = 0.0f;
	public float AngleSpreadY = 90.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		CameraRotate ();
	}

	void CameraRotate(){
		 
		Vector3 Mouse = Camera.main.ScreenToViewportPoint (Input.mousePosition);

		if (Mouse.y > 0.5f && Mouse.y <= 1.0f) {
			Y = 0.0f + (-1 * ((Mouse.y - 0.5f) * (AngleSpreadY * 2)));
		} 
		else if (Mouse.y < 0.5f && Mouse.y >= 0.0f) {
			Y = -1 * ((Mouse.y - 0.5f) * (AngleSpreadY * 2));
		} 
		else if (Mouse.y == 0.5f) {
			Y = 0.0f;
		}
			
		transform.localEulerAngles = new Vector3 (Y, 0, 0);

	}

}//CLASS
