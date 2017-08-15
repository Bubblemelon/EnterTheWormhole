using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AteChecker : MonoBehaviour {

    Hunger Hungry;

	// Use this for initialization
	void Start () {

        Hungry = GameObject.Find("Game Manager").GetComponent<Hunger>();
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Hungry.ATE == true)
        {
            Debug.Log("ATE CHECKED");

            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);

        }

        
	}

    
}
