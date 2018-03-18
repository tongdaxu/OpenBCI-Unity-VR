using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightControl : MonoBehaviour {

	public static float timeFlow;
	private Light sunLight;

	// Use this for initialization
	void Start () {

		sunLight = GetComponent<Light>();
		
	}

	// Update is called once per frame
	void Update () {

		sunLight.transform.Rotate (timeFlow, 0f, 0f);

		//Debug.Log (sunLight.transform.rotation.x);

		if (Mathf.Abs (sunLight.transform.rotation.x) < 0.8f) {

			sunLight.color = Color.HSVToRGB (0.1f, 0.2f + sunLight.transform.rotation.x, 1f);
					
		} else {
		
			sunLight.color = Color.HSVToRGB (0.1f, 1f, 1f);

		}
		
	}
}
