using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class LoadSceneOnClick : MonoBehaviour 
{

    Input_Listeners IPL;

    void Start()
    {
        IPL = Singleton_Service.GetSingleton<Input_Listeners>();
    }

    public void LoadByIndex( int sceneIndex )
    {
       if(  IPL.getButtonX() )
        {
            SceneManager.LoadScene(sceneIndex);
        }
      
    }

   



}
