using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinKiller : MonoBehaviour
{
    FloatSpinMidAir fsma;
    Quaternion OgRot;
    // Use this for initialization
    void Start()
    {
        fsma = GetComponent<FloatSpinMidAir>();
        OgRot = transform.rotation;
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Right Hand" || col.gameObject.tag == "Left Hand")
        {
            fsma.enabled = false;
            transform.rotation = OgRot;
        }

    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Right Hand" || other.gameObject.tag == "Left Hand")
        {
            fsma.enabled = true;
            transform.rotation = OgRot;
            transform.parent = null;
        }
    }
}
