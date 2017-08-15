using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovements : MonoBehaviour {

    // publiv variables:
    public float SpinSpeed = 10f;
    public float amplitude = 0.2f;
    public float frequency = 0.5f;

    public GameObject Player;
    public float PlayerProximity2Ship;

    // Position Storage Variables
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    Vector3 ShipPosition;


    // sound variables
    public AudioClip SpaceShipIdleNoise;
    AudioSource Asource;

    // Use this for initialization
    void Start () {

        PlayerProximity2Ship = 20f;

        Asource = GetComponent<AudioSource>();

        ShipPosition = new Vector3();

        // Store the starting position & rotation of the object
       

        MoveShipUp();
    }

    // Update is called once per frame
    void Update () {

        if (Player)
        {
            float dist = Vector3.Distance(Player.transform.position, this.transform.position);
            // print("Distance to Player: " + dist);

            if (dist < PlayerProximity2Ship && Asource.isPlaying == false)
            {

                // play shore sounds
                SpaceshipOnIdle(SpaceShipIdleNoise);

                Debug.Log("Ship on Idle");
            }

            if (dist >= (PlayerProximity2Ship + 10f))
            {
                // stops when player is away from shore
                Asource.Stop();

            }
        }


            floating();

    }

    // makes ship looks like it;s floating
    void floating()
    {
        // Float up/down with a Sin()
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = tempPos;
    }

    // Moves the ship upwards
    void MoveShipUp()
    {
        ShipPosition = this.gameObject.transform.position;

        for( int i = 0; i < 20; i++)
        {
            
            ShipPosition.y += 0.1f;

            this.gameObject.transform.position = ShipPosition;
        }

        posOffset = transform.position;
    }

    // idle sound function
    public void SpaceshipOnIdle( AudioClip clip)
    {
        Asource.volume = 1.0f;
        Asource.clip = clip;
        Asource.loop = true;
        Asource.Play();

    }
}
