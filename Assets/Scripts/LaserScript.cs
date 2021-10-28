using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{

    public float timeRemainingNext = 0;
    public float timeRemainingLaser = 0;

    public ParticleSystem laser;
    private ParticleSystem laserCopy;

    public int laserDamage = 5;
    void Update()
    {
        if (timeRemainingNext > 0)
        {
            timeRemainingNext -= Time.deltaTime;
        }

        if (timeRemainingLaser > 0)
        {
            timeRemainingLaser -= Time.deltaTime;
        }
        if(timeRemainingLaser <= 0)
        {
            Collider2D collider = gameObject.GetComponentInChildren<Collider2D>();
            collider.enabled = false;
            Destroy(laserCopy);
        }
    }


    public void Attack()
    {
        if (timeRemainingNext <= 0)
        {
            SoundEffectsHelper.Instance.MakeLaserSound();
            laserCopy = Instantiate(laser, gameObject.transform) as ParticleSystem;
            laserCopy.GetComponent<Renderer>().sortingLayerName = "Bullets";

            Collider2D collider = gameObject.GetComponentInChildren<Collider2D>();
            collider.enabled = true;

            timeRemainingLaser = 2;
            timeRemainingNext = 4;
        }
    }
}
