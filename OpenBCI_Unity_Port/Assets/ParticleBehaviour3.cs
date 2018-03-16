using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]

public class ParticleBehaviour3 : MonoBehaviour {

	public static float G3_emissionRate;
	public static float G3_speed;


	ParticleSystem exhaust;
	Gradient grad = new Gradient();

	void Start () {

		exhaust = GetComponent<ParticleSystem>();
	}
	
	void Update () {
		
		var main = exhaust.main;

		exhaust.emissionRate = G3_emissionRate;
		main.startSpeed = G3_speed;


	
	}
}
