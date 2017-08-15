using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirstFill : MonoBehaviour {


    /* thirst zero when Filler (slider) is Rect.Transform.Right = 160
     * 
     * 160 : 10,000
     *   1 : 62.5
     * 
     * 10,000 : 160
     * 1/62.5 : 1
     * 
     * 0.016  : 1
     * 
     * 2/125  : 1
     * 
     * 
     */


    //public bool Thirst0; // used to decrease play lives

    PlayerPanelDisplay PPD;

    float R;

    float maxR = 0.0f;
    float minR = -160.0f;

    Thirst t;

    // Use this for initialization
    void Start()
    {

        //R = -80f; /// start half way for fill bar

        R = 0f; /// full bar !!!

        this.GetComponent<RectTransform>().offsetMax = new Vector2(R, -7.595002f);//right-top

        t = GameObject.Find("Game Manager").GetComponent<Thirst>();

        PPD = GameObject.Find("PlayerPanel").GetComponent<PlayerPanelDisplay>();
    }

    // Update is called once per frame
    void Update()
    {

        //  -160 <--------- R ----------> 0   
        //   minR                         maxR

        // to make sure it is within the range 

        if ( R > maxR )
        { 
            R = maxR;
        }

        if( R < minR )
       {
            R = minR;
        }

        tFill();
       //Debug.Log(R + "Thirst R Value");

    }

    // function for increasing and decreasing the hunger bar
    void tFill()
    {
        if (R >= minR && R <= maxR)
        {

           
            if (t.waterDepleteCalled)
            {



               // Debug.Log("HEYeeeee" + PPD.TCheck);

                // 2/125f * 1
                R -= 2/125f;

                t.waterDepleteCalled = false;


                this.GetComponent<RectTransform>().offsetMax = new Vector2(R, -7.595002f);//right-top

               

            }

            
            if (t.fillWaterCalled)
            {
               // Thirst0 = false;

                // 2/125f * 2000
                R += 32f;

                t.fillWaterCalled = false;

                this.GetComponent<RectTransform>().offsetMax = new Vector2(R, -7.595002f);//right-top


            }


        }

        this.GetComponent<RectTransform>().offsetMax = new Vector2(R, -7.595002f);//right-top

 
    }



}
