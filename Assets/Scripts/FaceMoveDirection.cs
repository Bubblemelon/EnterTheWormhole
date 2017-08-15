using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceMoveDirection : MonoBehaviour {

    WanderingAI WA;

    Transform Leader;

    float strength;

	// Use this for initialization
	void Start () {

        // parent of the animal which controlls the movement
         WA = this.gameObject.transform.parent.GetComponent<WanderingAI>();

        //WA = this.gameObject.GetComponent<WanderingAI>();

        //Leader = this.gameObject.transform.parent;

        strength = 0.5f;

        Leader = this.gameObject.transform;
	}
	
	// Update is called once per frame
	void Update () {

        //transform.LookAt(Leader.transform);

        //Quaternion TR = Quaternion.LookRotation(Leader.position - transform.position);

        //float str = Mathf.Min(strength * Time.deltaTime, 1);

       // transform.rotation = Quaternion.Lerp(transform.rotation, TR, str);

        //transform.LookAt( WA.newPos + Vector3.left);

        transform.LookAt( Vector3.left);

    }
}
