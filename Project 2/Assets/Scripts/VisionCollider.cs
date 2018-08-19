using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionCollider : MonoBehaviour {

    public Light visionLight;


    // Use this for initialization
    void Start () {
        //visionLight = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
       // visionLight = GetComponent<Light>();


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {

            Vector3 pos = other.transform.position;
            Enemy s = GetComponentInParent<Enemy>();

            if (s != null)
            {
                visionLight.color = Color.red;

                s.shootRay(pos);
            }
            // Destroy(other.gameObject);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player")
        {

            Vector3 pos = other.transform.position;
            Enemy s = GetComponentInParent<Enemy>();

            if (s != null)
            {
                visionLight.color = Color.red;
                s.shootRay(pos);
            }
            // Destroy(other.gameObject);
        }

    }

  

}

