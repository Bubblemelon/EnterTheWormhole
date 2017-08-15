using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienChickenConvo : MonoBehaviour {

    Sounds noise;
   
	// Use this for initialization
	void Start () {

        noise = GameObject.Find("Game Manager").transform.GetComponent<Sounds>();

        Invoke( "ChickenConvo", Random.Range( 30f,50f) );

    }
	
	// Update is called once per frame
	void Update () {

        
		
	}

    // chicken conversations from the sound scripts
    void ChickenConvo()
    {
        float randomTimeRange = Random.Range(50f, 80f);

        noise.AlienChickenSounds();

        // invokes the fuction at a randome time range
        Invoke("ChickenConvo", randomTimeRange);
    }


}
