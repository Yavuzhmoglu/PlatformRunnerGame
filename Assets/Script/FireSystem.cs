using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSystem : MonoBehaviour
{

    public Transform Zone;
    public GameObject Efect;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {    
            GameObject b= Instantiate(Efect, other.transform.position, Quaternion.identity);
            other.GetComponent<Transform>().position = Zone.position;
           

             Destroy(b, 3.0f);
            Destroy(gameObject,2.0f);
           
        }
        if (other.tag == "Player")
        {
            GameObject b = Instantiate(Efect, other.transform.position, Quaternion.identity);
            other.GetComponent<Transform>().position = Zone.position;


            Destroy(b, 3.0f);
            Destroy(gameObject, 2.0f);

        }
    }
}
