using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothingSpd;
    public Vector3 maxPosition;
    public Vector3 minPosition;

    public void Start()
    {

    }

    public void LateUpdate()
    {
        Vector3 targetPosittion = new Vector3(target.position.x, target.position.y, transform.position.z);

        targetPosittion.x = Mathf.Clamp(targetPosittion.x, minPosition.x, maxPosition.x);

        targetPosittion.y = Mathf.Clamp(targetPosittion.y, minPosition.y, maxPosition.y);

        transform.position = Vector3.Lerp(transform.position, targetPosittion, smoothingSpd);
    }
}
