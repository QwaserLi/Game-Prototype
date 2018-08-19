using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : Living {
    
    public Image[] hearts;
    public Sprite heart;
    Quaternion prevRotation;
    Vector3 originalPos;


    bool invincible;

    public void respawn() {
        transform.position = originalPos;
    }

    public override void movement()
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
        Vector3 prevLocation = transform.position;

        transform.Translate(movement * 3 * Time.deltaTime, Space.World);


    }

    public override void Damage(int damageTaken)
    {
        if (!invincible) { 

            health -= damageTaken;

            toggleInvulnerability();
            Invoke("toggleInvulnerability", 2);
         }
    }

    void toggleInvulnerability()
    {
        invincible = !invincible;
    }


    // Use this for initialization
    void Start()
    {   

        // gameObject.transform.position = startPos;
        originalPos = transform.position;
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
