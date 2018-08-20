using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public Vector3 slideTowards;
    bool open;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (open) {
            float step = 2 * Time.deltaTime;
            // Move our position a step closer to the target.
            transform.position = Vector3.MoveTowards(transform.position, slideTowards, step);
        }
        if(transform.position == slideTowards)
            Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Player p = other.gameObject.GetComponent<Player>();

            foreach (Items i in p.getInventory()) {
                if (i.GetType() == typeof(Key)) {
                    open = true;
                }
            }

            // Destroy(other.gameObject);
        }
    }
}
