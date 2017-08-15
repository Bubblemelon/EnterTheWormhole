using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  
/// defines an axe as a tool with the following properties
///  
/// </summary>

// requires Interactable item from NewtonVRs

public class Axe : MonoBehaviour
{

    public int AxeUses = 100;

    public bool RHand = false;
    public bool LHand = false;

    public SteamVR_TrackedObject trackedObj;


    //private variabels

    Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        AxeDestroy();

      

    }

    // number of uses decreases with each use of the axe on a tree
    void decreaseUse()
    {
        AxeUses -= 2;

    }
    // destroys the axe object when number of axe uses is 0

    // play sound when axe is destroyed ???
    void AxeDestroy()
    {
        if (AxeUses == 0)
        {
            Debug.Log("AXE Destoyed");
            Destroy(this.gameObject);
        }

    }

    // Other means == the thing that collides with the axe
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tree") || other.CompareTag("Animal") )
        {
            decreaseUse();

           // Debug.Log("WEAR on AXE!!!");
        }

        //left hand collision with axe
        if (other.CompareTag("Left Hand"))
        {
            trackedObj = other.gameObject.GetComponent<SteamVR_TrackedObject>();
           // Debug.Log("LEFT Hand");


        }

        //right hand collision with axe
        if (other.CompareTag("Right Hand"))
        {
            trackedObj = other.gameObject.GetComponent<SteamVR_TrackedObject>();
            RHand = true;

           
        }
    }

}
