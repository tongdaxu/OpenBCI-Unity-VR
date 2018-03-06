using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class ParticlePlexus : MonoBehaviour {

    public int maxConnections = 50;
    public int maxLineRenders = 100;

    public float maxDistance = 1.0f;
    ParticleSystem.Particle[] particles;
    new ParticleSystem particleSystem;
    ParticleSystem.MainModule particleSystemMainModule;

    public LineRenderer lineRenderTemplate;
    List<LineRenderer> lineRenders = new List<LineRenderer>();

    Transform _transform;

	// Use this for initialization
	void Start () {
        particleSystem = GetComponent<ParticleSystem>();
        particleSystemMainModule = particleSystem.main;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        int maxParticles = particleSystemMainModule.maxParticles;

        if(particles == null || particles.Length < maxParticles)
        {
            particles = new ParticleSystem.Particle[maxParticles];
        }

        int lrIndex = 0;
        int lineRenderCount = lineRenders.Count;

        if(lineRenderCount>maxLineRenders)
        {
            for(int i= maxLineRenders; i<lineRenderCount;i++)
            {
                Destroy(lineRenders[i].gameObject);
            }
            int removeCount = lineRenderCount - maxLineRenders;
            lineRenders.RemoveRange(maxLineRenders, removeCount);
            lineRenderCount -= removeCount;
        }

        if (maxConnections>0 && maxLineRenders > 0)
        {

            particleSystem.GetParticles(particles);
            int particleCount = particleSystem.particleCount;

            float maxDistanceSqr = maxDistance * maxDistance;

        


            ParticleSystemSimulationSpace simulationSpace = particleSystemMainModule.simulationSpace;

            switch (simulationSpace)
            {
                case ParticleSystemSimulationSpace.Local:
                    {
                        _transform = transform;
                        break;
                    }
                case ParticleSystemSimulationSpace.Custom:
                    {
                        _transform = particleSystemMainModule.customSimulationSpace;
                        lineRenderTemplate.useWorldSpace = false;
                        break;
                    }
                case ParticleSystemSimulationSpace.World:
                    {
                        _transform = transform;
                        break;
                    }
                default:
                    {
                        throw new System.NotSupportedException
                        (string.Format("Unsupport simulation slace '{0}'.",System.Enum.GetName(typeof (ParticleSystemSimulationSpace),particleSystemMainModule.simulationSpace)));
                    }
            }

        for(int i=0; i<particleCount;i++)
        {
                Vector3 p1_position = particles[i].position;
                int connections = 0;

                for(int j=i+1;j<particleCount;j++)
                {
                    Vector3 p2_position = particles[j].position;
                    float distanceSqr = Vector3.SqrMagnitude(p1_position - p2_position);

                    if (distanceSqr <= maxDistanceSqr)
                    {

                        LineRenderer lr;

                        if (lrIndex == lineRenderCount)
                        {
                            lr = Instantiate(lineRenderTemplate, _transform, false);
                            lineRenders.Add(lr);

                            lineRenderCount++;
               
                        }

                        lr = lineRenders[lrIndex];

                        lr.enabled = true;
                        lr.useWorldSpace = simulationSpace == ParticleSystemSimulationSpace.World ? true : false;

                        lineRenders[lrIndex].SetPosition(0, p1_position);
                        lineRenders[lrIndex].SetPosition(1, p2_position);

                        lrIndex++;
                        connections++;

                        if (connections == maxConnections || lrIndex == maxLineRenders)
                        {
                            break;
                        }
                    }
                }
            }
        }
        for (int i = lrIndex; i < lineRenderCount; i++)
        {
            lineRenders[i].enabled = false;
        }

    }
}
