using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]

public class ParticleBehaviour2 : MonoBehaviour {

	public static float G2_emissionRate;
	public static float G2_rotate;
	public static float G2_speed;

	public float G2_shift;
	//Translate for [0,10]

	public static float G2_color_1;
	//public static float G2_color_2;
	//Color for [0,1]

	//public static ParticleSystem.ColorOverLifetimeModule col;

	ParticleSystem exhaust;
	Gradient grad = new Gradient();

	void Start () {

		exhaust = GetComponent<ParticleSystem>();
	}
	
	void Update () {
		
		var col = exhaust.colorOverLifetime;
		var main = exhaust.main;

		exhaust.emissionRate = G2_emissionRate;
		exhaust.transform.Rotate (0f, 0f, G2_rotate) ;
		main.startSpeed = G2_speed;

		grad.SetKeys( new GradientColorKey[] { new GradientColorKey(Color.HSVToRGB(G2_color_1 + G2_shift, 1f, 1f), 0.0f), new GradientColorKey(Color.HSVToRGB(G2_color_1 + G2_shift, 1f, 1f), 1.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(1.0f, 0f) } );
		col.color = grad;
	
	}
}
