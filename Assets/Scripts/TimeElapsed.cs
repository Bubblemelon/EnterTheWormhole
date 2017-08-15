using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeElapsed : MonoBehaviour {

    /*
     * Class that contains methods for manipulating time.
     * 
     * Methods need to be public inorder to be accessed:
     * 
     * timeReduced()
     * 
     * expiration()
     * 
     * TimeInDays()
     * 
     */

    /// Variables
    float timeMinused; // factored amount time reduced 

    int timeCollection;

    //public variables
    [HideInInspector] public bool exp; // expiration flag

    public int DayNum;

    FogTimer FT;

    private void Start()
    {
        DayNum = 0;

        timeCollection = 0;

        FT = GameObject.Find("Fog").GetComponent<FogTimer>();

    }

    // Update is called once per frame
    void Update()
    {
       
       

    }

    // takes time passed multiplied by a number to increase intensity
    public float timeReduced( float factor )
    {
        timeMinused = Time.time - factor;

        return timeMinused;
    }

    //expiration method
    // destroys object after a certain time in seconds
    // 60s == 1 min
    //
    // StartCoroutine( Example() );
    public IEnumerator expiration( float timeAmount, GameObject x )
    {

        //print(Time.time);

        // suspend execution for x seconds
        yield return new WaitForSeconds( timeAmount );

        Destroy( x );

       // print("Object Dies " + x + Time.time);

        exp = true;


       
    }



    // every 90 frames add 1 day
    public float timeInDays()
    {
       // Debug.Log(" timecoll b4" + timeCollection);

        timeCollection++;

        //Debug.Log(" timecoll After" + timeCollection);

        if ( timeCollection > 4000 )
        {
            timeCollection = 0;
            //Debug.Log(" timecoll ZEOR??" + timeCollection);

            //Debug.Log("TIME PASSED");

            DayNum++;

            FT.FogRollsIn();

        }

       

        return DayNum; 
    }

    // Sets time back to normal after a period of time

    public IEnumerator TimeNorm( float duration )
    {

        yield return new WaitForSeconds( duration );

        Time.timeScale = 1.0f;
    }

}
