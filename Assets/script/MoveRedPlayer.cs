using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRedPlayer : MonoBehaviour
{

    public float moveSpeed = 5f;
    public GameObject pitchBoundary;
    public Transform destination;
    private UnityEngine.AI.NavMeshAgent agent;
    public Animator animator;
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        if (destination != null) {
            agent.SetDestination(destination.position);
        }
        //caraecter is moving
        if (agent.velocity.magnitude > 0.1f)
        {
            animator.SetBool("ismovingjerry", true);
        }
        else
        {
            animator.SetBool("ismovingjerry", false);
        }
        
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == pitchBoundary)
        {
            // If player collides with the pitch boundary, reset its position to (0, 0, 0)
            gameObject.transform.position = new Vector3(4f, 0.5f, 3f);
        }
    }
}

