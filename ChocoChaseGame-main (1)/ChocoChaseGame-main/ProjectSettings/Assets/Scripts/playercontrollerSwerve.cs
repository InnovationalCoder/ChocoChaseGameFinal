using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontrollerSwerve : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardspeed;
    public float forceSize;
    public Animator anim;
    public AudioSource victory;
    public AudioSource topple;
    
    // private Rigidbody rigidbody;



    void Start()
    {
        controller = GetComponent<CharacterController>();
      //  rigidbody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        direction.z = forwardspeed;
    }
    private void FixedUpdate()
    {
        controller.Move(direction * Time.fixedDeltaTime);
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("HaltWall"))
        {
            //Time.timeScale = 0f;
            Destroy(other.gameObject);

            forwardspeed = 0;
            victory.Play();
            won();



        }
        else if  (other.gameObject.CompareTag("fall"))
            {
            Debug.Log("collision detected");
            topple.Play();
        }
    }
    
    public void won()
    {
        anim.SetTrigger("Won");
    }
}
