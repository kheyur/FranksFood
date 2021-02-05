using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerX : MonoBehaviour
{
    public GameObject target;
    public bool canMove = true;
    float speed = 5f;

    void Update()
    {
        
        if (Input.GetMouseButton(1))
        {
            if (canMove)
            {
                // Spin the camera around the target at a speed based on the mouse movement speed
                transform.RotateAround(target.transform.position, transform.up, Input.GetAxis("Mouse X") * speed);
            }
            
        }
    }
}
