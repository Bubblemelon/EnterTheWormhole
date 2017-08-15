using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunger : MonoBehaviour
{

    /// <summary>
    /// 
    /// Hunger Meter:
    /// 
    /// 1. Start () Starts with half meter full
    /// 2. FoodDeplete() meter level depletes every 0.2 seconds till 0f
    /// 3. fills meter method
    ///
    /// </summary>

    // maximum hunger meter level 
    public float maxFood { get; set; }

    // current hunger meter level
    public float currentFood { get; set; }


    //vairables
    bool flag = true;

    // variables for UI Player Display
    public bool FoodDepleteCalled;
    public bool fillFoodCalled;

    public GameObject WarningNote;

    public PlayerPanelDisplay PPD;

    public bool ATE; // UI CheckList

    public bool Hdie; // cond for 3rd heart to disappear

    // reference from other scripts --- remember implement on the interface as well
    public TimeElapsed timeRef;


    // Use this for initialization
    void Start()
    {
        ATE = false;

        Hdie = false;

        // PPD = Singleton_Service.GetSingleton<PlayerPanelDisplay>();

        // default start amount
        maxFood = 20000f;

        //start the game with half full thirst meter
        //currentFood = maxFood/2;

        //start the game full thirst meter
        currentFood = maxFood;
    }

    // Update is called once per frame
    void Update()
    {
        FoodDeplete();

        //if statement for when Food level is replenished
    }


    // decreases currentWater after every frame by "decrease amount"
    void FoodDeplete()
    {

        if (currentFood > 0f)
        {
            //currentFood -= timeRef.GetComponent<TimeElapsed>().timeReduced( 0.15f );

            currentFood -= 1.5f;

            PPD.saved = false;
            //Debug.Log("Time.Time" + Time.time);
            //Debug.Log("currentFood Level" + currentFood);

            FoodDepleteCalled = true;
        }
        else
        {
            // this is so that the debug log dying is shown once
            if (flag == true)
            {
                dying();

            }
            flag = false;
        }

    }

    // refilll water level 
    public void fillFood(float amount)
    {
        //Debug.Log("FOOOOODD Added!!");
        currentFood += amount;

        fillFoodCalled = true;

        ATE = true;



        WarningNote.SetActive(false);

        
        //StopCoroutine( "WaitRemove"); // does this work ???????????

        PPD.saved = true;
    }

    //Dying of thirst warning
    void dying()
    {
        //Debug.Log("Died of Hunger! ");
        Hdie = true;
        PPD.removeLife();
    }
}
