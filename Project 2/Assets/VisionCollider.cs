using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision col)
    {

        Debug.Log(col.gameObject.name);
        if (col.gameObject.name == "Player")
        {
            Destroy(col.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player") { 

            Destroy(other.gameObject);
        }
    }
}
