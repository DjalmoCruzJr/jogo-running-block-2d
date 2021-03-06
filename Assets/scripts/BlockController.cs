using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BlockController : MonoBehaviour {
	
	private SpawnController parent;
	private PlayerController player;
	private GameController game;
	private bool isPlayerScaped;
	private float speed;
	private bool isCollisable;

	// Use this for initialization
	void Start () {
		this.isCollisable = true;
		this.isPlayerScaped = false;
		this.parent = FindObjectOfType (typeof(SpawnController)) as SpawnController;
		this.player = FindObjectOfType(typeof(PlayerController)) as PlayerController;
		this.game   = FindObjectOfType(typeof(GameController))   as GameController;
	}
	
	// Update is called once per frame
	void Update () {
		moveToForward ();
		onBlockExitScreenListener ();
		onPlayerScapeListener ();
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (this.isCollisable) {
			this.isCollisable = false;
			PlayerPrefs.SetInt("PlayerScore", this.player.Score);
			PlayerPrefs.SetInt("PlayerLevel", this.game.Level);
			Application.LoadLevel ("GameOver");
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		this.isCollisable = true;
	}

	private void moveToForward() {
		this.transform.Translate (-(this.speed * Time.deltaTime), 0 , 0);
	}

	private void onBlockExitScreenListener () {
		if (this.transform.position.x < this.parent.minWidth) {
			Destroy(this.gameObject);
		}
	}

	private void onPlayerScapeListener() {
		if (this.transform.position.x < this.player.transform.position.x && !this.isPlayerScaped) {
			this.player.Score++;
			this.audio.Play();
			this.isPlayerScaped = true;
		}
	}

	public float Speed {
		get{return this.speed;}
		set{this.speed = value;}
	}

}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   