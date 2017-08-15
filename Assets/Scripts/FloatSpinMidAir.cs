using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// Spins + Floats 
/// 
/// Stops when interacted with Hand.
/// 
/// </summary>


public class FloatSpinMidAir : MonoBehaviour
{
    // publiv variables:
    public float SpinSpeed = 10f;
    public float amplitude = 0.2f;
    public float frequency = 0.5f;

    // private variables:
 
    Input_Listeners IP;
    Rigidbody rb;

    bool onHand = false;

    // Position Storage Variables
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();
    


    // Use this for initialization
    void Start()
    {
        IP = Singleton_Service.GetSingleton<Input_Listeners>();

        // Store the starting position & rotation of the object
        posOffset = transform.position;

        rb = GetComponent<Rigidbody>();


        //IP = GetComponent<Input_Listeners>(); <--- must be on the object that this script is attached to
        // should be:

        // IP = FindSceneObjectsOfType<Input_Listeners>.GetComponent<Input_Listeners>();
    }

    void Update()
    {
        // if not on hand
       
            floating();
            Spin();
        


    }

    void floating()
    {
        // Float up/down with a Sin()
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = tempPos;
    }

    void Spin()
    {
        //Rotation
        // world sapce up direction == vector.up  
        transform.Rotate(Vector3.up, SpinSpeed * Time.deltaTime);
    }

}
