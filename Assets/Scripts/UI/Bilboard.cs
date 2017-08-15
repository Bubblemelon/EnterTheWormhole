using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bilboard : MonoBehaviour {

    // makes player panel face the player

    public GameObject head;

    Vector3 UIFace;
    Input_Listeners IPL;

    // Use this for initialization
    void Start () {

       
    }
	
	// Update is called once per frame
	void Update () {

        // keeps the panel facing the player's head
        transform.LookAt(head.transform);
        transform.Rotate(0,180, 0);

	}


}
