using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

    SteamVR_TrackedObject trackedObj;
    SteamVR_Controller.Device device;

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    void FixedUpdate()
    {
        device = SteamVR_Controller.Input((int)trackedObj.index);
    }

    void Update()
    {
       // rumbleController();
    }

    void rumbleController()
    {
        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Grip) )
        {
            device.TriggerHapticPulse(1000);
        }
           
        

    }
}
