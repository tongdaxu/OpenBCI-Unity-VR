using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]

public class ParticleBehaviour : MonoBehaviour {

	public static float G2_emissionRate;
	public static float G2_rotate;


	ParticleSystem exhaust;

	// Use this for initialization
	void Start () {

		exhaust = GetComponent<ParticleSystem>();

	}
	
	// Update is called once per frame
	void Update () {

		exhaust.emissionRate = G2_emissionRate;
		exhaust.transform.Rotate (0f, 0f, 1f) ;
		G2_rotate = G2_rotate + 1f;
		//exhaust.shape.radius. = 20f;
		//exhaust.shape.rotation.Set (0f, 0f, 90f);
		
	}
}
