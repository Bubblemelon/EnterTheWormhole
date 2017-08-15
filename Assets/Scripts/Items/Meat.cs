using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meat : MonoBehaviour
{
    //private variables
    Hunger hunger;
    TimeElapsed t;
    float timeAmountSlowed;
    Vector3 MeatCookPoint;
    Rigidbody rb;

    //sounds
    Sounds noise;

    AudioSource Asource;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;

    private float lowPitchRange = .75F;
    private float highPitchRange = 1.5F;

    //Public variables

    // Cooking Sound
    public AudioClip CookingFireNoise;


    public GameObject FoodPrefab;
    public int CookTime = 10;
    public float meatExpTime = 6000f;



    public static bool CookedMeat; // UI CheckList


    // Use this for initialization
    void Start()
    {
        CookedMeat = false;

        noise = GameObject.Find("Game Manager").GetComponent<Sounds>();

        hunger = GameObject.Find("Game Manager").GetComponent<Hunger>();

        t = GameObject.Find("Game Manager").GetComponent<TimeElapsed>();

        StartCoroutine(t.expiration(meatExpTime, this.gameObject)); // expires in 6000secs

        timeAmountSlowed = 15f;

        MeatCookPoint = new Vector3();

        rb = GetComponent<Rigidbody>();

        Asource = GetComponent<AudioSource>();
    }
    
    // Update is called once per frame
    void Update()
    {

    }

    // add some sort of sound or effect when wood is burnt ???

    void OnTriggerEnter(Collider other)
    {
        //if (other.CompareTag("Mouth"))
        //{

            // play sick sound

            //hunger.fillFood(100);

        //    Destroy(this.gameObject);

           

         //   Debug.Log(" Ate Raw Meat ! ");
       // }

        if (other.CompareTag("Animal"))
        {
            Destroy(this.gameObject);

            Debug.Log(" Animal collided with MEAT ! ");

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if( other.CompareTag("Fire"))
        {

            MeatCookPoint = other.transform.position;

            MeatCookPoint.y = MeatCookPoint.y + 1f;

            this.rb.isKinematic = true;
            this.rb.useGravity = false;

            this.transform.position = MeatCookPoint;
           
           // Debug.Log("COOKING MEAT!!!");
            StartCoroutine(Cooking());

        }
    }

    IEnumerator Cooking()
    {
        // start cooking sounds
        CookingSound(CookingFireNoise);

        yield return new WaitForSeconds( CookTime );

        // stop cooking sound
        Asource.Stop();

        Destroy(this.gameObject);

        Instantiate(FoodPrefab, this.transform.position, Quaternion.identity);

        CookedMeat = true;

        // start food ready sound
        noise.FoodDoneCookingSound();
    }

    void slowsTime()
    {
        Time.timeScale = 0.5f;

        // play time slowed sound

        StartCoroutine( t.TimeNorm( timeAmountSlowed ) );

    }

    // cooking sound on the fire pit

    void CookingSound( AudioClip clip )
    {
        Asource.clip = clip;
        Asource.loop = true;
        Asource.volume = Random.Range(volLowRange, volHighRange);
        Asource.pitch = Random.Range(lowPitchRange, highPitchRange);
        Asource.Play();

    }




}
