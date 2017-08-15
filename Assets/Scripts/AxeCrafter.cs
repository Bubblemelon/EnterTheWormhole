using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeCrafter : MonoBehaviour {

    //public variables
    public float AxeCraftingTime;
    public float CraftCoolDownTime;
    public GameObject AxePrefab;

    public bool MadeAxe; // UI CheckList

    //private variable
    Vector3 NewAxePosition;
    float HeightAboveCrafter;
    

    bool checkBlue; //first rock on the collider
    bool checkBlack; // first black rock on collider

    bool craftDone;
    AxeItemCollide AIC;

    Sounds Noise;

    // Use this for initialization
    void Start () {

        Noise = GameObject.Find("Game Manager").GetComponent<Sounds>();

        MadeAxe = false;

        craftDone = false;

        checkBlue = false;
        checkBlack = false;

        AxeCraftingTime = 10f;

        HeightAboveCrafter = 1f;

        NewAxePosition = new Vector3();

        CraftCoolDownTime = 30f;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    // if two of the axe items are there

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log(" Craft STAYING !!!! ");


        //if( !craftDone )
        //{

        //    /*
        //    * FIRST rock check
        //    * 
        //    */

        //    // if first rock is blue
        //    if (other.CompareTag("Blue Rock") && !checkBlue && !checkBlack)
        //    {
        //        Debug.Log("  first rock on collider is Blue rock");

        //        checkBlue = true;


        //    }
        //    // other if first rock is black
        //    else if (other.CompareTag("Black Rock") && !checkBlue && !checkBlack)
        //    {
        //        Debug.Log("  first rock on collider is BLACK rock");

        //        checkBlack = true;

        //    }
        //    // do nothing
        //    else
        //    {

        //    }

        //    /*
        //     * second rock check
        //     * 
        //     */

        //    if (checkBlue && other.CompareTag("Black Rock"))
        //    {
        //        Debug.Log("  Second rock on collider is BLACK rock");
        //        //checkBlue = false;
        //        StartCoroutine(MakeAxe());

        //    }
        //    else if (checkBlack && other.CompareTag("Blue Rock"))
        //    {
        //        Debug.Log("  Second rock on collider is BLUE rock");
        //        //checkBlack = false;
        //        StartCoroutine(MakeAxe());


        //    }
            




        //}

    

    }
    private void OnTriggerEnter(Collider other)
    {
        CheckerFunk(other.tag, true, other);
    }
    void OnTriggerExit(Collider other)
    {
        CheckerFunk(other.tag, false, other);
    }

    void CheckerFunk(string tag, bool value, Collider other)
    {
        if (other.CompareTag("Blue Rock") || other.CompareTag("Black Rock"))
        {
            AIC = other.GetComponent<AxeItemCollide>();
            AIC.OnCraftingSpot = value;
            switch (tag)
            {
                case "Blue Rock":
                    checkBlue = value;
                        break;
                case "Black Rock":
                    checkBlack = value;
                    break;
            }
        }

        // second rock check if both blue and black has entered
        if (checkBlack && checkBlue)
        {
            StartCoroutine(MakeAxe());

            checkBlack = false;
            checkBlue = false;
        }
    }
    IEnumerator MakeAxe()
    {

        yield return new WaitForSeconds( AxeCraftingTime );

        NewAxePosition = this.gameObject.transform.position;

        Debug.Log(NewAxePosition + "NEW AXE POOS");

        NewAxePosition.y = HeightAboveCrafter + NewAxePosition.y;

        Debug.Log(NewAxePosition + "NEW AXE AFTER !!! POOS");

        Instantiate(AxePrefab, NewAxePosition , Quaternion.identity);

        //play Axe finished making sound
        Noise.AxeIsFabricated();

        MadeAxe = true;

        Debug.Log(NewAxePosition + "NEW AXE AFTER AFTER AFTER !!! POOS");


        // start the effects to show that crafting spot is unusable...

        /// start cool down
        StartCoroutine( MakeCraftDoneFalseAgain() );

    }

    // this is not used
    IEnumerator MakeCraftDoneFalseAgain()
    {
    
        yield return new WaitForSeconds( CraftCoolDownTime );

        craftDone = false;

        // show that crafting spot is usable again...
    }
}
