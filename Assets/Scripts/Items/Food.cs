using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    //private variables
    Hunger hunger;
    TimeElapsed t;
    Sounds s;
    //Public variables
    
    
    public float FoodExpTime = 3000f;

    // Use this for initialization
    void Start()
    {
        hunger = GameObject.Find("Game Manager").GetComponent<Hunger>();

        t = GameObject.Find("Game Manager").GetComponent<TimeElapsed>();

        s = GameObject.Find("Game Manager").GetComponent<Sounds>();


        StartCoroutine(t.expiration(FoodExpTime , this.gameObject)); // expires in 3000secs
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
            s.EatingSound();

            hunger.fillFood(4000);

            // Destroy(this.gameObject);

            this.gameObject.SetActive(false);

            //Debug.Log(" Ate COOKED Meat ! ");
        }

        if (other.CompareTag("Animal"))
        {
            Destroy(this.gameObject);

            Debug.Log(" Animal collided with Food ! ");

        }
    }

    private void OnTriggerStay(Collider other)
    {
        //if (other.CompareTag("Fire"))
       // {
        //    Debug.Log("COOKING FOOD AGAIN ??!!!");
        //
         //   Destroy(this.gameObject);

       // }
    }



}