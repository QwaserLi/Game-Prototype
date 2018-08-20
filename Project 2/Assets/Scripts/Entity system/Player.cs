using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : Living {

    [SerializeField]
    protected int movespeed;


    public Image[] hearts;
    public Sprite heart;
    Vector3 originalPos;


    bool invincible, control;



    public override void movement()
    {
        if (control)
        {
            float moveHorizontal = Input.GetAxisRaw("Horizontal");
            float moveVertical = Input.GetAxisRaw("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15F);
            
            transform.Translate(movement * movespeed * Time.deltaTime, Space.World);
        }

    }

    public override void Damage(int damageTaken)
    {
        if (!invincible) { 

            health -= damageTaken;

            toggleInvulnerability();
            Invoke("toggleInvulnerability", 2);
            respawn();
            //Invoke("respawn", 1);
            //Invoke("toggleControl", 1);


        }
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

    // Use this for initialization
    void Start()
    {
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
}
