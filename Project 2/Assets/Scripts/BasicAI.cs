using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAI : MonoBehaviour {

    Vector3 startPos;
    int dir = 1;
    bool forward = true;
	// Use this for initialization
	void Start () {
        Vector3 pos = gameObject.transform.position;


        this.startPos = pos;
        Debug.Log(startPos);
    }

    // Update is called once per frame
    void Update () {
        Vector3 pos = gameObject.transform.position;

        Debug.Log(pos);


        pos.z += (1 * Time.deltaTime) * dir;

        if (pos.z > startPos.z + 3 && forward) {
            dir = -dir;
            forward = !forward;
        }

        if (pos.z < startPos.z - 0.1 && !forward)
        {
            forward = !forward;

            dir = -dir;
        }


        gameObject.transform.position = pos;

       
    }
}
