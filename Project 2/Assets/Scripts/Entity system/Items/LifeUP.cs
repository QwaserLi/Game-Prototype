using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeUP : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        //When play triggers this increase play health and increase move speed
        if (other.gameObject.name == "Player" )
        {
            Player p = other.gameObject.GetComponent<Player>();
            p.lifeUP(1);
            p.changeMovespeed(1);
            Destroy(gameObject);

        }
    }
}
