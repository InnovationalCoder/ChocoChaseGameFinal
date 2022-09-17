using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour
{
    public float speed = 500f;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        transform.Rotate(Vector3.up , Time.deltaTime * speed);
        //break;

    }
}
