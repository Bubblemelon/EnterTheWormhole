using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_Listeners : MonoBehaviour
{

    public bool LeftTriggerInteractive = false;
    public bool RightTriggerInteractive = false;

    public bool LeftGripInteractive = false;
    public bool RightGripInteractive = false;

    // Left
    public bool ButtonXInteractive;
    public bool ButtonYInteractive;

    public bool ThumbStickPressedLeft;

    // Right
    public bool ButtonAInteractive;

    public bool ThumbStickPressedRight;


    public bool teleport = false;

    public bool teleR = false;
    public bool teleL = false;


    // Use this for initialization
    void Start()
    {

    }


    /// <summary>
    /// 
    /// TRIGGER
    /// 
    /// </summary>


    // getters
    public bool getLeftTriggerInteracting()
    {
        return LeftTriggerInteractive;
    }
    public bool getRightTriggerInteracting()
    {
        return RightTriggerInteractive;
    }

    //setters
    public void setLeftTriggerInteracting(bool left)
    {
        LeftTriggerInteractive = left;
    }
    public void setRightTriggerInteracting(bool right)
    {
        RightTriggerInteractive = right;
    }


    /// <summary>
    /// 
    /// GRIP
    /// 
    /// </summary>
   

    // getters
    public bool getLeftGripInteracting()
    {
        return LeftGripInteractive;
    }
    public bool getRightGripInteracting()
    {
        return RightGripInteractive;
    }

    //setters
    public void setLeftGripInteracting(bool left)
    {
        LeftGripInteractive = left;
    }
    public void setRightGripInteracting(bool right)
    {
        RightGripInteractive = right;
    }


    /// <summary>
    /// 
    /// Button X and A
    /// 
    /// </summary>

    // getters
    public bool getButtonX()
    {
        return ButtonXInteractive;
    }
    public bool getButtonA()
    {
        return ButtonAInteractive;
    }

    //setters
    public void setButtonX( bool left )
    {
        ButtonXInteractive = left;
    }
    public void setButtonA( bool right ) 
    {
        ButtonAInteractive = right;
    }


    /// <summary>
    /// 
    /// Button Y
    /// 
    /// Not implementing B
    /// 
    /// </summary>
    
    //getter
    public bool getButtonY()
    {
        return ButtonYInteractive;
    }
    
    //setter
    public void setButtonY( bool left )
    {
        ButtonYInteractive = left;
    }


    /// <summary>
    /// 
    /// 
    ///  Thumbsticks presses
    ///  
    /// 
    /// </summary>

    

    /// RIGHT CONTROLLER
    
    //getter
    public bool getThumbStickPressedRight()
    {
        return ThumbStickPressedRight;
    }
    //setter
    public void setThumbStickPressedRight(bool right)
    {
        ThumbStickPressedRight = right;
    }


    /// LEFT CONTROLLER
    
    //getter
    public bool getThumbStickPressedLeft()
    {
        return ThumbStickPressedLeft;
    }
    //setter
    public void setThumbStickPressedLeft(bool left)
    {
        ThumbStickPressedLeft = left;
    }


    // Update is called once per frame
    void Update()
    {

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
