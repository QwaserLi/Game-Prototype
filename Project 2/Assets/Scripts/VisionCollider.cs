using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionCollider : MonoBehaviour {

    public Light visionLight;
    Color baseColor;

    // Use this for initialization
    void Start () {
        //visionLight = GetComponent<Light>();
        baseColor = visionLight.color;
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

                s.shootRay(pos);
            }
            // Destroy(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {

            visionLight.color = baseColor;
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
                s.shootRay(pos);
            }
            // Destroy(other.gameObject);
        }

    }

  

}

