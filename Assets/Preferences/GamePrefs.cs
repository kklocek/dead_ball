using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePrefs : MonoBehaviour {

    public GameSettings gs;
    public Player player;

    private AudioSource deadSound;

    void Awake() {
        if(gs == null) {
            gs = ScriptableObject.CreateInstance<GameSettings>();
        }
        deadSound = GetComponent<AudioSource>();
    }

    void Start() {
        if (player == null) {
            player = GameObject.Find("Player").GetComponent<Player>();
        }
    }
	
	public void AddPoint() {
        gs.points++;
    }

    public void KillPlayer() {
        gs.lives--;
        if(gs.lives <= 0) {
            deadSound.Play();
            player.Dead();
        }
    }
}
