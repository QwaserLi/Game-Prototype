using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboEnemy : Enemy {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(!chasing)
            movement();
        else
        {
            chase();
        }
	}
}
