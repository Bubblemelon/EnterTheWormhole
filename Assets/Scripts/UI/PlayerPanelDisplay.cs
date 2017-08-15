using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPanelDisplay : MonoBehaviour {

    /*
     * 
     * Shows the Player Panel when
     * a button is pressed
     * e.g. button x on the left touch control
     * 
     * Hides it when x is pressed again!
     */

 // PUBLIC
    public static PlayerPanelDisplay instance;

    public GameObject[] LifeItems;

    public GameObject WarningNote;

    public bool saved;

// Private
    int LifeIndex = 0;

    Hunger H;
    Thirst T;
    Sounds S;
    
    void Awake()

    {
        //If there currently isn't a PlayerPanelDisplay, make this the PlayerPanelDisplay. Otherwise,
        //destroy this object. We only want one Timer
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

    }

    // Use this for initialization
    void Start () {

        saved = false;

        H = GameObject.Find("Game Manager").GetComponent<Hunger>();
        T = GameObject.Find("Game Manager").GetComponent<Thirst>();
        S = GameObject.Find("Game Manager").GetComponent<Sounds>();
    }
	
	// Update is called once per frame
	

    //removes a life image from the UI panel

    public void removeLife()
    {


        if (LifeIndex < LifeItems.Length)
        { 

            LifeItems[LifeIndex].SetActive(false);

            // heart sound when it disappears
            S.HeartGoneSound();

           // Debug.Log("Life Removed");

            LifeIndex++;

            //print((H.Hdie && T.Tdie) + " cond for removelife");

            if( H.Hdie && T.Tdie )
            {

                StartCoroutine( "WaitRemove" );

            }

        }
    }
    
    // wait a while to remove life
    // play sound to similate dying !!!!!!!!!!!!

    public IEnumerator WaitRemove()
    {
        int counter = 0;

        while( !saved )
        {

            WarningNote.SetActive(true);

            yield return new WaitForSeconds(1f);


            if ( counter == 15 )
            {
                LifeItems[LifeIndex].SetActive(false);

                Debug.Log("Both Thirst & Hunger Zero == Life Removed");

                LifeIndex++;
            }

          

            counter++;

        }


    }



    void OnEnable()
    {
        Singleton_Service.RegisterSingletonInstance(this);
    }

    // when scene ends
    void OnDisable()
    {
        Singleton_Service.UnregisterSingletonInstance(this);
    }
}
