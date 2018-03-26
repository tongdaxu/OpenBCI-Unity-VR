using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G2Agent : Agent {

	private float alphaPast;
		
	public override List<float> CollectState()
	{
		List<float> state = new List<float>();

		state.Add (UDPServer.alphaValue);

		state.Add (ParticleBehaviour1.G1_color_1);
		state.Add (ParticleBehaviour2.G2_color_1);
		state.Add (ParticleBehaviour2.G2_emissionRate);
		state.Add (ParticleBehaviour2.G2_rotate);
		state.Add (ParticleBehaviour2.G2_speed);

		return state;
	}

	public override void AgentStep(float[] act)
	{
		if (brain.brainParameters.actionSpaceType == StateType.continuous) {

			float colorAction = act [0];
			float emissionAction = act [1];
			float rotateAction = act [2];
			float speedAction = act [3];
			float colorAction1 = act [4];

			// if need a random group
			/*
			colorAction = Random.Range (0, 1);
			emissionAction = Random.Range (0, 1);
			rotateAction = Random.Range (0, 1);
			speedAction = Random.Range (0, 1);
			colorAction1 = Random.Range (0, 1);
			*/

			//note the scale of action space

			if (System.Math.Abs (colorAction) < 1.0f) {
				ParticleBehaviour2.G2_color_1 = ParticleBehaviour2.G2_color_1 + colorAction/50f  ;
			} else if(colorAction>=1.0f) {
				ParticleBehaviour2.G2_color_1 = ParticleBehaviour2.G2_color_1 + 0.02f;			
			} else {
				ParticleBehaviour2.G2_color_1 = ParticleBehaviour2.G2_color_1 - 0.02f;
			}

			if (System.Math.Abs (colorAction1) < 1.0f) {
				ParticleBehaviour1.G1_color_1 = ParticleBehaviour1.G1_color_1 + colorAction1/50f  ;
			} else if(colorAction>=1.0f) {
				ParticleBehaviour1.G1_color_1 = ParticleBehaviour1.G1_color_1 + 0.02f;			
			} else {
				ParticleBehaviour1.G1_color_1 = ParticleBehaviour1.G1_color_1 - 0.02f;
			}

			if (System.Math.Abs (emissionAction) < 1.0f) {
				ParticleBehaviour2.G2_emissionRate = ParticleBehaviour2.G2_emissionRate + emissionAction / 20f;
			} else if (emissionAction >= 1.0f) {
				ParticleBehaviour2.G2_emissionRate = ParticleBehaviour2.G2_emissionRate + 0.05f;			
			} else {
				ParticleBehaviour2.G2_emissionRate = ParticleBehaviour2.G2_emissionRate - 0.05f;
			}

			if (System.Math.Abs (rotateAction) < 1.0f) {
				ParticleBehaviour2.G2_rotate = ParticleBehaviour2.G2_rotate + rotateAction / 50f;
			} else if (rotateAction >= 1.0f) {
				ParticleBehaviour2.G2_rotate = ParticleBehaviour2.G2_rotate + 0.02f;			
			} else {
				ParticleBehaviour2.G2_rotate = ParticleBehaviour2.G2_rotate - 0.02f;	
			}

			if (System.Math.Abs (speedAction) < 1.0f) {
				ParticleBehaviour2.G2_speed = ParticleBehaviour2.G2_speed + speedAction / 50f;
			} else if (speedAction >= 1.0f) {
				ParticleBehaviour2.G2_speed = ParticleBehaviour2.G2_speed + 0.02f;			
			} else {
				ParticleBehaviour2.G2_speed = ParticleBehaviour2.G2_speed - 0.02f;			
			}



			if (ParticleBehaviour2.G2_emissionRate <= 0) {
				done = true;
				reward = -0.1f;
			} else {
			}

			//Alpha wave down, avoid alphavalve go up

			if ( UDPServer.alphaValue/UDPServer.alphaValuePast > 1.1f ) {
				done = true;
				reward = -1.0f;
			}


			//Alpha wave up, avoid alphavalve go down

			/*
			if ( UDPServer.alphaValue/UDPServer.alphaValuePast < 0.9f ) {
				done = true;
				reward = -1.0f;
			}
			*/

			if (done == false)
			{
				reward = 0.1f;
			}


		}
	}

	public override void AgentReset()
	{
		ParticleBehaviour1.G1_color_1 = 0.8f;
		ParticleBehaviour2.G2_color_1 = 0.2f;
		ParticleBehaviour2.G2_emissionRate = 150f;
		ParticleBehaviour2.G2_rotate = Random.Range(-1f, 1f);
		ParticleBehaviour2.G2_speed = 10f;

	}

	public override void AgentOnDone()
	{

	}
}
