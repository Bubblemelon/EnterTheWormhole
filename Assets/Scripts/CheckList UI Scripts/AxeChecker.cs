using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeChecker : MonoBehaviour {

    AxeCrafter AC;

	// Use this for initialization
	void Start () {
		
        AC = GameObject.Find("Purple Craft Spot").GetComponent<AxeCrafter>();

    }
	
	// Update is called once per frame
	void Update () {

        if (AC.MadeAxe == true)
        {
            Debug.Log("Axe Made CHECKED");

            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);

        }

    }
}
