using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;

    [Header("Sheep Control Values")]
    [SerializeField]
    private float moveSpeed = 5f;
    [SerializeField]
    private float touchSensitivity = 0.005f;

    [Header("Movement Area Limit")]
    [SerializeField]
    private float minX = -2.5f;
    [SerializeField]
    private float maxX = 2.5f;

    private Touch touch;

    private void Start()
    {
        if (rb == null)
            rb = this.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Move sheep forward with constant speed
        this.transform.position += moveSpeed * Time.deltaTime * transform.forward;

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                MoveKid();
            }
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0f, 0f), 5f * Time.deltaTime);
        }
    }

    // Move sheep on touch
    private void MoveKid()
    {
        RotateKid();
        this.transform.position = new Vector3(Mathf.Clamp(transform.position.x + touch.deltaPosition.x * touchSensitivity, minX, maxX),
                    transform.position.y,
                    transform.position.z);
    }

    private void RotateKid()
    {
        if (touch.deltaPosition.x > 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 15f, 0f), 5f * Time.deltaTime);
        }
        if (touch.deltaPosition.x < 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, -15f, 0f), 5f * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
