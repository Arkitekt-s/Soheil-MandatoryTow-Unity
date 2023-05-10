using Cinemachine;
using UnityEngine;

public class MoveBluePlayer : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 5f;
    
    
    public GameObject pitchBoundary;
    //shot the ball
    public GameObject ballPrefab;
    private bool hasShotBall = false;
    //destroy old ball 
    public GameObject oldBall;
    public Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && !hasShotBall)
        {
            //change old ball to new ball and make new ball a old ball
            /*can shoot ball everytime no limit*/
            animator.SetBool("isshooting", true);
            if (oldBall != null)
            {
                Destroy(oldBall);
            }
            
            // Instantiate ball object at player's position
            GameObject ball = Instantiate(ballPrefab, transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity);
            
            // Apply force to the ball in the direction the player is facing
            Rigidbody ballRb = ball.GetComponent<Rigidbody>();
            Vector3 shootDirection = transform.forward;
            ballRb.AddForce(shootDirection * 7000f);
            hasShotBall = true;
            oldBall = ball;
        }

    // Move player 1 with arrow keys and use vector3 to move the player
    if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 position = gameObject.transform.position;
            position.x -= moveSpeed * Time.deltaTime;
            gameObject.transform.position = position;
            //rotation
            Quaternion targetRotation = Quaternion.Euler(0f, -90f, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 position = gameObject.transform.position;
            position.x += moveSpeed * Time.deltaTime;
            gameObject.transform.position = position;
            //rotation
            Quaternion targetRotation = Quaternion.Euler(0f, 90f, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            
            
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            Vector3 position = gameObject.transform.position;
            position.z += moveSpeed * Time.deltaTime;
            gameObject.transform.position = position;
            Quaternion targetRotation = Quaternion.Euler(0f, 0f, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
          
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            Vector3 position = gameObject.transform.position;
            position.z -= moveSpeed * Time.deltaTime;
            gameObject.transform.position = position;
            Quaternion targetRotation = Quaternion.Euler(0f, 180f, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            
            
            
        }
        //caraecter is moving
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetBool("ismoving", true);
        }
        else
        {
            animator.SetBool("ismoving", false);
        }
        //
        if(Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("isshooting", true);
        }
        else
        {
            animator.SetBool("isshooting", false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == pitchBoundary)
        {
            // If player collides with the pitch boundary, reset its position to (0, 0, 0)
            gameObject.transform.position = new Vector3(-4f, 0.5f, 3f);
        }
    }
}



