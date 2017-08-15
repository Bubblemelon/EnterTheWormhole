using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// objects instantiated will have rigid body property
[RequireComponent(typeof(Rigidbody))]

//[RequireComponent( typeof(NVRInteractable) ) ]

public class AnimalLife : MonoBehaviour {


    // reference from other scripts --- remember implement on the interface as well
   
    public float AnimalTimeSpan; // the amount of time on the map
    public GameObject MeatPrefab;
    public GameObject BloodSpray;

  

    // UI CheckList ///////////////
    public static bool KilledAnimal; 
    int KillCounter;
    ///////////////////////////////

    //variables
    float life;
    RandomSpawn animalList;
    Sounds noise;

    
    GameObject Creature; // this gameObject
    Vector3 MeatCation;

    // Use this for initialization
    void Start () {

        

        
        
        KilledAnimal = false;
        KillCounter = 0;

        // reference to the Random Spawn's animal list 

        //animalList = this.gameObject.transform.parent.gameObject.GetComponent<RandomSpawn>();
        animalList = GameObject.Find("Spawner").transform.GetComponent<RandomSpawn>();


        health();

        noise = GameObject.Find("Game Manager").transform.GetComponent<Sounds>();
    }
	
	// Update is called once per frame
	void Update () {

        

	}

    //health of animal
    void health()
    {
        //generates a random life span value
        //AnimalTimeSpan = Random.Range(60.0f , 80.0f); 

        AnimalTimeSpan = 100f;

        //For debugging
        //life = 10f; // the amount to handle damage

        //Debug.Log( life + " life span" );

        // Animal disappears after a certain time
        //StartCoroutine(timeRef.expiration( life ));

        StartCoroutine("AnimalLifeSpan");

        

    }

    public IEnumerator AnimalLifeSpan()
    {

        yield return new WaitForSeconds( AnimalTimeSpan  );

        Destroy(this.gameObject);

        //print("ANIMALS DIES " + Time.time);

        // needs to be removed from the Animals List = using animals.Remove( this )
        animalList.animals.Remove(this.gameObject);

        animalList.AddedIncrements--;

       // Debug.Log("AddedIncrements DEcreaseddd " + animalList.AddedIncrements);

    }



    //collides with player's controller == decrease health

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Axe") )
        {
            StopCoroutine("AnimalLifeSpan");


        }

    }

    private void OnTriggerExit(Collider other)
    {
        if( other.CompareTag( "Axe" )  )

        {
            //Debug.Log(" ANIMAL KILLED ");

            noise.ChickenDieSound();

            MeatCation = new Vector3(this.gameObject.transform.position.x, 1.2f, this.gameObject.transform.position.z);

           
            KilledAnimal = true;

            //Debug.Log(" MEAT ITem?? ");

            Creature = this.gameObject;

            Destroy(Creature, 2f);

            Destroy(GetComponent<SphereCollider>());

            GameObject Blood = Instantiate(BloodSpray, this.gameObject.transform.position, Quaternion.identity);
            Blood.transform.parent = this.gameObject.transform; // make blood effect child of animal object

            Destroy(Blood, 2f);

            animalList.animals.Remove(this.gameObject);

            animalList.AddedIncrements--;

           

            // invoke only works from start() because of the time parameter
            //Invoke("MeatCreation", Time.time + 2f); 

            GameObject meat = Instantiate(MeatPrefab, MeatCation, Quaternion.identity);
        }

    }

   


}
