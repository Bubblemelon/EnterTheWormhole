using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Spawns animals in an array at random locations
 * as a child of killable
 * 
 * 
 */
 
public class RandomSpawn : MonoBehaviour {


    //a set of prefab animals to instantiate:
    public GameObject[] AnimalsArray;

    //a set of prefab Plants to instantiate:
    public GameObject[] PlantsArray;

    // a set of prefab rocks to instantiate:
    public GameObject[] RocksArray;

    //the dynamic list of animals 
    [HideInInspector] public List<GameObject> animals;

    //the dynamic list of plants 
    [HideInInspector] public List<GameObject> plants;

    //the dynamic list of rocks
    [HideInInspector] public List<GameObject> rocks;

    //number of animals instatiated on the map
    public int AnimalPopulationLimit;

    //number of plants instantiated on the map
    public int PlantPopulationLimit;

    // number of rocks instantiated on the map
    public int NumberOfRocksOnMap;

    //should be decreased each time an animal is destroyed/dies
    public int AddedIncrements = 0;

    //number of plants added
    public int PlantsAdded = 0;

    //number of rocks added
    public int RocksAdded = 0;

    //variable for random location
    float r;

    // random tree variable location
    float F;

    //spawn location variable
    Transform spawn;
    Vector3 RandPostion;


    // plants and animals declarations
    GameObject newPlant;

    GameObject newAnimal;

    GameObject newRock;

    // Use this for initialization
    void Start() {



        //Instantiate( Resources.Load("Assets/MyPrefabs/Pear"), RandPostion, Quaternion.identity ) as GameObject; 


        // Debug.Log("Random Positions" + getRandPosition());

        //instantiated the both arrays on the interface

       


    }

    // Update is called once per frame
    void Update() {

        

        // instantiates a random list of animals at a random location
        AnimalList();

        PlantList();

        RockList();
    }

    //random location of gameobject spawning relative to spawn location:
    private void RandLocation()
    {
        r = Random.Range(-20.0f, 20.0f);

        // set the spawn location ( configured on the interface ) 
        spawn = GameObject.FindGameObjectWithTag("SpawnL").transform;


        RandPostion = new Vector3(spawn.transform.position.x + r, spawn.transform.position.y, spawn.transform.position.z + (-r) );

    }
    // access RandPosition
    public Vector3 getRandPosition()
    {
        return RandPostion;

    }

    // adds prefab animals onto the list and then instatiates them 
    void AnimalList()
    {

        //instatiated the dynamic array using a List from interface

        //the number of animals added onto the list does not excess the public animal population limit
        while (AddedIncrements < AnimalPopulationLimit)
        {
            //generates a random index for the animals array 
            int RandAIndex = Random.Range(0, AnimalsArray.Length);

            //generate random location
            RandLocation();

            //Debug.Log(RandAIndex + "Random Index Number");

            // as a child of Killable ( NO ! -- attaching random movement to animal prefabs)
            //GameObject newAnimal = Instantiate(AnimalsArray[RandAIndex], RandPostion, Quaternion.identity, this.gameObject.transform); 

            newAnimal = Instantiate(AnimalsArray[RandAIndex], RandPostion, Quaternion.identity); 

            animals.Add(newAnimal);

            //Debug.Log(newAnimal);

            //Debug.Log("AddedIncrements B4" + AddedIncrements);

            AddedIncrements++;

            //Debug.Log("AddedIncrements After !!!" + AddedIncrements);
        }

       
    }
    // adds prefab plants onto the list and then instatiates them 
    void PlantList()
    {

        //instatiate the dynamic array using a List from interface

        //the number of animals added onto the list does not excess the public animal population limit
        while (PlantsAdded < PlantPopulationLimit)
        {
            //generates a random index for the animals array 
            int RandPIndex = Random.Range(0, PlantsArray.Length);

            //generate random location
            //RandLocation();

            //Debug.Log(RandPIndex + "Random PLANT Index Number");
            r = Random.Range(-20.0f, 20.0f);

            F = Random.Range(-30f, 30f);

            Vector3 TreeCation = new Vector3(spawn.transform.position.x + (r * 2f), 2.32f, spawn.transform.position.z + F );

            //not a child of killable
            newPlant = Instantiate(PlantsArray[RandPIndex], TreeCation, Quaternion.identity);

            newPlant.transform.rotation = Quaternion.AngleAxis(r*10f, Vector3.up);

            animals.Add(newPlant);

           // Debug.Log(newPlant);

            //Debug.Log("PlantsAdded B4" + PlantsAdded);

            PlantsAdded++;

            //Debug.Log("PlantsAdded After !!!" + PlantsAdded);
        }


    }

    void RockList()
    {
        //instatiated the dynamic array using a List from interface

        //the number of animals added onto the list does not excess the public animal population limit
        while (RocksAdded < NumberOfRocksOnMap)
        {
            //generates a random index for the animals array 
            int RandRIndex = Random.Range(0, RocksArray.Length);

            //Debug.Log(RandPIndex + "Random PLANT Index Number");
            r = Random.Range(-20.0f, 20.0f);

            float b = Random.Range(-10.0f, 30.0f);

            Vector3 RockCation = new Vector3(spawn.transform.position.x + (-r * 1.5f), 0.25f, spawn.transform.position.z + b);

            //not a child of killable
            newRock = Instantiate(RocksArray[RandRIndex], RockCation, Quaternion.identity);

            newRock.transform.rotation = Quaternion.AngleAxis(r * 8f, Vector3.up);

            rocks.Add(newPlant);

            // Debug.Log(newPlant);

            //Debug.Log("PlantsAdded B4" + PlantsAdded);

            RocksAdded++;

            //Debug.Log("Plant
        }


    }



}
