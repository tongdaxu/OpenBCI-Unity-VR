using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		ParticleBehaviour.G2_emissionRate = 100f;

	}
	
	// Update is called once per frame
	void Update () {

		ParticleBehaviour.G2_emissionRate = ParticleBehaviour.G2_emissionRate+ 0.1f;
		
	}
}
