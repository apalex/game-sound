using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour
{
    public Transform player;  
    public float smoothSpeed = 0.125f;  
    public Vector3 offset;  

    void Start()
    {
        if (offset == Vector3.zero)
        {
            offset = new Vector3(0, 0, -50);  
        }
    }

    void LateUpdate()
    {
        Vector3 desiredPosition = player.position + offset;

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;
    }
}
