using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienLifeShowsUp : MonoBehaviour {

    public int NumberOfDaysForAlienToShowUp;

    TimeElapsed t;

    // Use this for initialization
    void Start () {

        NumberOfDaysForAlienToShowUp = 7;

        // should find objects with tags instead of object's names
        t = GameObject.Find("Game Manager").transform.GetComponent<TimeElapsed>();

        this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {

        //Debug.Log(t.timeInDays() + "DAy number");

        if ( t.timeInDays() == NumberOfDaysForAlienToShowUp)
        {

            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);

        }


	}
}
