using UnityEngine;

// In this example we have a particle system emitting green particles; we then emit and override the color every 2 seconds.
public class ExampleClass : MonoBehaviour
{
	private ParticleSystem system;

	void Start()
	{
		// A simple particle material with no texture.
		Material particleMaterial = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));

		// Create a particle system.
		var go = new GameObject("Particle System");
		go.transform.Rotate(-90, 0, 0); // Rotate so the system emits upwards.
		system = go.AddComponent<ParticleSystem>();
		go.GetComponent<ParticleSystemRenderer>().material = particleMaterial;
		var mainModule = system.main;
		mainModule.startColor = Color.green;

		// Every 2 seconds we will emit.
		InvokeRepeating("DoEmit", 2.0f, 2.0f);
	}

	void DoEmit()
	{
		// Any parameters we assign in emitParams will override the current system's when we call Emit.
		// Here we will override the start color. All other parameters will use the behavior defined in the Inspector.
		var emitParams = new ParticleSystem.EmitParams();
		emitParams.startColor = Color.red;
		system.Emit(emitParams, 10);
	}
}