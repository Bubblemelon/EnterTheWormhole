using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungerFill : MonoBehaviour {

    /* hunger zero when Filler (slider) is Rect.Transform.Right = 160
     * 
     * 160 : 20,000
     *   1 : 125
     * 
     * 20,000 : 160
     * 1/125  : 1
     * 
     * 
     * 
     */

    //public bool Hunger0; // used to decrease play lives

    PlayerPanelDisplay PPD;

    float R;

    float maxR = 0.0f;
    float minR = -160.0f;

    Hunger h;

	// Use this for initialization
	void Start () {

        //R = -80f; /// start half way for fill bar
         
       R = 0; /// full bar !!!

        this.GetComponent<RectTransform>().offsetMax = new Vector2(R, 92);//right-top

        h = GameObject.Find("Game Manager").GetComponent<Hunger>();

        PPD = GameObject.Find("PlayerPanel").GetComponent<PlayerPanelDisplay>();
    }
	
	// Update is called once per frame
	void Update () {



        //  -160 <--------- R ----------> 0   
        //   minR                         maxR

        // to make sure it is within the range 
       if (R > maxR)
       {
           R = maxR;
       }

        if (R < minR)
        {
           R = minR;
       }


        hFill();
        //print(R + "R HUNGER VALUE ");


    }

    // function for increasing and decreasing the hunger bar
    void hFill()
    {
        if( R >= minR && R <= maxR )
        {

          
            if( h.FoodDepleteCalled )
            {


                // depeletes by 2 every frame  for fooddepeleted: 1.5* 1/125
                R -= (1.5f/125f);

                h.FoodDepleteCalled = false;

                //Debug.Log("HUNGER BAR");


                this.GetComponent<RectTransform>().offsetMax = new Vector2(R, 92);//right-top

                //Debug.Log( R );

            }

            
            if( h.fillFoodCalled )
            {
                

                //Hunger0 = false;

                /// 8 X 10 ^-3 * (4000) because of add amount of filled food
                R += 32f;

                h.fillFoodCalled = false;

                this.GetComponent<RectTransform>().offsetMax = new Vector2(R, 92);//right-top
            }

            
        }

        this.GetComponent<RectTransform>().offsetMax = new Vector2(R, 92);//right-top


        
    }

}
