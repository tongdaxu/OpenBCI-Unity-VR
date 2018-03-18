using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor.Rendering;
#endif

public class waveControler : MonoBehaviour {

    public Material waterMat;

	// Use this for initialization
	void Start () {
		waterMat = new Material(Shader.Find("StylizedWater"));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
