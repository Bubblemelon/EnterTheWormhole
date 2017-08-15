using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{

    //public variables
    public int FireBurningTime;

    public float PlayerProximity;
    public AudioClip FirePitBackgroundNoise;

    public static bool AddLog; // UI CheckList

    //private variables
    bool loop = true;

    GameObject Player;
    AudioSource Asource;
    private float lowPitchRange = .75F;
    private float highPitchRange = 1.5F;

    // Use this for initialization
    void Start()
    {
        AddLog = false;

        PlayerProximity = 3f;
        FireBurningTime = 500;
        Player = GameObject.Find("MY NVRPlayer");
        Asource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        FireLife();

        if (Player)
        {

            FirePitNearBySound();
        }

    }

    // as time passess decrease fire life
    void FireLife()
    {


        // Debug.Log("HEY TIME" + Time.time);

        // every 100 seconds FireBurning Decreases
        if ((int)(Time.time) % 10 == 0)
        {
            //Debug.Log( (int)(Time.time) + "int time");

            FireBurningTime--;

            // Debug.Log(" FireBurningTime " + FireBurningTime);
        }

        switch (FireBurningTime)
        {
            case 75:
                //print("Fire is 1/3 done burning");
                // decrease fire brightness
                break;

            case 50:
                //print("Fire is Mid way out");
                //decrease fire brightness
                break;

            case 0:
               // print(" Fire Out!!! ");
                Destroy(this.gameObject);
                break;

            default:
                //print("Fire is Burning");
                break;

        }

    }

    // fire intensity decreases with time
    void firelight()
    {
        this.GetComponent<Light>().intensity -= Time.time;

    }

    // when wood is added to the fire pit
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wood"))
        {
            FireBurningTime += 100;

            this.GetComponent<Light>().intensity += 0.5f;

            Debug.Log("ADDing WOOD");

            Debug.Log(FireBurningTime + " FireBurningTime NEW");

            AddLog = true;
        }


    }

    // when player is near the firepit
    void FirePitNearBySound()
    {

        float dist = Vector3.Distance(Player.transform.position, this.transform.position);
       // print("Distance to Player: " + dist);

        if (dist < PlayerProximity && Asource.isPlaying == false)
        {

            // play shore sounds
            FirePitNoise(FirePitBackgroundNoise);

           // Debug.Log(" Fire Pit Background Noise");
        }

        if (dist >= (PlayerProximity + 1f))
        {
            // stops when player is away from shore
            Asource.Stop();

        }


    }

    // to play the sound for the fire pit
    void FirePitNoise(AudioClip clip)
    {
        Asource.clip = clip;
        Asource.loop = true;
        Asource.pitch = Random.Range(lowPitchRange, highPitchRange);
        Asource.Play();
        Asource.volume = 0.5f;

    }

}
