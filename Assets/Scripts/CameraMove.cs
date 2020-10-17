using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform Target;
    private Vector3 moveVector,startDistance;
    void Start()
    {
        startDistance = transform.position - Target.position;
    }

    void Update()
    {
        moveVector = Target.position + startDistance;

        moveVector.z = 0;
        moveVector.y = startDistance.y;
        
        transform.position = moveVector;
    }
}
