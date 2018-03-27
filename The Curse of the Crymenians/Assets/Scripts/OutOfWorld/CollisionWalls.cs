using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWalls : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision target){
		if (target.gameObject.tag == "Player") {
			target.transform.position = new Vector3 (0, 0, 0);
		}
		if (target.gameObject.tag != "Player") {
			Destroy (target.gameObject);
		}
	}

	void OnTriggerEnter(Collider target){
		if (target.gameObject.tag != "Player") {
			Destroy (target.gameObject);
		}
	}

}//CLASS
