using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillAnimalChecker : MonoBehaviour {

    // KilledAnimals is a global variable of AnimalLife

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (AnimalLife.KilledAnimal == true)
        {
            Debug.Log("An Animal killed CHECKED");

            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);

        }

    }
}
