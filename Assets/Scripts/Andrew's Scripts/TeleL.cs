using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleL : MonoBehaviour
{

    // public variables
    public GameObject Player;
    public StartButton StartB;
    public GameObject AboutPanel;
    public GameObject MenuPanel;



    // IMPORTANT NOTE:  
    //
    // because script does not run on the playerpanel when set to active(false)
    // I'm hiding it from the player's view

         public GameObject HidePlayerPanelView;

         //public GameObject OrginalPlayerPanelView; // container so that the PlayerPlanel can be seen by Player Again

    // the vector container for the UI rect
         Vector3 OriginalPlayerUIPosition;

         Vector3 HidePlayerPanelViewPostion;

    bool AtHidePostion;
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    



    public int WinningSceneIndex;

    GameObject PlayerPanelObject;
    GameObject ToDOList;

    bool state1;
    bool state2;

    // Private Vaariables
    Input_Listeners IPL;
    Vector3 newPos;

    QuitButton QuitB;

    // Use this for initialization
    void Start()
    {


/////////////////////////////

        OriginalPlayerUIPosition = new Vector3();

        HidePlayerPanelViewPostion = new Vector3();


        // saves the original rect transform of the playerPanelObject
         OriginalPlayerUIPosition = new Vector3(0,0,0 );

        if (HidePlayerPanelView != null )
        {
            // saves the hide rect transform of the hide location UI
            HidePlayerPanelViewPostion = HidePlayerPanelView.GetComponent<RectTransform>().localPosition;

        }


        // print(OriginalPlayerUIPosition + "Original" );

        // print(HidePlayerPanelViewPostion + "HDIE" );
        /////////////////////////////

            IPL = Singleton_Service.GetSingleton<Input_Listeners>();

      



        //StartB = GameObject.Find("Start Button").GetComponent<StartButton>();

        QuitB = GameObject.Find("Quit Button").transform.GetComponent<QuitButton>();


        if (HidePlayerPanelView != null)
        {

            PlayerPanelObject = this.gameObject.transform.GetChild(0).gameObject;

            ToDOList = this.gameObject.transform.GetChild(1).gameObject;




            // initial state of UI Panels
            PlayerPanelObject.SetActive(true);
            ToDOList.SetActive(false);
        }

        state1 = false;
        state2 = false;

        AtHidePostion = false;

    }

    // Update is called once per frame
    void Update()
    {
        PlayTeleport();
   
    }

    /// <summary>
    ///  teleports player in the game
    /// </summary>
    void PlayTeleport()
    {
        if( IPL != null )
        {

            if (IPL.getLeftTriggerInteracting())
            {
                RaycastHit hit;

                Debug.DrawRay(transform.position, transform.forward, Color.green);

                if (Physics.Raycast(transform.position, transform.forward, out hit))
                {
                    if (hit.collider.CompareTag("Teleport"))
                    {


                        IPL.teleport = true;

                        newPos = hit.point;

                        // right controller is used
                        if (!IPL.teleR)
                        {
                            IPL.teleL = true;

                        }
                    }
                    else
                    {
                        IPL.teleport = false;
                    }


                    if (hit.collider.CompareTag("Complete Ship"))
                    {
                        Debug.Log("Complete SHip !!! ");
                        SceneManager.LoadScene(WinningSceneIndex);

                    }


                }
            }


            if (IPL.teleport && !IPL.getLeftTriggerInteracting())
            {
                //Debug.Log(newPos);

                //to make sure only one of the controllers is being trigger at one time
                if (IPL.teleL)
                {

                    Player.transform.position = newPos;
                    IPL.teleport = false;
                    IPL.teleL = false;

                }

            }




        }



    }


    // called when Button X is released 
    public void ButtonXCheck()
    {



        // state machine switch statement
        //
        // switch statements cannot use floats 
        //
        //switch ( (int)(PlayerPanelObject.GetComponent<RectTransform>().position.y) )
        //{
        //// state 1
        //case 0 :

        //    if (!state1 && !state2)
        //    {
        //        Debug.Log("STATe 1");
        //        //PlayerPanelObject.SetActive(false);

        //        PlayerPanelObject.gameObject.GetComponent<RectTransform>().position = HidePlayerPanelViewPostion;
        //        //set the player planel to the hide position

        //        ToDOList.SetActive(true);
        //        state1 = true;

        //    }
        //        break;


        //// state 2
        //case -25:

        //    if ( state1 && !state2 )
        //    {
        //        Debug.Log("STATe 2");
        //        //PlayerPanelObject.SetActive(false);

        //        PlayerPanelObject.gameObject.GetComponent<RectTransform>().position = HidePlayerPanelViewPostion;
        //        //set the player planel to the hide position


        //        ToDOList.SetActive(false);
        //        state2 = true;
        //        break;
        //    }



        //    // state 3
        //    if (state1 && state2)
        //    {
        //        Debug.Log("STATe 3");
        //        // PlayerPanelObject.SetActive(true);

        //        PlayerPanelObject.gameObject.GetComponent<RectTransform>().position = OriginalPlayerUIPosition;
        //        // set the player planel back to the original rect transform

        //        ToDOList.SetActive(false);
        //        state1 = false;
        //        state2 = false;
        //    }

        //    break;


        // }

        //alternative  ( should be using local position !!!!!!!! )
        //
        // otherwise this will work !!!

        //if( PlayerPanelObject.GetComponent<RectTransform>().position.y == 0.0f )
        //{

        //    Debug.Log()

        //    if (!state1 && !state2)
        //    {
        //        Debug.Log("STATe 1");
        //        //PlayerPanelObject.SetActive(false);

        //        PlayerPanelObject.gameObject.GetComponent<RectTransform>().position = HidePlayerPanelViewPostion;
        //        //set the player planel to the hide position

        //        ToDOList.SetActive(true);
        //        state1 = true;
        //    }

        //}
        //else if(PlayerPanelObject.GetComponent<RectTransform>().position.y == -25.0f )
        //{

        //    if (state1 && !state2)
        //       {
        //          Debug.Log("STATe 2");
        //          //PlayerPanelObject.SetActive(false);

        //             PlayerPanelObject.gameObject.GetComponent<RectTransform>().position = HidePlayerPanelViewPostion;
        //             //set the player planel to the hide position


        //              ToDOList.SetActive(false);
        //              state2 = true;

        //        }


        //   // state 3
        //    if (state1 && state2)
        //    {

        //     Debug.Log("STATe 3");
        //          // PlayerPanelObject.SetActive(true);

        //         PlayerPanelObject.gameObject.GetComponent<RectTransform>().position = OriginalPlayerUIPosition;
        //           // set the player planel back to the original rect transform

        //           ToDOList.SetActive(false);
        //           state1 = false;
        //           state2 = false;
        //     }

        //}


        if (HidePlayerPanelView != null)
        {

            switch (AtHidePostion)
            {

                case false:
                    // set to the hide position
                    // set todolist true
                    // state 1 = true


                    PlayerPanelObject.gameObject.GetComponent<RectTransform>().localPosition = HidePlayerPanelViewPostion;
                    ToDOList.SetActive(true);
                    state1 = true;

                    AtHidePostion = true;

                    //print(" state 1 ");

                    break;

                case true:

                    // if( state1 == true )
                    // set tododlist = false
                    // keep playerpanel at hide position
                    // state 2 = true

                    if (state1 && !state2)
                    {
                        ToDOList.SetActive(false);
                        state2 = true;

                        // print(" state 2 ");

                        break;

                    }

                    // if ( state1 && state 2 == true )
                    //set to original position
                    // keep todollist false
                    // state 1 = false
                    // state 2 = false
                    // athide postion = false

                    if (state1 && state2)
                    {
                        PlayerPanelObject.gameObject.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
                        state1 = false;
                        state2 = false;
                        AtHidePostion = false;

                        // print(" state 3 ");
                    }

                    break;


            }
        }


        // ( The very second  one )
        //
        //// state machine switch statement

        //switch (PlayerPanelObject.activeSelf)
        //{
        //    // state 1
        //    case true:

        //        if (!state1 && !state2)
        //        {
        //            Debug.Log("STATe 1");
        //            PlayerPanelObject.SetActive(false);
        //            ToDOList.SetActive(true);
        //            state1 = true;

        //        }
        //        break;


        //    // state 2
        //    case false:

        //        if (state1 && !state2)
        //        {
        //            Debug.Log("STATe 2");
        //            PlayerPanelObject.SetActive(false);
        //            ToDOList.SetActive(false);
        //            state2 = true;
        //            break;
        //        }



        //        // state 3
        //        if (state1 && state2)
        //        {
        //            Debug.Log("STATe 3");
        //            PlayerPanelObject.SetActive(true);
        //            ToDOList.SetActive(false);
        //            state1 = false;
        //            state2 = false;
        //        }

        //        break;


        //}



        // ( The very First one )
        //
        /// old planel switching state


        //if (PlayerPanelObject.activeSelf == true)
        //{
        //    PlayerPanelObject.SetActive(false);
        //    ToDOList.SetActive(true);
        //}
        //else
        //{

        //    PlayerPanelObject.SetActive(false);
        //    ToDOList.SetActive(false);

        //}

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
           
            switch (hit.collider.tag)
            {
                case "Start Button":
                    StartB.StartButtonInteracted();
                    break;

                case "About Button":
                    AboutPanel.SetActive(true);
                    MenuPanel.SetActive(false);
                    break;

                case "Quit Button":
                    QuitB.Quit();
                    break;

                case "Back Button":
                    AboutPanel.SetActive(false);
                    MenuPanel.SetActive(true);
                    break;

                default:
                    break;
            }
        }
             
    }

    // called when Button Y is released
    public void ButtonYCheck()
    {

    }
   
    
}