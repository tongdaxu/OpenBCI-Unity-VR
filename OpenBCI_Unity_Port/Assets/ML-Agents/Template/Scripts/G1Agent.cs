using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G1Agent : Agent {



	public override List<float> CollectState()
	{
		List<float> state = new List<float>();


		state.Add (ParticleBehaviour1.G1_color);
		state.Add (ParticleBehaviour1.G1_emissionRate);
		state.Add (ParticleBehaviour1.G1_rotate);
		state.Add (ParticleBehaviour1.G1_speed);
		state.Add (ParticleBehaviour1.G1_shift);

		return state;
	}

	public override void AgentStep(float[] act)
	{

		if (brain.brainParameters.actionSpaceType == StateType.continuous) {

			float colorAction = act [0];
			float emissionAction = act [1];
			float rotateAction = act [2];
			float speedAction = act [3];
			float shiftAction = act [4];

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

					
		}

	}

	public override void AgentReset()
	{

	}

	public override void AgentOnDone()
	{

	}
}
