using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour {

    private string scene = "WorkForce";
    public Color loadToColor = Color.black;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("space"))
        {
            Initiate.Fade(scene, loadToColor, 3.0f);
        }

        if (Input.GetKeyDown("n"))
        {
            Application.Quit();
        }

    }
}
