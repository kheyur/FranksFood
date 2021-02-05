using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject target;

    public float minFOV = 35f;
    public float maxFOV = 100f;
    float sensitivity = 17f;
    public bool canMove = true;
    //float speed = 5f;

    void Update()
    {
        if (canMove)
        {
            //Zoom
            float fov = Camera.main.fieldOfView;
            fov += Input.GetAxis("Mouse ScrollWheel") * -sensitivity;
            fov = Mathf.Clamp(fov, minFOV, maxFOV);
            Camera.main.fieldOfView = fov;
        }
      

        // Floor Traversal
        if (Input.GetKeyDown(KeyCode.W))
        {
       //   FloorUp();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
       //     FloorDown();
        }
    }

    public void FloorUp()
    {
        Vector3 position = this.transform.position;
        position.y = position.y + 30f;
        transform.position = position;
    }

    public void FloorDown()
    {
        Vector3 position = this.transform.position;
        position.y = position.y - 30f;
        transform.position = position;
        
    }
}
