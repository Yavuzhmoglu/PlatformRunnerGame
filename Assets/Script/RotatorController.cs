using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorController : MonoBehaviour
{

    Rigidbody MyRb;
    public float Speed;
    void Update()
    {
        transform.Rotate(0, Speed, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            MyRb = other.GetComponent<Rigidbody>();
            MyRb.velocity = Vector3.left * Speed;
          
        }
    }

}
