using UnityEngine;

public class PlayerWalkParticle : MonoBehaviour
{
    [SerializeField] private bool createDustOnWalk = true;
    [SerializeField] private ParticleSystem ParticleSystem;

    public void CreateWalkParticles()
    {
        if (createDustOnWalk)
        {
            ParticleSystem.Stop();
            ParticleSystem.Play();
        }
    }
}
