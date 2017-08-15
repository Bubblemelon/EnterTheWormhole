using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Left_VR_Cont : MonoBehaviour
{

    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
    private Valve.VR.EVRButtonId GripButton = Valve.VR.EVRButtonId.k_EButton_Grip;
    private Valve.VR.EVRButtonId ButtonX = Valve.VR.EVRButtonId.k_EButton_A;
    private Valve.VR.EVRButtonId ButtonY = Valve.VR.EVRButtonId.k_EButton_DPad_Up;
    private Valve.VR.EVRButtonId ThumbstickButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad;


    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
    public SteamVR_TrackedObject trackedObj;

    Input_Listeners IPL;
    TeleL teleL;

    // Use this for initialization
    void Start()
    {
        IPL = Singleton_Service.GetSingleton<Input_Listeners>();

        trackedObj = GetComponent<SteamVR_TrackedObject>();
        teleL = GetComponent<TeleL>();
    }

    // Update is called once per frame
    void Update()
    {
        //TRIGGER

        if (controller.GetPressDown(triggerButton))
        {
            IPL.setLeftTriggerInteracting(true);
            // IPL.Set_Player_Interacting(true);
            SteamVR_Controller.Input((int)trackedObj.index).TriggerHapticPulse(500);
        }
        if (controller.GetPressUp(triggerButton))
        {
            IPL.setLeftTriggerInteracting(false);
           // IPL.Set_Player_Interacting(false);
        }


        //GRIP

        if (controller.GetPressDown(GripButton))
        {
            IPL.setLeftGripInteracting(true);
            // IPL.Set_Player_Interacting(true);
            SteamVR_Controller.Input((int)trackedObj.index).TriggerHapticPulse(500);
        }

        if (controller.GetPressUp(GripButton))
        {
            IPL.setLeftGripInteracting(false);
            // IPL.Set_Player_Interacting(false);
        }

        // BUTTON X

        if ( controller.GetPressDown(ButtonX) )
        {
            IPL.setButtonX(false);
            SteamVR_Controller.Input((int)trackedObj.index).TriggerHapticPulse(500);
        }
        if ( controller.GetPressUp(ButtonX) )
        {
            teleL.ButtonXCheck();
        }



        // BUTTON Y

        if( controller.GetPressDown( ButtonY) )
        {
            IPL.setButtonY(false);
           // SteamVR_Controller.Input((int)trackedObj.index).TriggerHapticPulse(500);
        }
        if( controller.GetPressUp( ButtonY) )
        {
            teleL.ButtonYCheck();

        }


        // THUMBSTICK BUTTON

        if (controller.GetPressDown(ThumbstickButton))
        {
            IPL.setThumbStickPressedLeft(false);
            SteamVR_Controller.Input((int)trackedObj.index).TriggerHapticPulse(500);
        }
        if (controller.GetPressUp(ThumbstickButton))
        {
            // does the same thing as the x button on the touch controls 
            teleL.ButtonXCheck();
        }


    }

}