using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller3 : MonoBehaviour {

	void Start () {

		ParticleBehaviour3.G3_emissionRate = 5;
		ParticleBehaviour3.G3_rotate = 0f;
		ParticleBehaviour3.G3_color = 0.2f;
		ParticleBehaviour3.G3_speed = 10f;

	}
	

	void Update () {

		ParticleBehaviour3.G3_speed = ParticleBehaviour3.G3_speed + Random.Range (-0.1f, 0.1f);
		ParticleBehaviour3.G3_emissionRate = ParticleBehaviour3.G3_emissionRate+ 0.1f;

		//ParticleBehaviour3.G3_rotate = ParticleBehaviour3.G3_rotate + Random.Range (-0.01f, 0.01f);
		
	}
}
