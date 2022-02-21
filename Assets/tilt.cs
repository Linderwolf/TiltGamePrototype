using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tilt : MonoBehaviour
{
    public Vector3 currentRotation;
    public int rotationMaxDegrees = 350;
    public int rotationMinDegrees = 8;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // Gets the angle of the rotation at this frame
        currentRotation = GetComponent<Transform>().eulerAngles;

        if ((Input.GetAxis("Horizontal")>.2) && (currentRotation.z <= rotationMinDegrees || currentRotation.z >= rotationMaxDegrees))
        {
            transform.Rotate(0, 0, 1);
        }

        if ((Input.GetAxis("Horizontal") < -.2) && (currentRotation.z >= rotationMaxDegrees+1 || currentRotation.z <= rotationMinDegrees+1))
        {
            transform.Rotate(0, 0, -1);
        }

        if ((Input.GetAxis("Vertical") > .2) && (currentRotation.x <= rotationMinDegrees || currentRotation.x >= rotationMaxDegrees))
        {
            transform.Rotate(1, 0, 0);
        }

        if ((Input.GetAxis("Vertical") < -.2) && (currentRotation.x >= rotationMaxDegrees + 1 || currentRotation.x <= rotationMinDegrees + 1))
        {
            transform.Rotate(-1, 0, 0);
        }
    }
}
