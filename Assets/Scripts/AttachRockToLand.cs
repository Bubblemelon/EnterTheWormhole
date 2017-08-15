using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachRockToLand : MonoBehaviour {

    //private variables
    RandomSpawn RockList;
    Vector3 RockPoint;

    // Use this for initialization
    void Start()
    {

        RockList = GameObject.Find("Spawner").transform.GetComponent<RandomSpawn>();

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
            if (hit.collider.CompareTag("Teleport"))
            {

                // Debug.Log(" Tree is now on the ground. ");
                RockPoint = hit.point;

                RockPoint.y += 0.25f;

                // set the tree to the hit position
                this.transform.position = RockPoint;

            }

            if (hit.collider.CompareTag("Crafting Spot") || hit.collider.CompareTag("Fire"))
            {

                Destroy(this.gameObject);

                //Debug.Log(" This tree is on a tree ! ");

                RockList.rocks.Remove(this.gameObject);

                RockList.RocksAdded--;
            }

            if (hit.collider.CompareTag("Tree") || hit.collider.CompareTag("Player"))
            {
                Destroy(this.gameObject);

                //Debug.Log(" This tree is on a tree ! ");

                RockList.rocks.Remove(this.gameObject);

                RockList.RocksAdded--;

            }



        }
        else if (hit.collider)
        {
            Destroy(this.gameObject);

            //Debug.Log(" This tree is on a tree ! ");

            RockList.rocks.Remove(this.gameObject);

            RockList.RocksAdded--;
        }

        // ray cast doesn't hit anything
        else
        {
            Destroy(this.gameObject);

            // Debug.Log(" TREE not above land ! ");

            RockList.rocks.Remove(this.gameObject);

            RockList.RocksAdded--;

        }
    }
}
