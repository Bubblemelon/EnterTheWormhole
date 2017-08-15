using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// attaches to the broken aircraft
/// 
/// </summary>

public class GetOffPlanet : MonoBehaviour {

    public GameObject CompleteShipObject;


    Sounds Noise;

	// Use this for initialization
	void Start () {

        Noise = GameObject.Find("Game Manager").GetComponent<Sounds>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {

        if( other.CompareTag("Ship Component") )
        {

            // play wing attachement sound & Electrical field noise
            Noise.RightWingAttached();


            // play the electric fog sound when above noise is done
            StartCoroutine( "ElectricFogAroundSpaceship" ); 

            Instantiate(CompleteShipObject, this.transform.position, Quaternion.identity);

            //Destroy(other.gameObject);

            other.gameObject.SetActive(false);

           
           
          
        }
        
    }

    IEnumerator ElectricFogAroundSpaceship()
    {
        // start when WingIsAttachedNoise is done playing
        yield return new WaitForSeconds( Noise.WingIsAttachedNoise.length );

        print(" HEY ELECTRIC");

        Noise.ElectricFieldCloudSound();

        //Destroy(this.gameObject);

        this.gameObject.SetActive(false);

    }

}
