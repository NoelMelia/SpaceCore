using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float TurningSpeed = 100;
    Vector3 LookAtPos;
    Vector3 SmoothedLookAtPos;
    public float ForwardSpeed = 100;
    void Update()
    {
        //Look At the Mouse
        LookAtPos = Camera.main.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, 
            Input.mousePosition.y, 50));
        SmoothedLookAtPos = Vector3.Lerp(SmoothedLookAtPos, 
            LookAtPos, Time.deltaTime * 5);
        transform.LookAt(SmoothedLookAtPos);
        //Move forward (you could use a Rigidbody)
        //transform.position += transform.forward * Time.deltaTime * ForwardSpeed;
    }
}
