using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachFiretoLand : MonoBehaviour {

    //private variables
    Vector3 FirepitPoint;


    // Use this for initialization
    void Start()
    {

      

        Tele();
    }

    // Update is called once per frame
    void Update()
    {
      
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
               // Debug.Log(" Fire hits ground???");
              
                FirepitPoint = hit.point;

                FirepitPoint.y += 0.50f;

                // set the tree to the hit position
                this.transform.position = FirepitPoint;

            }

            if (hit.collider.CompareTag("Crafting Spot") || hit.collider.CompareTag("Fire"))
            {

                //Destroy(this.gameObject);

                FirepitPoint = hit.point;

                FirepitPoint.y += 0.50f;
                FirepitPoint.x += 20f;

                // set the tree to the hit position
                this.transform.position = FirepitPoint;


            }

            if (hit.collider.CompareTag("Tree") || hit.collider.CompareTag("Player"))
            {
                //Destroy(this.gameObject);
                FirepitPoint = hit.point;

                FirepitPoint.y += 0.50f;
                FirepitPoint.x += 20f;

                // set the tree to the hit position
                this.transform.position = FirepitPoint;


            }



        }
        // if it hits anything else except for the ones mentioned above
        else if (hit.collider)
        {
            Destroy(this.gameObject);

          

      

        }

        // ray cast doesn't hit anything
        else
        {
            Destroy(this.gameObject);

            

         

        }
    }
}
