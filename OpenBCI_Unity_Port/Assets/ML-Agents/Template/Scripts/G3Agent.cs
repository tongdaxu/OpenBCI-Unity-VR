using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G3Agent : Agent {



	public override List<float> CollectState()
	{
		List<float> state = new List<float>();

		state.Add (UDPServer.alphaValue);
		state.Add (ParticleBehaviour3.G3_emissionRate);
		state.Add (ParticleBehaviour3.G3_speed);
		state.Add (lightControl.timeFlow);
		state.Add (waveControler.waveIntensity);
		state.Add (waveControler.waveSpeed);

		return state;
	}

	public override void AgentStep(float[] act)
	{
		if (brain.brainParameters.actionSpaceType == StateType.continuous) {

			float emissionAction = act [0];
			float speedAction = act [1];
			float timeflowAction = act [2];
			float waveIntAction = act [3];
			float waveSpeedAction = act [4];

			if (System.Math.Abs (emissionAction) < 1.0f) {
				ParticleBehaviour2.G2_emissionRate = ParticleBehaviour2.G2_emissionRate + emissionAction / 50f;
			} else if (emissionAction >= 1.0f) {
				ParticleBehaviour2.G2_emissionRate = ParticleBehaviour2.G2_emissionRate + 0.02f;			
			} else {
				ParticleBehaviour2.G2_emissionRate = ParticleBehaviour2.G2_emissionRate - 0.02f;
			}


			if (System.Math.Abs (speedAction) < 1.0f) {
				ParticleBehaviour2.G2_speed = ParticleBehaviour2.G2_speed + speedAction / 10f;
			} else if (speedAction >= 1.0f) {
				ParticleBehaviour2.G2_speed = ParticleBehaviour2.G2_speed + 0.1f;			
			} else {
				ParticleBehaviour2.G2_speed = ParticleBehaviour2.G2_speed - 0.1f;
			}


			if (System.Math.Abs (timeflowAction) < 1.0f) {
				lightControl.timeFlow = 2*timeflowAction;
			} else if (timeflowAction >= 1.0f) {
				lightControl.timeFlow = 2.0f;			
			} else {
				lightControl.timeFlow = -2.0f;
			}

			if (waveControler.waveIntensity < 0.1f) {

			} else if (waveControler.waveIntensity >= 40.0f) {
				
			} else {
				waveControler.waveIntensity = waveControler.waveIntensity + waveIntAction;
			}

			if (waveControler.waveSpeed < 0.1f) {

			} else if (waveControler.waveSpeed >= 40.0f) {

			} else {
				waveControler.waveSpeed = waveControler.waveSpeed + waveSpeedAction;
			}


			if (ParticleBehaviour2.G2_emissionRate < 0f) {
				done = true;
				reward = -0.1f;
			}


			if ( UDPServer.alphaValue/UDPServer.alphaValuePast < 0.9f ) {
				done = true;
				reward = -1.0f;
			}

			if (done == false)
			{
				reward = 0.1f;
			}

		}
	}

	public override void AgentReset()
	{

		ParticleBehaviour3.G3_emissionRate = 500f;
		ParticleBehaviour3.G3_speed = 10f;
		waveControler.waveSpeed = 10f;
		waveControler.waveIntensity = 10f;
	}

	public override void AgentOnDone()
	{

	}
}
