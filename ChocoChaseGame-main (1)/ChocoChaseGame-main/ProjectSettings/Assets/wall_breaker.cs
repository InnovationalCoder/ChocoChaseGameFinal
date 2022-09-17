using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall_breaker : MonoBehaviour
{
    public GameObject choco_full;
    public GameObject choco_pieces;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            choco_full.SetActive(false);
            choco_pieces.SetActive(true);
        }
    }
}
