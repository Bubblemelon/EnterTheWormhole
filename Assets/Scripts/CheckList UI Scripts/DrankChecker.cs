using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrankChecker : MonoBehaviour {

    Thirst Thirsty;

	// Use this for initialization
	void Start () {
		
        Thirsty = GameObject.Find("Game Manager").GetComponent<Thirst>();
    }
	
	// Update is called once per frame
	void Update () {

        if (Thirsty.DRANK == true)
        {
            Debug.Log("DRINK CHECKED");

            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);

        }


    }
}
