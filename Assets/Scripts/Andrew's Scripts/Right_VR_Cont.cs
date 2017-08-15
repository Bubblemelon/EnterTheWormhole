using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Right_VR_Cont : MonoBehaviour
{

    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;

    private Valve.VR.EVRButtonId GripButton = Valve.VR.EVRButtonId.k_EButton_Grip;

    private Valve.VR.EVRButtonId ButtonA = Valve.VR.EVRButtonId.k_EButton_A;

    private Valve.VR.EVRButtonId ThumbstickButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad;

    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }

    public SteamVR_TrackedObject trackedObj;

    Input_Listeners IPL;
    TeleR teleR;

    // Use this for initialization
    void Start()
    {
        //IPL = GameObject.Find("GM").GetComponent<Input_Listeners>();
        IPL = Singleton_Service.GetSingleton<Input_Listeners>();


        trackedObj = GetComponent<SteamVR_TrackedObject>();

        // always initialize private variablessss !!!!!!!!!!!
        teleR = GetComponent<TeleR>();
    }

    // Update is called once per frame
    void Update()
    {
        //TRIGGER

        if (controller.GetPressDown(triggerButton))
        {
            IPL.setRightTriggerInteracting(true);
            // IPL.Set_Player_Interacting(true);

               SteamVR_Controller.Input((int)trackedObj.index).TriggerHapticPulse(500);


        }
        if (controller.GetPressUp(triggerButton))
        {
            IPL.setRightTriggerInteracting(false);
            // IPL.Set_Player_Interacting(false);
        }

        //GRIP

        if (controller.GetPressDown(GripButton))
        {
            IPL.setRightGripInteracting(true);
            // IPL.Set_Player_Interacting(true);

            SteamVR_Controller.Input((int)trackedObj.index).TriggerHapticPulse(500);
        }
        if (controller.GetPressUp(GripButton))
        {
            IPL.setRightGripInteracting(false);
            // IPL.Set_Player_Interacting(false);
        }

        // BUTTON A

        if (controller.GetPressDown(ButtonA))
        {
            IPL.setButtonA(false);
            SteamVR_Controller.Input((int)trackedObj.index).TriggerHapticPulse(500);
        }
        if (controller.GetPressUp(ButtonA))
        {
            teleR.ButtonACheck();
        }


        // THUMBSTICK BUTTON

        if (controller.GetPressDown(ThumbstickButton))
        {
            IPL.setThumbStickPressedRight(false);
            SteamVR_Controller.Input((int)trackedObj.index).TriggerHapticPulse(500);
        }
        if (controller.GetPressUp(ThumbstickButton))
        {
            // does the same thing as the x button on the touch controls 
            teleR.ButtonACheck();
        }




    }

}