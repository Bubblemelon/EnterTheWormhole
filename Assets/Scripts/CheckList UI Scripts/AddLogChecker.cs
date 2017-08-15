using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddLogChecker : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Fire.AddLog == true)
        {
            Debug.Log("Log Added CHECKED");

            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);

        }

    }
}
