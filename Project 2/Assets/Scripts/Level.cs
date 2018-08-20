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
        if (player.getHealth() <= 0) {
              string scene = "GameOverScreen";
              Color loadToColor = Color.black;
              Initiate.Fade(scene, loadToColor, 3.0f);
              player.transform.position = new Vector3(0, -100, 0);

        }
    }
}
