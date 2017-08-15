using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayDisplay : MonoBehaviour {


    [Header("UI Elements")]
    //public Text timeText;           //The UI element that shows the amount of time
    public Text collectText;        //The UI element that shows the player's Number of Days

    TimeElapsed t;

    //Awake is always called before any Start functions
    private void Awake()
    {
        // Set up the reference.
        collectText = GetComponent<Text>();

        t = GameObject.Find("Game Manager").transform.GetComponent<TimeElapsed>();
    }

    // Use this for initialization
    void Start () {

        collectText.text = "Day: " + t.timeInDays();

    }

    // Update is called once per frame
    void Update () {


        collectText.text = "Day: " + t.timeInDays();

    }
}
