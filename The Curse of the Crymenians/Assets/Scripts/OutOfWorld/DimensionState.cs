using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DimensionState : MonoBehaviour {

	public bool BigStar = false;
	public GameObject Score;
	private UnityEngine.UI.Text ScoreText;
	public GameObject Death;
	private UnityEngine.UI.Text DeathText;

	public GameObject Player;
	private PlayerStats PS;

	public AudioClip YouDied;
	private AudioSource AS;
	private bool once = false;

	public int Scores = 0;

	void Awake(){
		ScoreText = Score.GetComponent<UnityEngine.UI.Text> ();
		DeathText = Death.GetComponent<UnityEngine.UI.Text> ();
		PS = Player.GetComponent<PlayerStats> ();
		AS = GetComponent<AudioSource> ();
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		ScoreCounter();
		DeathCounter ();
		CheckRestart ();
		Screen.fullScreen = true;
	}

	void ScoreCounter(){
		ScoreText.text = "Cursed Crymenians saved: " + Scores;
	}

	void DeathCounter(){
		if (PS.currentHP == 0) {
			if (!once) {
				AS.PlayOneShot (YouDied, 1f);
				once = true;
			}
			DeathText.text = "You Died Bitch God";
		}
	}

	void CheckRestart(){
		if(Input.GetKeyDown(KeyCode.O)){
			SceneManager.LoadScene("LevelScene");
		}
	}

}//CLASS
