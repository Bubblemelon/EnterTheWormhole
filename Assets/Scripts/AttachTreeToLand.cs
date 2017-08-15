using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachTreeToLand : MonoBehaviour {

    //private variables
    RandomSpawn TreeList;

    // Use this for initialization
    void Start()
    {

        TreeList = GameObject.Find("Spawner").transform.GetComponent<RandomSpawn>();

        Tele();
    }

    // Update is called once per frame
    void Update()
    {
        ///Tele();
    }

    //this is so that the plant doesn't stay in mid air when spawned randomly
    void Tele()
    {
        RaycastHit hit;


        // transform position == position of object that the scrip is attached to
        // direction of the raycast
        // hit contains information of the hit

        // if ray cast hits something
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            // if the ray cast hits collider with tag teleport
            if (hit.collider.CompareTag("Teleport") )
            {

               // Debug.Log(" Tree is now on the ground. ");

                // set the tree to the hit position
                this.transform.position = hit.point;

            }

            if( hit.collider.CompareTag("Crafting Spot") || hit.collider.CompareTag("Fire") || hit.collider.CompareTag("Food") || hit.collider.CompareTag("Ship Component"))
            {

                Destroy(this.gameObject);

                //Debug.Log(" This tree is on a tree ! ");

                TreeList.plants.Remove(this.gameObject);

                TreeList.PlantsAdded--;
            }

            if ( hit.collider.CompareTag("Tree") || hit.collider.CompareTag("Player") || hit.collider.CompareTag("Blue Rock") || hit.collider.CompareTag("Black Rock"))
            {
                Destroy(this.gameObject);

                //Debug.Log(" This tree is on a tree ! ");

                TreeList.plants.Remove(this.gameObject);

                TreeList.PlantsAdded--;

            }



        }
        else if( hit.collider )
        {
            Destroy(this.gameObject);

            //Debug.Log(" This tree is on a tree ! ");

            TreeList.plants.Remove(this.gameObject);

            TreeList.PlantsAdded--;

        }

        // ray cast doesn't hit anything
        else
        {
            Destroy(this.gameObject);

           // Debug.Log(" TREE not above land ! ");

            TreeList.plants.Remove(this.gameObject);

            TreeList.PlantsAdded--;


        }
    }
}

