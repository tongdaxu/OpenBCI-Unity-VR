using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor.Rendering;
#endif

public class waveControler : MonoBehaviour {

    public Material waterMat;
    public static float waveSpeed;
    public static float waveIntensity;

	// Use this for initialization
	void Start () {
		waveSpeed = 10;
		waveIntensity = 10;
		//waterMat = new Material(Shader.Find("StylizedWater"));
	}
    
    // Update is called once per frame
    void Update () {
        waterMat.SetFloat("_WavesSpeed", waveSpeed);
        waterMat.SetFloat("_WavesIntensity", waveIntensity);
    }
}
