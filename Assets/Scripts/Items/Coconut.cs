using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coconut : MonoBehaviour
{
    //private variables
    TimeElapsed exp;
    Thirst t;
    Sounds noise;

    //public variables

    public float coconutExpTime = 7000f;

    // Use this for initialization
    void Start()
    {
        noise = GameObject.Find("Game Manager").GetComponent<Sounds>();

        t = GameObject.Find("Game Manager").GetComponent<Thirst>();

        exp = GameObject.Find("Game Manager").GetComponent<TimeElapsed>();

        StartCoroutine( exp.expiration(coconutExpTime , this.gameObject) ); // coconut's expiration time
    }

    // Update is called once per frame
    void Update()
    {

    }

    // add some sort of sound or effect when wood is burnt ???

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Mouth"))
        {
            noise.DrinkingStrawSound();

            t.fillWater(2000);

            //Destroy(this.gameObject);
            this.gameObject.SetActive(false);

            //Debug.Log(" Drank a Coconut ");
        }
    }

}