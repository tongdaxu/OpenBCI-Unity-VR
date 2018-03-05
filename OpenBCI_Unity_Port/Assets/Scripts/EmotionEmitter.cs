using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmotionEmitter : MonoBehaviour {

	public ParticleSystem system;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		system.Emit (new ParticleSystem.EmitParams (){ position = Random.onUnitSphere }, 1);
		
	}
}
