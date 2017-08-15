using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTouchesGround : MonoBehaviour {

    Vector3 Newpoint;


    Rigidbody rb;

    public float HeightAboveGround;

	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody>();

        HeightAboveGround = 1.5f;
	}
	
	// Update is called once per frame
	void Update () {
		

	}

    // when item falls through the ground
    private void OnTriggerEnter(Collider other)
    {
        if( other.CompareTag("Teleport") )
         {
            this.transform.position = new Vector3(this.transform.position.x, 5f, this.transform.position.z);

            MoveAboveGround();
        }
    }

    // ray cast to set item above the ground
    void MoveAboveGround()
    {
        RaycastHit hit;


        // transform position == position of object that the scrip is attached to
        // direction of the raycast
        // hit contains information of the hit

        // if ray cast hits something
        if ( Physics.Raycast(transform.position, Vector3.down, out hit) || Physics.Raycast(transform.position, Vector3.up, out hit) || Physics.Raycast(transform.position, Vector3.right, out hit) || Physics.Raycast(transform.position, Vector3.left, out hit) )
        {
            // if the ray cast hits collider with tag teleport
            if (hit.collider.CompareTag("Teleport"))
            {
                rb.isKinematic = true;
                rb.useGravity = false;

                Newpoint = hit.point;

               // Debug.Log("Ray cast teleport!!! ");

                // set the tree to the hit position
                this.transform.position = new Vector3( Newpoint.x, Newpoint.y + HeightAboveGround, Newpoint.z );


            }


        }
        // ray cast doesn't hit anything
        else
        {
            Destroy(this.gameObject);

            // item is off the island or playable surface


        }
    }

}
