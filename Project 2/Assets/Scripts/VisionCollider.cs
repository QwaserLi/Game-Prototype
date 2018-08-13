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

    //void OnCollisionEnter(Collision col)
    //{

    //    Debug.Log(col.gameObject.name);
    //    if (col.gameObject.name == "Player")
    //    {
    //        Vector3 pos = col.transform.position;
    //        Sight s = GetComponentInParent<Sight>();

    //        if (s != null)
    //            s.shootRay(pos);
    //    }
    //}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {

            Vector3 pos = other.transform.position;
            Sight s = GetComponentInParent<Sight>();

            if (s != null)
                s.shootRay(pos);

            // Destroy(other.gameObject);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player")
        {

            Vector3 pos = other.transform.position;
            Sight s = GetComponentInParent<Sight>();

            if (s != null)
                s.shootRay(pos);

            // Destroy(other.gameObject);
        }
    }
}

