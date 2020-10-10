using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform Target;
    float DeltaZ;
    float DeltaX;

    void Start()
    {
        

        DeltaZ = transform.position.z - Target.position.z;
        DeltaX = transform.position.x - Target.position.x;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Target.position.x+DeltaX, transform.position.y, Target.position.z + DeltaZ);

    }
    public void SetTarget(Transform newTarget)
    {
        Target = newTarget;


    }
}
