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

    //public GameObject vision;
    
    public bool chasing;

    private int nextPos;
    private float int_HitRadiusDistance = 2000f;
    protected Vector3 playerPosition;

    public NavMeshAgent navMeshAgent;

    public Light visionLight;


    void Start() {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = movespeed;
        //navMeshAgent.updateRotation = false;
    }

    public override void Damage(int damageTaken)
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player" && chasing) {
            Player p = collision.gameObject.GetComponent<Player>();
            p.Damage(1);

        }
    }

    public void chase() {
        navMeshAgent.SetDestination(firstDestination);
    }

    public void resetMovement() {
        firstDestination = movepositions[nextPos];
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
                visionLight.color = Color.red;
                chasing = true;
                firstDestination = hit.collider.gameObject.transform.position;
                
            }
        }
    }

    // Use this for initialization
  
}
