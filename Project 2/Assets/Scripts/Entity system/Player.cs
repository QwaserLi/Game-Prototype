using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : Living {

    [SerializeField]
    protected int movespeed;

    private List<Items> inventory;
    public Image[] hearts;
    public Sprite heart;
    Vector3 originalPos;


    bool invincible, control;
    private Quaternion prevRotation;

    // Use this for initialization
    void Start()
    {
        inventory = new List<Items>();
        // gameObject.transform.position = startPos;
        originalPos = transform.position;
        control = true;
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        for (int i = 0; i < hearts.Length; i++) {
            if (i < health) {
                hearts[i].enabled = true;
            }
            else {
                hearts[i].enabled = false;
            }
        }
    }

    public override void movement()
    {
        if (control)
        {
            float moveHorizontal = Input.GetAxisRaw("Horizontal");
            float moveVertical = Input.GetAxisRaw("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);


            if (moveHorizontal == 0 && moveVertical == 0)
            {
                prevRotation = transform.rotation;
            }
            else
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15F);
            }
            Vector3 prevPos = transform.position;

            transform.Translate(movement * movespeed * Time.deltaTime, Space.World);
            Vector3 direction = transform.position - prevPos;

            Ray ray1 = new Ray(prevPos, direction);
            RaycastHit hit = new RaycastHit();
            bool collide = Physics.Raycast(ray1, out hit, 0.2f);
            Debug.DrawRay(prevPos, direction);

            if (collide) {
                if (hit.collider.gameObject.tag == "Wall")
                    transform.position = prevPos;

                Debug.Log(hit.collider.gameObject.name);
            }
        }

    }

    public override void Damage(int damageTaken)
    {
        if (!invincible)
        {

            health -= damageTaken;

            toggleInvulnerability();
            Invoke("toggleInvulnerability", 2);
            respawn();
            //Invoke("respawn", 1);
            //Invoke("toggleControl", 1);


        }
    }

    public void addItem(Items item) {
        inventory.Add(item);
    }

    public List<Items> getInventory() {
        return inventory;
    }

    void toggleInvulnerability()
    {
        invincible = !invincible;
    }

    void toggleControl()
    {
        control = !control;
    }

    public void changeMovespeed(int speed)
    {
        movespeed += speed;
    }

    public void respawn()
    {
        transform.position = originalPos;
    }
}
