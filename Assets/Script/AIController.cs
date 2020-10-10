using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    Rigidbody myRgb;
    Transform transformPlayer;
    Animator animator;
    public float forwardSpeed;
    PlayerController playerController;
    public Transform Zone;

    NavMeshAgent agent;
    public Transform Target;
    public int distance;

    public GameObject Bullet;
    public Transform BulletZone;
    int bullets;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        myRgb = GetComponent<Rigidbody>();
        transformPlayer = GetComponent<Transform>();
        playerController=  GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        animator = GetComponent<Animator>();

        
    }


    void Update()
    {

        RaycastHit hit;
        distance=(int)(Vector3.Distance(transform.position, Target.position));
        
        if (Physics.Raycast(transform.position, -transform.forward, out hit, 1.0f))
        {

            if (hit.collider.gameObject.tag == "Player")
            {
               
                myRgb.velocity = -Vector3.right * 0;
                myRgb.velocity = -Vector3.forward * 0; 
            

            }
        }

        if (bullets > 0)
        {

            
            GameObject b = Instantiate(Bullet, BulletZone.position, Quaternion.identity);
            bullets--;
            Rigidbody rb = b.GetComponent<Rigidbody>();

            rb.velocity = -transformPlayer.forward * 3000 * Time.deltaTime;
        

            Destroy(b, 3.0f);

        }

    }
    private void FixedUpdate()
    {

        if (playerController.GetComponent<PlayerController>().Win)
        {
            
            agent.destination = transform.position;
            animator.SetBool("Dance", true);
            animator.SetBool("Start", false);
            return;
        }
         if (playerController.isPlaying == true)
            {

            agent.destination = Target.position;
           
            agent.Move(transform.forward *0.1f);

           
            animator.SetBool("Start", true);
        } 
    }


   


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            transformPlayer.position = Zone.position;
            
        }

        if (other.tag == "finish")
        {
            agent.destination = transform.position;
            transform.Rotate(0, 180, 0);
            animator.SetBool("Dance", true);

        }
        if (other.tag == "Bulletstation")
        {
            bullets++;
            other.gameObject.SetActive(false);
        }

    }

}
