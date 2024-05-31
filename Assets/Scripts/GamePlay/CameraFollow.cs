using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float followSpd;
    public Transform followTarget;

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(followTarget.position.x,followTarget.position.y,-10);
        transform.position = Vector3.Slerp(transform.position,newPos,followSpd*Time.deltaTime);    
    }
}
