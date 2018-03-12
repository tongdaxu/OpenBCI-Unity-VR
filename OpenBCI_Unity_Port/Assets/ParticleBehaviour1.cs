using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]

public class ParticleBehaviour1 : MonoBehaviour {

	public static float G1_emissionRate;
	public static float G1_rotate;
	public static float G1_translate;
	public static float G1_speed;

	public static float G1_shift;
	public static float G1_color;
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

		exhaust.emissionRate = G1_emissionRate;
		exhaust.transform.Rotate (0f, 0f, G1_rotate) ;
		exhaust.transform.Translate (0f, 0f, G1_translate);
		main.startSpeed = G1_speed;

		grad.SetKeys( new GradientColorKey[] { new GradientColorKey(Color.HSVToRGB(G1_color + G1_shift, 1f, 1f), 0.0f), new GradientColorKey(Color.HSVToRGB(G1_color, 1f, 1f), 1.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(1.0f, 0f) } );
		col.color = grad;
	
	}
}
