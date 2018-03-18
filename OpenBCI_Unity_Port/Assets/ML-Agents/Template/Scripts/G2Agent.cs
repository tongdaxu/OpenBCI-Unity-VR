using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G2Agent : Agent {

	private float alphaPast;
		
	public override List<float> CollectState()
	{
		List<float> state = new List<float>();

		state.Add (UDPServer.alphaValue);
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

			//note the scale of action space

			if (System.Math.Abs (colorAction) < 1.0f) {
				ParticleBehaviour2.G2_color_1 = ParticleBehaviour2.G2_color_1 + colorAction/20f  ;
			} else {
				ParticleBehaviour2.G2_color_1 = ParticleBehaviour2.G2_color_1 + 0.05f;			
			}

			if (System.Math.Abs (emissionAction) < 1.0f) {
				ParticleBehaviour2.G2_emissionRate = ParticleBehaviour2.G2_emissionRate + emissionAction/50f  ;
			} else {
				ParticleBehaviour2.G2_emissionRate = ParticleBehaviour2.G2_emissionRate + 0.02f;			
			}

			if (System.Math.Abs (rotateAction) < 1.0f) {
				ParticleBehaviour2.G2_rotate = ParticleBehaviour2.G2_rotate + rotateAction/10f  ;
			} else {
				ParticleBehaviour2.G2_rotate = ParticleBehaviour2.G2_rotate + 0.1f;			
			}

			if (System.Math.Abs (speedAction) < 1.0f) {
				ParticleBehaviour2.G2_speed = ParticleBehaviour2.G2_speed + speedAction/10f  ;
			} else {
				ParticleBehaviour2.G2_speed = ParticleBehaviour2.G2_speed + 0.1f;			
			}



			Debug.Log (UDPServer.alphaValue == UDPServer.alphaValuePast);

			if ( UDPServer.alphaValue/UDPServer.alphaValuePast > 1.1f ) {
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

		ParticleBehaviour2.G2_color_1 = 0.2f;
		ParticleBehaviour2.G2_emissionRate = 150f;
		ParticleBehaviour2.G2_rotate = 0f;
		ParticleBehaviour2.G2_speed = 10f;

	}

	public override void AgentOnDone()
	{

	}
}
