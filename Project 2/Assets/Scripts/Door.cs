using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public Vector3 slideTowards;
    public GameObject keyWarning;
    public int DoorId;
    bool open;

	// Use this for initialization
	void Start () {
        keyWarning.SetActive(false);
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
                    Key k = (Key)i;
                    if (k.keyID == DoorId)
                    {
                        open = true;
                        return;
                    }
                }
            }
            keyWarning.SetActive(true);
            Invoke("warningOff", 3);

            // Destroy(other.gameObject);
        }
    }

    void warningOff() {
        keyWarning.SetActive(false);
    }
}
