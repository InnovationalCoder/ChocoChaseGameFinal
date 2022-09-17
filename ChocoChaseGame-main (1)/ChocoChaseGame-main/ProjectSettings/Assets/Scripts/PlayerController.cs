using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;


    
    public Swipe swipeControl;
    private Vector3 direction;
    public float forwardSpeed;
    //three options for moving.Left(1)/mid(0)/Right(2)
    private int desireLane = 1;
    public float laneDistance = 3;
    public float laneSpeed = 100;
    //win
    public Animator anim;
    void Start()
    {
        controller = GetComponent<CharacterController>();

    }



    void Update()
    {
        direction.z = forwardSpeed;

        if( (Input.GetKeyDown(KeyCode.RightArrow))|| (swipeControl.SwipeRight))
        {
            desireLane++;
            if (desireLane == 3)
            {
                desireLane = 2;
            }
        }
        if ((Input.GetKeyDown(KeyCode.LeftArrow))|| (swipeControl.SwipeLeft))
        {
            desireLane--;
            if (desireLane == -1)
            {
                desireLane = 0;
            }
        }
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (desireLane == 0)
        { targetPosition += Vector3.left * laneDistance; }
        else if (desireLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }
        transform.position = Vector3.Lerp(transform.position, targetPosition, laneSpeed * Time.deltaTime);//for smooth movement of player
                                                                                                          //  transform.positin = targetPosition;


    }
    private void FixedUpdate()
    {
        controller.Move(direction * Time.fixedDeltaTime);
    }
    public void won()
    {
        anim.SetTrigger("Won");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("HaltWall"))
        {
            //Time.timeScale = 0f;
            Destroy(other.gameObject);
            
            forwardSpeed = 0;
               won();
            


        }
    }
}
