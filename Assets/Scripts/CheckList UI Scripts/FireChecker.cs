using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireChecker : MonoBehaviour {

    // FIRE is a global variable of BlueFireSpark

	// Use this for initialization
	void Start () {
		
        //Fire = GameObject.FindWithTag("Blue Rock").transform.GetComponent<BlueFireSpark>();
    }
	
	// Update is called once per frame
	void Update () {

        if (BlueFireSpark.FIRE == true)
        {
            //Debug.Log("Made Fire CHECKED");

            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);

        }


    }
}
