using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public GameObject player;
    public GamePrefs gamePrefs;
    private Vector3 diff, newPos;
	// Use this for initialization
	void Start () {
		if(player == null) {
            player = GameObject.Find("Player");
        }
        if(gamePrefs == null) {
            gamePrefs = GameObject.Find("Prefs").GetComponent<GamePrefs>();
        }
	}
	
	void FixedUpdate () {
        newPos = Vector3.MoveTowards(transform.position, player.transform.position, 0.005f);
        newPos.y = transform.position.y;
        transform.position = newPos;
	}

    void OnCollisionEnter(Collision col) {
        if(col.gameObject.tag == "Bullet") {
            gamePrefs.AddPoint();
            Destroy(gameObject);
        }

        if(col.gameObject.tag == "Player") {
            gamePrefs.KillPlayer();
            Destroy(gameObject);
        }
    }
}
