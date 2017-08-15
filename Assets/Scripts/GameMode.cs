using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMode : MonoBehaviour {

    public GameObject life1;
    public GameObject life2;
    public GameObject life3;

    public int sceneIndex;

    float DeathTransition;
    // Use this for initialization

    void Start () {

        DeathTransition = 5f;
    }
	
	// Update is called once per frame
	void Update () {

        GameOver();
		
	}

    void GameOver()
    {
        // if all three life items are INACTIVE
        if( !life1.activeSelf && !life2.activeSelf && !life3.activeSelf )
        {
            StartCoroutine(Death());
        }

    }

    IEnumerator Death()
    {

        yield return new WaitForSeconds(DeathTransition);

        LoadByIndex();
    }

    // change scene when all health items are gone
   void LoadByIndex()
    {

      SceneManager.LoadScene( sceneIndex );
        
    }


}
