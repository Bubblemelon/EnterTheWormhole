using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NewtonVR;


public class Log : MonoBehaviour {

    //private variables

    TimeElapsed exp;
    Vector3 FirePitPosition;
    Quaternion LogPitRotation;
    Rigidbody rb;
    float randRotate;
    Sounds noise;
    

    //public variables

    public float logExpTime = 7000f;

	// Use this for initialization
	void Start () {

        exp = GameObject.Find("Game Manager").GetComponent<TimeElapsed>();

        noise = GameObject.Find("Game Manager").GetComponent<Sounds>();

        FirePitPosition = new Vector3();

        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {

        StartCoroutine( exp.expiration( logExpTime, this.gameObject) );
		
	}

    // add some sort of sound or effect when wood is burnt ???

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fire"))
        {
            randRotate = Random.Range(-5.0f , 5.0f);

            //Destroy(this.gameObject);

            // remove components:
            Destroy( GetComponent<BoxCollider>() );

           // Destroy( GetComponent<NVRInteractableItem>() );

            Destroy( GetComponent<ItemTouchesGround>() );

            rb.isKinematic = true;
            rb.useGravity = false;

            Debug.Log(" Log Burnt ! ");

            // set log position to fire pit:
            FirePitPosition = other.transform.position;
      
            this.transform.position = FirePitPosition;

            // set log rotation to random rotation about fire pit:
            LogPitRotation = other.transform.rotation;

            LogPitRotation.x =+ randRotate;
            LogPitRotation.y =+ randRotate;
            LogPitRotation.z =+ randRotate;

            this.transform.rotation = LogPitRotation;

            noise.LogBurningSound();

            // this log is not the child of other i.e. the fire
            this.transform.parent = other.transform;
        }
    }

}
