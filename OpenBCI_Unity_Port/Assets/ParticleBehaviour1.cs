using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]

public class ParticleBehaviour1 : MonoBehaviour {
	
	public static float G1_color_1;
	ParticleSystem exhaust;
	Gradient grad = new Gradient();

	void Start () {

		exhaust = GetComponent<ParticleSystem>();

	}

	void Update () {

		var col = exhaust.colorOverLifetime;
		var main = exhaust.main;

		G1_color_1 = (float)(G1_color_1 - System.Math.Floor (G1_color_1));
		exhaust.emissionRate = ParticleBehaviour2.G2_emissionRate;
		exhaust.transform.Rotate (0f, 0f, ParticleBehaviour2.G2_rotate) ;
		main.startSpeed = ParticleBehaviour2.G2_speed;

		grad.SetKeys( new GradientColorKey[] { new GradientColorKey(Color.HSVToRGB(G1_color_1, 1f, 1f), 0.0f), new GradientColorKey(Color.HSVToRGB(G1_color_1, 1f, 1f), 1.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(1.0f, 0f) } );
		col.color = grad;

	}
}
