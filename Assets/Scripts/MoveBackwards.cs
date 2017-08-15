using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackwards : MonoBehaviour {

    float increment;

	// Use this for initialization
	void Start () {
        increment = 0f;
	}
	
	// Update is called once per frame
	void Update () {

        moveBackwards();
	}

    void moveBackwards()
    {
        this.GetComponent<RectTransform>().position = new Vector3(0, 0, increment/7);

        increment++;

    }
}
