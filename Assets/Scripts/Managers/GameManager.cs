using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public GameManager instance;
    public ParticleSystem ParticleEffects;

    protected override void Awake()
    {
        base.Awake();
        ParticleEffects = GameObject.FindGameObjectWithTag("Particle").GetComponent<ParticleSystem>();
        
    }
}
