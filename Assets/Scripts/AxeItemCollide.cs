using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeItemCollide : MonoBehaviour {

    //private variables
    AxeCrafter AC;

    Rigidbody rb;
    Vector3 AttachAboveCraftPoint;
    

    // public variables:
    public float HowFarAbove;
    public bool OnCraftingSpot;
    public float RotationSpeedFactor;

	// Use this for initialization
	void Start () {

        OnCraftingSpot = false;

        rb = GetComponent<Rigidbody>();

        

        AC =  GameObject.Find("Purple Craft Spot").GetComponent<AxeCrafter>();

        RotationSpeedFactor = 100f;

    }
	
	// Update is called once per frame
	void Update () {

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if( other.CompareTag("Crafting Spot") )
        {
            AttachAboveCraftPoint = other.transform.position;

            AttachAboveCraftPoint.y += HowFarAbove;

            rb.isKinematic = true;
            rb.useGravity = false;

            this.transform.position = AttachAboveCraftPoint;

            

            // delete the rocks in the same amount of time the axe is being made
            StartCoroutine(RockDelete());
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Crafting Spot"))
        {
            this.transform.Rotate(0, Time.time / RotationSpeedFactor, 0);
        }
       
    }



    IEnumerator RockDelete()
    {
        yield return new WaitForSeconds(AC.AxeCraftingTime);
        Destroy(this.gameObject);

    }
}
