using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : Living {

    [SerializeField]
    private Vector3[] movepositions;

    [SerializeField]
    private int movespeed;

    [SerializeField]
    private Vector3 firstDestination;

    private int nextPos;
    private float int_HitRadiusDistance = 2000f;  

    public NavMeshAgent navMeshAgent;

    void Start() {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = movespeed;
        //navMeshAgent.updateRotation = false;

    }

    public override void Damage(int damageTaken)
    {

    }

    public override void movement()
    {
        // have to hard code height because navmesh rises the position up
        Vector3 yZero = new Vector3(transform.position.x, 0, transform.position.z);


        if (yZero == firstDestination) {
            if (nextPos + 1 >= movepositions.Length)
            {
                nextPos = 0;
            }
            else {
                nextPos++;
            }

            firstDestination = movepositions[nextPos];
        }
        //transform.rotation = Quaternion.LookRotation(navMeshAgent.velocity.normalized);

        navMeshAgent.SetDestination(firstDestination);
    }

    public void shootRay(Vector3 playerPosition)
    {
        Vector3 direction = (playerPosition - transform.position).normalized;

        Ray ray1 = new Ray(transform.position, direction);
        RaycastHit hit = new RaycastHit();
        bool collide = Physics.Raycast(ray1, out hit, int_HitRadiusDistance);
        //Debug.Log(hit.collider.gameObject.name);

        if (collide)
        {
            if (hit.collider.gameObject.name == "Player")
            {
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                //Destroy(hit.collider.gameObject);     
                Player p = hit.collider.gameObject.GetComponent<Player>();
                p.Damage(1);
                p.respawn();
            }
        }
    }

    // Use this for initialization
  
}
