using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogTimer : MonoBehaviour {

    //PUBLIC 

    public float FogDuration;
    // Fog Wind
    public AudioClip FogWindNoise;


    //PRIVATE

    GameObject FogMotion;
    AudioSource Asource;
    private float volLowRange = .05f;
    private float volHighRange = .25f;

    // transform FogMotion

    private void Awake()
    {
        FogDuration = 250f;
        Asource = GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start () {

        FogMotion = this.gameObject.transform.GetChild(0).gameObject;
        // FogMotion = this.gameObject.transform.GetChild(0);

        FogMotion.SetActive(false);
        // FogMotion.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void FogRollsIn()
    {

       FogMotion.SetActive(true);

        // FOG WIND SOUND
        float vol = Random.Range(volLowRange, volHighRange);
        Asource.PlayOneShot(FogWindNoise, vol);

        //Debug.Log(Asource.isPlaying);
        // 

        StartCoroutine( StopFog() );

       // Debug.Log("FOG Started");
    }

    IEnumerator StopFog()
    {
        yield return new WaitForSeconds(FogDuration);
        FogMotion.SetActive(false);
        Asource.Stop();
        Debug.Log(Asource);
        Debug.Log("FOG STOPEED");
    }
}
