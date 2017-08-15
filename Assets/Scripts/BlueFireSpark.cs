using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueFireSpark : MonoBehaviour {

    //private
    GameObject sparks;
    GameObject Player;
    Vector3 FirepitPosition;
    GameObject blackrock;
    Sounds Noise;
    AudioSource Asource;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;

    //public
    public float TimeForRockToBecomeFire;
    public float DistanceOfFirepitInforntOfPlayer;
    public GameObject FirepitPrefab;
    public AudioClip SparkNoise;
   

    // public static == static public
    // this is a global variable 
    // does not belong to one particular object
    public static bool FIRE; // UI CheckList

    private void Awake()
    {
        TimeForRockToBecomeFire = 5f;
        DistanceOfFirepitInforntOfPlayer = 2.5f;
    }

    // Use this for initialization
    void Start () {

        Noise = GameObject.Find("Game Manager").GetComponent<Sounds>();
        Asource = GetComponent<AudioSource>();

        FIRE = false;

        // child of blue rock
        sparks = this.gameObject.transform.GetChild(0).gameObject;

        sparks.SetActive(false);

        Player = GameObject.Find("MY NVRPlayer");

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    
    private void OnTriggerEnter(Collider other)
    {
        // when collide with with Black rock
        if ( other.CompareTag("Black Rock") )
        {
            // start the spark effects of blue rock
            sparks.SetActive(true);

            // start the spark effects of black rock
            other.gameObject.transform.GetChild(0).gameObject.SetActive(true);

            // randomw volume for spark sound
            float vol = Random.Range(volLowRange, volHighRange);

            //play spark sound
            Asource.PlayOneShot(SparkNoise, vol);
  
            StartCoroutine(RockToFire());

            // put other into the blackrock container
            blackrock = other.gameObject;
        }

   
    }

    // makes the firepit!!!!
    IEnumerator RockToFire()
    {

        yield return new WaitForSeconds(TimeForRockToBecomeFire);

        // turn off blue rock
        this.gameObject.SetActive( false );

        // turn off black rock
        blackrock.gameObject.SetActive(false);

        FirepitPosition = Player.transform.position;

        // add distance infornt of player
        FirepitPosition.z += DistanceOfFirepitInforntOfPlayer;

        // set it high in ground so that the "attach fire to land script" can attach it closer to the ground
        FirepitPosition.y += 20f;

        //stop spark sound
        Asource.Stop();

        // instatiate the fire pit infornt of the player.
        Instantiate(FirepitPrefab, FirepitPosition, Quaternion.identity);

        // play fire made sound
        Noise.FireIsCreatedSound();

        FIRE = true;


        //destroy blue rock and will stop sparks
        Destroy(this.gameObject);

        // destroy black rock and will stop sparks
        Destroy(blackrock.gameObject);

    }
}
