using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerY : MonoBehaviour
{
    public GameObject target;
    public bool canMove = true;
    float speed = 5f;
    
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (canMove)
            {
                transform.RotateAround(target.transform.position, transform.right, Input.GetAxis("Mouse Y") * -speed);
            }
           
        }
    }
}
