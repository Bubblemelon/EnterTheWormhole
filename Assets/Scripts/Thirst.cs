using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thirst : MonoBehaviour {

    /// <summary>
    /// 
    /// Thirst Meter:
    /// 
    /// 1. Start () Starts with half meter full
    /// 2. waterDeplete() meter level depletes every 0.2 seconds till 0f
    /// 3. fills meter method
    ///
    /// </summary>

    // maximum thirst meter level 
    public float maxWater { get; set; }

    // current thirst meter level
    public float currentWater { get; set;  }

    
    //vairables
    bool flag = true;


    // variables for UI Player Display
    public bool waterDepleteCalled;
    public bool fillWaterCalled;


    public bool DRANK; // UI CheckList

    public bool Tdie; // cond for 3rd heart to disappear


    // reference from other scripts --- remember implement on the interface as well
    public TimeElapsed timeRef;

    public PlayerPanelDisplay PPD;

    public GameObject WarningNote;

    // Use this for initialization
    void Start ()
    {
        Tdie = false;

        DRANK = false;

        //PPD = Singleton_Service.GetSingleton<PlayerPanelDisplay>();
        // default start amount
        maxWater = 10000f;

        //start the game with half full thirst meter
        //currentWater = maxWater/2;

        //start the game with full thirst meter
        currentWater = maxWater;
    }

    // Update is called once per frame
    void Update()
    {
        waterDeplete();

        //if statement for when water level is replenished
    }


    // decreases currentWater after every frame by "decrease amount"
    void waterDeplete( )
    {

        if (currentWater > 0f)
        {
            //currentWater -= timeRef.GetComponent<TimeElapsed>().timeReduced( 0.25f );

            currentWater -= 1f;

            PPD.saved = false;

            //Debug.Log("Time.Time" + Time.time);
            //Debug.Log("currentWater Level" + currentWater);

            waterDepleteCalled = true;
        }
        else 
        {
            if (flag == true)
            {
                dying();
                
            }
            flag = false;
        }

    }

    // called by coconut script
    // refilll water level 
    public void fillWater( float amount )
    {
        //Debug.Log("Water Added!!");
        currentWater += amount;

        fillWaterCalled = true;

        DRANK = true;

        WarningNote.SetActive(false);

       //stopCoroutine(PPD.WaitRemove());
       //StopCoroutine("WaitRemove");

        PPD.saved = true;
    }

    //Dying of thirst warning
    void dying()
    {
        //Debug.Log("Died of Thirst! ");

        Tdie = true;
        PPD.removeLife();
    }
}
