using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public Spawner spawner;
    public GameObject sight;

    private AudioSource shootSound;
    private Vector3 newPos;
    private Rigidbody rigidbody;

    void Start() {
        shootSound = GetComponent<AudioSource>();
        newPos = new Vector3();
        rigidbody = GetComponent<Rigidbody>();
    }
	// Update is called once per frame
	void Update () { 
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) {
            spawner.SpawnBullet(sight.transform.position);
            shootSound.Play();
        }
	}

    void FixedUpdate() {
        if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.Rotate(0, -1f, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow)) {
            transform.Rotate(0, 1f, 0);
        }

        if (Input.GetKey(KeyCode.UpArrow)) {
            rigidbody.AddForce(transform.forward * Time.fixedDeltaTime * 1000);
        } else if(Input.GetKey(KeyCode.DownArrow)) {
            rigidbody.AddForce(-transform.forward * Time.fixedDeltaTime * 1000);
        }
    }

    public void Dead() {
        shootSound.Stop();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
