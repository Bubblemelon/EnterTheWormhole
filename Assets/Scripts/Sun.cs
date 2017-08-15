using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour {

    //public variables

    public float TimeFactor =1000f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        SunRotate();
		
	}

    // directional light rotation

    void SunRotate()
    {
        // rotates about the y axis:
        //transform.RotateAround(Vector3.zero, Vector3.up, 20 * Time.deltaTime);

        //Debug.Log(Time.time);

        transform.Rotate( Time.time/TimeFactor, 0, 0);
    }
}
