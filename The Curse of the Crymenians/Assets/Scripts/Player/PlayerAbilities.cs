using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour {

	public GameObject attackObject;

	public GameObject Player;
	private PlayerStats PS;

	public GameObject Dimension;
	private DimensionState DS;

	public float StarPower = 40f;
	public float StarPowerTime = 10f;

	private AudioSource AS;
	public AudioClip StovaMi;
	public AudioClip BorASka;
	public AudioClip VaiMa;

	void Awake(){
		PS = Player.GetComponent<PlayerStats> ();
		DS = Dimension.GetComponent<DimensionState> ();
		AS = GetComponent<AudioSource> (); 
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (PS.currentHP > 0) {
			Autoattack ();
			LoveAttack ();
			DivinityAttack ();
		}
	}

	void Autoattack(){
		if (Input.GetMouseButtonDown(0)) {
			Instantiate (attackObject, transform.position, Quaternion.identity);
			AS.PlayOneShot (VaiMa, 0.5f);
		}
	}

	void LoveAttack(){
		if (PS.currentLove == PS.Love && Input.GetKey(KeyCode.Alpha1)) {
			PS.currentHP = PS.HP;
			PS.currentLove = 0;
			AS.PlayOneShot (StovaMi, 1f);
		}
	}

	void DivinityAttack(){
		if (PS.currentDivinity >= StarPower && Input.GetKeyDown (KeyCode.Alpha2)) {
			DS.BigStar = true;
			PS.currentDivinity -= StarPower;
			AS.PlayOneShot (BorASka, 1f);
			StartCoroutine (StarPowerTimer ());
		}
	}

	IEnumerator StarPowerTimer(){
		yield return new WaitForSeconds (StarPowerTime);
		DS.BigStar = false;
	}

}//CLASS
