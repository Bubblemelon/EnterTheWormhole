using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoconutTree : MonoBehaviour
{

    //public variables
    public float CoconutTreeTimeSpan = 1500f; // the amount of time on the map
    public GameObject CoconutPrefab;

    //private variables
    float life; //a tree's life
    float damage;

    bool cutting = false;

    RandomSpawn TreeList;

    Sounds noise;

    // Use this for initialization
    void Start()
    {


        health();

        TreeList = GameObject.Find("Spawner").transform.GetComponent<RandomSpawn>();

        noise = GameObject.Find("Game Manager").transform.GetComponent<Sounds>();
    }

    // Update is called once per frames
    void Update()
    {

    }

    // the amount of life the tree can substain damage
    void health()
    {
        life = Random.Range(30f, 50f); //amount to handle damage

        //to debug
        //life = 10f;

        // StartCoroutine( TreeLifeSpan(life) ); THIS ONE DOES NOT LET YOU STOP 

        StartCoroutine("CoconutTreeLifeSpan");

    }


    //tree TIME span == the amount of time the tree can spend on the map
    public IEnumerator CoconutTreeLifeSpan()
    {
        //print(Time.time);

        // suspend execution for x seconds
        yield return new WaitForSeconds(CoconutTreeTimeSpan);


        Destroy(this.gameObject);

        print("TREE DIES " + Time.time);

        TreeList.plants.Remove(this.gameObject);

        TreeList.PlantsAdded--;

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Axe"))
        {

            //controll vibrations go here:

            // sound goes here:
            noise.TreeSounds();


            // Stops coroutine
            StopCoroutine("CoconutTreeLifeSpan");

            damage = life / 5f;

            life -= damage;

           // Debug.Log("Cutting");


            // decrease the time span of the time 
            CoconutTreeTimeSpan -= 5f;

            StartCoroutine("CoconutTreeLifeSpan");


            //Debug.Log("Life AMount" + life);
        }

        if (other.CompareTag("Tree"))
        {
            this.transform.position = new Vector3(this.gameObject.transform.position.x + 10f, this.gameObject.transform.position.y, this.gameObject.transform.position.z + 10f);

           // Debug.Log("TREE COLLIDING");
        }

    }
    private void OnTriggerStay(Collider other)
    {

    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log(" Trigger Exit !!! ");

        //if life == 0 then destroy tree and instantiate wood prefab and start sound
        if (life < 1.0f)
        {

            Debug.Log(" TREE CHOPPED ");

            // for logs
            // gravity off
            //is kinematic true

            Vector3 CocoCation = new Vector3(this.gameObject.transform.position.x, 1.2f, this.gameObject.transform.position.z);

            //GameObject Logs = Instantiate(Resources.Load("MyPrefabs/Log", typeof(GameObject)) as GameObject, this.gameObject.transform.position, Quaternion.identity);
            // Resources.load does not work

            GameObject GreenCoconut = Instantiate(CoconutPrefab, CocoCation, Quaternion.identity);

            Debug.Log(" Drops coconut! ");

            // log instatiate sound:
            // log instatiate sound:
            noise.LogSound();


            Destroy(this.gameObject);

            TreeList.plants.Remove(this.gameObject);

            TreeList.PlantsAdded--;

        }
    }


}
