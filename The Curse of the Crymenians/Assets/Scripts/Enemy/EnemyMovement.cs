using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public float speed = 0.01f;
	public float loveScore = 10f;

	private float X = 0f;
	private float Z = 0f;

	private GameObject player;
	private PlayerStats playerStats;

	private GameObject Dimension;
	private DimensionState DS;

	public GameObject Obj;

	void Awake(){
		player = GameObject.Find("Player");
		Dimension = GameObject.Find ("DimensionState");
		playerStats = player.GetComponent<PlayerStats> ();
		DS = Dimension.GetComponent<DimensionState> ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Move ();
	}

	void Move(){
		Vector3 Position = Vector3.MoveTowards (transform.position, player.transform.position, speed);
		Vector3 Rotation = Vector3.RotateTowards (transform.position, player.transform.position, (100f * Time.deltaTime), 0);
		Position.y = transform.position.y;

		transform.position = Position;
		transform.rotation = Quaternion.LookRotation (Rotation);

	}

	void OnTriggerEnter(Collider target){
		if (target.gameObject.tag == "AttackObject") {
			if (playerStats.currentLove < playerStats.Love) {
				playerStats.currentLove += loveScore;
			}
			Destroy (gameObject);
			DS.Scores++;
			Instantiate(Obj, transform.position, Quaternion.identity);
			Attack star = target.GetComponent<Attack> ();
			star.StarDead ();
		}
	}


}
