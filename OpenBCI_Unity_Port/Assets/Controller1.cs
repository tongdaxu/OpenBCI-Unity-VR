using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller1 : MonoBehaviour {

	void Start () {

		ParticleBehaviour1.G1_emissionRate = 100f;
		ParticleBehaviour1.G1_rotate = 0f;
		ParticleBehaviour1.G1_color = 0.2f;
		ParticleBehaviour1.G1_speed = 10f;

	}
	

	void Update () {

		ParticleBehaviour1.G1_speed = ParticleBehaviour1.G1_speed + Random.Range (-0.1f, 0.1f);
		ParticleBehaviour1.G1_emissionRate = ParticleBehaviour1.G1_emissionRate+ 0.1f;
		ParticleBehaviour1.G1_translate = ParticleBehaviour1.G1_translate + Random.Range (-0.001f, 0.001f);
		ParticleBehaviour1.G1_rotate = ParticleBehaviour1.G1_rotate + Random.Range (-0.01f, 0.01f);
		
	}
}
