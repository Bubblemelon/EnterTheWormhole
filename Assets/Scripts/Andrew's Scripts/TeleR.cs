using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleR : MonoBehaviour
{
    // public vairable
    public GameObject Player;
    public StartButton StartB;
    public GameObject AboutPanel;
    public GameObject MenuPanel;

    // private vairables
    Input_Listeners IPL;
    Vector3 newPos;

    QuitButton QuitB;

    // Use this for initialization
    void Start()
    {
        IPL = Singleton_Service.GetSingleton<Input_Listeners>();

        //StartB = GameObject.Find("Start Button").GetComponent<StartButton>();

        QuitB = GameObject.Find("Quit Button").transform.GetComponent<QuitButton>();

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

        if (IPL.getRightTriggerInteracting())
        {
            RaycastHit hit;
            //Debug.DrawRay(transform.position, transform.forward, Color.green);
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                if (hit.collider.CompareTag("Teleport"))
                {
                    IPL.teleport = true;

                    newPos = hit.point;

                    // right controller is used
                    if (!IPL.teleL)
                    {
                        IPL.teleR = true;

                    }
                }
                else
                {
                    IPL.teleport = false;
                }
            }
        }


        if (IPL.teleport && !IPL.getRightTriggerInteracting())
        {
            //Debug.Log(newPos);

            //to make sure only one of the controllers is being trigger at one time
            if (IPL.teleR)
            {

                Player.transform.position = newPos;
                IPL.teleport = false;
                IPL.teleR = false;

            }

        }



    }

    // called when Button A is released 
    public void ButtonACheck()
    {
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







}
