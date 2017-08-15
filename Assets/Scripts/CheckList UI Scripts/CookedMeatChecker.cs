using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookedMeatChecker : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Meat.CookedMeat == true)
        {
            Debug.Log("A piece meat cooked CHECKED");

            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);

        }

    }
}
