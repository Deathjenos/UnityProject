using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour {

	public float speed = 1f;
	public float rotationSpeed = 10f;
	public float jumpHeight = 5f;
	public bool MayMove = true;

	public float PowerUpSpeed = 2f;
	public float PowerUpSpeedDuration = 1f;
	private bool HasPowerUpSpeed = false;

	private Vector3 mouseStartX;
	private float CurrentMouseX;

	public float Y;
	public float Z;
	public float X;

	private bool CursorVisible = false;

	private Rigidbody rb;

	private bool onGround = true;

	// Use this for initialization
	void Awake(){
		rb = GetComponent<Rigidbody> ();
	}

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
		CheckCursor ();
	}

	void Move(){
		if (MayMove) {

			Z = Input.GetAxisRaw ("Vertical") * speed * Time.deltaTime;
			X = Input.GetAxisRaw ("Horizontal") * speed * Time.deltaTime;
			transform.Translate (X, 0, Z);

			float xMouse = CrossPlatformInputManager.GetAxis ("Mouse X") * rotationSpeed;
			Y = transform.localEulerAngles.y + xMouse;
			transform.localEulerAngles = new Vector3 (0, Y, 0);

			if (onGround) {
				if (Input.GetKey (KeyCode.Space)) {
					rb.velocity = new Vector3 (0, jumpHeight, 0);

					onGround = false;
				}
			}
		}
	}

	void CheckCursor(){
		if (Input.GetKeyDown (KeyCode.Escape)) {
			CursorVisible = true;
		} 
		if(Input.GetMouseButtonDown(0)) {
			CursorVisible = false;
		}

		Cursor.visible = CursorVisible;
	}

	void OnCollisionEnter(Collision target){
		if (target.gameObject.tag == "Ground") {
			onGround = true;
		}
	}

	void OnTriggerEnter(Collider target){
		if (target.gameObject.tag == "PowerUpSpeed") {
			StartCoroutine (SpeedPowerUP ());
			Destroy (target.gameObject);
		}
	}

	IEnumerator SpeedPowerUP(){
		float rememberSpeed = speed;
		speed = PowerUpSpeed;
		yield return new WaitForSeconds (PowerUpSpeedDuration);
		speed = rememberSpeed;
	}

}//CLASS
