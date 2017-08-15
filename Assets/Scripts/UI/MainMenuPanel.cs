using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuPanel : MonoBehaviour {

    float increment;

	// Use this for initialization
	void Start () {

        increment = 0f;
	}
	
	// Update is called once per frame
	void Update () {

        RectRotate();
	}


    //Rotates the image on the Main Menu
    void RectRotate( )
    {

        this.GetComponent<RectTransform>().rotation = Quaternion.Euler( 0f, 0f, increment);

        increment++;



    }
}
