using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField]Transform rightTransform,leftTransform,TempTransform;
    
   
    public float Speed;

    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 5.0f, 0);

       
          
            transform.position = Vector3.MoveTowards(transform.position, TempTransform.position, Time.deltaTime * Speed);

        if (transform.position == rightTransform.position)
        {
            TempTransform.position = leftTransform.position;
        }
        else if (transform.position == leftTransform.position)
        {
            TempTransform.position = rightTransform.position;
        }




    }


}
    