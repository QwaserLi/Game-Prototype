using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

    public GameObject spawnPoint;

    public GameObject winLocation;

    public Player player;

    void Awake() {
    }

	// Use this for initialization
	void Start () {
        player.transform.position = spawnPoint.transform.position;

    }

    // Update is called once per frame
    void Update () {
		
	}
}
