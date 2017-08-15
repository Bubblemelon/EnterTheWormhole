using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour {

    // TREEs
    public AudioClip TreeCuttingSound;
    public AudioClip TreeChoppedSound;

    // Log
    public AudioClip LogBurntNoise;

    // Animals
    // public AudioClip ChickenCut;
    public AudioClip ChickenDieNoise;
    //public AudioClip FishDieNoise;
    public AudioClip RandomAlienChickenNoise;
    //Alien Dies
    public AudioClip AlienDiesNoise;
    // Alien gets hit
    public AudioClip AlienGetsHitNoise;

    // Eating
    public AudioClip EatingNoise;

    // Drinking (straw sound)
    public AudioClip DrinkingStrawNoise;

    // Food Done Cooking
    public AudioClip CookingDoneNoise;

    //Firepit Created
    public AudioClip FirepitInstatiatedNoise;

    // Axe is made
    public AudioClip AxeInstatitedNoise;

    // SPACE SHIP !!!!
        // Right Wing Attachment
        public AudioClip WingIsAttachedNoise;
        // Electric Field Around Aircraft
        public AudioClip ElectricFieldNoise;
        // Spaceship on Idle
        // on ShipMovements.cs

    // player loose heart sound
    public AudioClip HeartGoneNoise;
    
    //PRIVATE
    AudioSource Asource;
    AudioSource ChickenSource;

    private float volLowRange = .5f;
    private float volHighRange = 1.0f;

    private float lowPitchRange = .75F;
    private float highPitchRange = 1.5F;

    private void Awake()
    {
       Asource = GetComponent<AudioSource>();
       ChickenSource = GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start () {

        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// 
    ///  Item Interactions!!!
    /// 
    /// </summary>


    // when tree is being cut
    public void TreeSounds()
    {
        Asource.clip = TreeCuttingSound;
        Asource.volume = 0.15f;
        Asource.pitch = Random.Range(lowPitchRange, highPitchRange);
        Asource.Play();

    }
    // when tree turns into a log
    public void LogSound()
    {
        float vol = Random.Range(volLowRange, volHighRange);
        Asource.PlayOneShot(TreeChoppedSound, vol);

    }

    // when coconut drops
    public void CoconutDropSound()
    {
        float vol = Random.Range(volLowRange, volHighRange);
       // Asource.PlayOneShot(TreeChoppedSound, vol);

    }

    // when blue and black rocks are touched == firepit is created
    public void FireIsCreatedSound()
    {
        Asource.clip = FirepitInstatiatedNoise;
        Asource.volume = Random.Range(volLowRange, volHighRange);
        Asource.pitch = Random.Range(lowPitchRange, highPitchRange);
        Asource.Play();
    }

    // when crafting spot is done crafting an axe
    public void AxeIsFabricated()
    {
        Asource.clip = AxeInstatitedNoise;
        Asource.volume = Random.Range(volLowRange, volHighRange);
        Asource.pitch = Random.Range(lowPitchRange, highPitchRange);
        Asource.Play();
    }


    // when the right wing is attached to the Spacecraft
    
    public void RightWingAttached()
    {

        float vol = 1.5f;
        Asource.PlayOneShot(WingIsAttachedNoise, vol);
        
    }

    // Play electric field noise around the Spaceship
    public void ElectricFieldCloudSound()
    {
        Asource.clip = ElectricFieldNoise;
        Asource.volume = 3.0f;
        Asource.Play();

    }


    /// <summary>
    /// 
    ///  ANIMAL SOUNDS
    /// 
    /// </summary>

    // when chicken dies sound  ( APPLIED TO BOTH CHICKEN AND FISH ....)
    public void ChickenDieSound()
    {
        float vol = 1.0f;
        Asource.PlayOneShot( ChickenDieNoise, vol);

    }

    // chicken conversations
    public void AlienChickenSounds()
    {

        ChickenSource.clip = RandomAlienChickenNoise;
        ChickenSource.pitch = Random.Range(lowPitchRange, highPitchRange);
        ChickenSource.volume = 0.020f;
        ChickenSource.Play();

    }

    // when Alien dies for Right Wing
    public void AlienDiesSound()
    {

        Asource.clip = AlienDiesNoise;

        Asource.Play();

    }

    // when alien is hit by the axe
    public void AlienHitSound()
    {
        Asource.clip = AlienGetsHitNoise;
        Asource.pitch = Random.Range(lowPitchRange, highPitchRange);
        Asource.volume = Random.Range(volLowRange, volHighRange);
        Asource.Play();

    }
    


    // wind sound during FOG

    // in fogtimer script


    /// <summary>
    /// 
    ///  EAT & DRINK & Food 
    /// 
    /// </summary>

    // eating Sounds
    public void EatingSound()
    {
        Asource.clip = EatingNoise;
        
        Asource.volume = Random.Range(volLowRange, volHighRange);
        Asource.pitch = Random.Range(lowPitchRange, highPitchRange);
        Asource.Play();
    }

    // drinking straw sound
    public void DrinkingStrawSound()
    {
        Asource.clip = DrinkingStrawNoise;
        Asource.volume = Random.Range(volLowRange, volHighRange);
        Asource.pitch = Random.Range(lowPitchRange, highPitchRange);
        Asource.Play();
    }

    // Food is done cooking and is ready Sound !!!

    public void FoodDoneCookingSound()
    {
        float vol =0.5f;
        Asource.PlayOneShot(CookingDoneNoise, vol);


    }

    /// <summary>
    /// 
    ///  BURNING & Cooking
    /// 
    /// </summary>

    public void LogBurningSound()
    {
        Asource.clip = LogBurntNoise;
        Asource.volume = Random.Range(volLowRange, volHighRange);
        Asource.pitch = Random.Range(lowPitchRange, highPitchRange);
        Asource.Play();

    }

    // when ship  is ready on Idle

        // in ShipMovements.cs



    //when food is cooking

    // in Meat.Cs script



    /// <summary>
    /// 
    ///  Ocean Sound (   Attached to Water Tile Object)
    /// 
    /// </summary>




    /// <summary>
    /// 
    ///  FirePit Nearby Sound ( One Fire.Cs )
    /// 
    /// </summary>


    // Player's heart decreased
    public void HeartGoneSound()
    {
        Asource.volume = 1f;
        Asource.PlayOneShot( HeartGoneNoise ) ;

    }



    // andrew's Play Audio Clip method
    public void PlaySound(AudioSource source, AudioClip clip)
    {
        source.clip = clip;
        source.pitch = Random.Range(lowPitchRange, highPitchRange);
        source.volume = Random.Range(volLowRange, volHighRange);
        source.Play();
    }

}
