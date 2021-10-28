using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEffectsHelper : MonoBehaviour
{
    public static SpecialEffectsHelper Instance;

    public ParticleSystem explosionEffect;
    public ParticleSystem fireEffect;

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("Multiple instances of SpecialEffectsHelper!");
        }

        Instance = this;
    }

    public void Explosion(Vector3 position)
    {
        instantiate(explosionEffect, position);
        instantiate(fireEffect, position);
    }

    private ParticleSystem instantiate(ParticleSystem prefab, Vector3 position)
    {
        ParticleSystem particleSystem = Instantiate(prefab, position, Quaternion.identity) as ParticleSystem;

        Destroy(
            particleSystem.gameObject,
            particleSystem.startLifetime
        );

        return particleSystem;
    }
}
