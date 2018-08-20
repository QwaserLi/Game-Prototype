using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Items {

    public int keyID;


    public override void movement()
    {
        throw new System.NotImplementedException();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Player p = other.gameObject.GetComponent<Player>();
            p.addItem(this);
            Destroy(gameObject);

        }
    }
}
