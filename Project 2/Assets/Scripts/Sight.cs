﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sight : MonoBehaviour {
    float int_HitRadiusDistance = 2000f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
 
    }

    public void shootRay(Vector3 playerPosition) {
        Vector3 direction = (playerPosition - transform.position).normalized;

        Ray ray1 = new Ray(transform.position, direction);
        RaycastHit hit = new RaycastHit();
        bool collide = Physics.Raycast(ray1, out hit, int_HitRadiusDistance);
        //Debug.Log(hit.collider.gameObject.name);

        if (collide)
        {
            if (hit.collider.gameObject.name == "Player")
            {
                Destroy(hit.collider.gameObject);
            }
        }
    }

}