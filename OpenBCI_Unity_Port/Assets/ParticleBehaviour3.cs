using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]

public class ParticleBehaviour3 : MonoBehaviour {

	public static float G3_emissionRate;
	public static float G3_rotate;
	//public static float G3_translate;
	public static float G3_speed;

	public float G3_shift;
	//Translate for [0,10]

	public static float G3_color;
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

		exhaust.emissionRate = G3_emissionRate;
		exhaust.transform.Rotate (0f, G3_rotate, 0f) ;
		//exhaust.transform.Translate (0f, 0f, 0f);
		main.startSpeed = G3_speed;

		grad.SetKeys( new GradientColorKey[] { new GradientColorKey(Color.HSVToRGB(G3_color + G3_shift, 1f, 1f), 0.0f), new GradientColorKey(Color.HSVToRGB(G3_color + G3_shift, 1f, 1f), 1.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(1.0f, 0f) } );
		col.color = grad;
	
	}
}
