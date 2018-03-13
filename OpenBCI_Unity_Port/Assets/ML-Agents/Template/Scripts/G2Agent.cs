using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G2Agent : Agent {


	public override List<float> CollectState()
	{
		List<float> state = new List<float>();

		state.Add (UDPServer.arosualValue);
		state.Add (UDPServer.valenceValue);
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
		}

	}

	public override void AgentReset()
	{


	}

	public override void AgentOnDone()
	{

	}
}
