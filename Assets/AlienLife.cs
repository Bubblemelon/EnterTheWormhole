using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienLife : MonoBehaviour {

    // reference from other scripts --- remember implement on the interface as well

        // when alien is nearby player variables
    public GameObject Player;
    public float PlayerProximity2Alien;
    public AudioClip Close2AlienNoise;

    AudioSource Asource;


    public GameObject DropItemPrefab;
    public GameObject BloodSpray;
    public GameObject ExplosionPrefab;

    //public GameObject ExplosionPrefab;
    // this creates more aliens after explosion

    //variables
    int life;
    Sounds noise;
    


    GameObject Creature; // this gameObject
    Vector3 ItemCation;

    // Use this for initialization
    void Start()
    {
        PlayerProximity2Alien = 20f;

        Asource = GetComponent<AudioSource>();

        life = 10;

        noise = GameObject.Find("Game Manager").transform.GetComponent<Sounds>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Player)
        {
            float dist = Vector3.Distance(Player.transform.position, this.transform.position);
            // print("Distance to Player: " + dist);

            if (dist < PlayerProximity2Alien && Asource.isPlaying == false)
            {

                // play alien is nearby sounds
                AlienAliveNClose( Close2AlienNoise );

                
            }

            if (dist >= (PlayerProximity2Alien + 10f))
            {
                // stops when player is away from shore
                Asource.Stop();

            }

        }


    }


    //collides with player's controller == decrease health

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Axe"))
        {

            life -= 2;

            // Place sound here

            // cut affect
            GameObject Blood = Instantiate(BloodSpray, this.gameObject.transform.position, Quaternion.identity);
            Blood.transform.parent = this.gameObject.transform; // make blood effect child of animal object

            Destroy(Blood, 2f);

            // play alien gets hit sound
            noise.AlienHitSound();

            if (life == 0)
            {
                ItemCation = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 0.5f , this.gameObject.transform.position.z);

                Creature = this.gameObject;

                Destroy(Creature, 2f);

                // Alien Die Sounds
                noise.AlienDiesSound();

                Destroy(GetComponent<SphereCollider>());

                GameObject Wing = Instantiate(DropItemPrefab, ItemCation, Quaternion.identity);

                GameObject Explosion = Instantiate(ExplosionPrefab, ItemCation, Quaternion.identity);
                // play sound for instantiating
            }

        }

    }

    void AlienAliveNClose(AudioClip clip)
    {
        Asource.clip = clip;
        Asource.loop = true;
        Asource.Play();
        
        // may want to have this on low volume
    }




}
