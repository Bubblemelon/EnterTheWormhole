using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSoundsIfPlayerNear : MonoBehaviour {

    public GameObject Player;
    public float PlayerProximity;

    public AudioClip ShoreNoise;

    AudioSource Asource;

    // Use this for initialization
    void Start () {

        PlayerProximity = 25f;

        Asource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

        //if ((Player.transform.position - this.transform.position).sqrMagnitude < PlayerProximity )
        //{
        //    // the player is within a radius of 3 units to this game object

        //    Debug.Log(" CLOSE TO THE WATER !!!!!!!!!!");

        //}

        if ( Player )
        {
            float dist = Vector3.Distance(Player.transform.position, this.transform.position);
           // print("Distance to Player: " + dist);

            if( dist < PlayerProximity && Asource.isPlaying == false)
            {

                // play shore sounds
                ShoreSound(ShoreNoise);

                //Debug.Log(" SHORE SOUNDS");
            }

            if( dist >= (PlayerProximity + 10f) )
            {
                // stops when player is away from shore
                Asource.Stop();

            }
            
        }

    }

    void ShoreSound(AudioClip clip)
    {
        Asource.clip = clip;
       // Asource.loop = true;
        Asource.Play();
        Asource.volume = 0.1f;

    }



}
