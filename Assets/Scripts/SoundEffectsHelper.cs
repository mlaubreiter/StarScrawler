using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectsHelper : MonoBehaviour
{ 
    public static SoundEffectsHelper Instance;

    public AudioClip explosionSound;
    public AudioClip playerShotSound;
    public AudioClip enemyShotSound;
    public AudioClip laserSound;
    public AudioClip hitSoundPlayer;
    public AudioClip hitSoundEnemy;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of SoundEffectsHelper!");
        }
        Instance = this;
    }

    public void MakeExplosionSound()
    {
        MakeSound(explosionSound, 1);
    }

    public void MakePlayerShotSound()
    {
        MakeSound(playerShotSound, 0.7f);
    }

    public void MakeEnemyShotSound()
    {
        MakeSound(enemyShotSound, 0.7f);
    }

    public void MakeLaserSound()
    {
        MakeSound(laserSound, 0.9f);
    }

    public void MakeHitSoundEnemy()
    {
        MakeSound(hitSoundEnemy, 0.5f);
    }

    public void MakeHitSoundPlayer()
    {
        MakeSound(hitSoundPlayer, 0.5f);
    }

    private void MakeSound(AudioClip originalClip, float volume)
    {
        AudioSource.PlayClipAtPoint(originalClip, transform.position, volume);
    }
}
