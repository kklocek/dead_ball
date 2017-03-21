using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject bullet;
    public GameObject enemy;

    private GamePrefs gamePrefs;
    // Use this for initialization
    void Start () {
        if (gamePrefs == null) {
            gamePrefs = GameObject.Find("Prefs").GetComponent<GamePrefs>();
        }
        SpawnEnemies();
	}

    public void SpawnBullet(Vector3 pos) {
        var b = Instantiate(bullet, pos, Quaternion.identity);
        pos.y = 0;
        b.GetComponent<Rigidbody>().AddForce(pos * 5000);
    }

    private void SpawnEnemies() {
        int num = gamePrefs.gs.enemiesCount;
        Vector3 pos = new Vector3();
        float angle;
        for(int i = num; i > 0; i--) {
            angle = Mathf.Deg2Rad * UnityEngine.Random.Range(0, 360f);
            pos.x = Mathf.Cos(angle) * gamePrefs.gs.radius;
            pos.z = Mathf.Sin(angle) * gamePrefs.gs.radius;
            pos.y = 0.25f;
            Instantiate(enemy, pos, Quaternion.identity);
        }
    }
}
