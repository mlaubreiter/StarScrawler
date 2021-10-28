using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public int hp = 1;
    public bool isEnemy = true;
    public int points = 10;

    public void Damage(int damageCount)
    {
        hp -= damageCount;


        if (hp <= 0)
        {
            SoundEffectsHelper.Instance.MakeExplosionSound();
            SpecialEffectsHelper.Instance.Explosion(transform.position);
            Destroy(gameObject);
            if (isEnemy)
            {
                Parameters.IncreaseScore(points);
            }
            return;
        }

        if (isEnemy)
        {
            SoundEffectsHelper.Instance.MakeHitSoundEnemy();
        }
        else
        {
            SoundEffectsHelper.Instance.MakeHitSoundPlayer();
        }

    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();
        if (shot != null)
        {
            if (shot.isEnemyShot != isEnemy)
            {  
                Damage(shot.getDamage());
                Destroy(shot.gameObject);
                return;
            }
        }
        else
        {
            if (CompareTag("Player") && otherCollider.CompareTag("Enemy"))
            {
               Damage(1000);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        LaserScript laser = collision.gameObject.GetComponent<LaserScript>();
        if (laser != null)
        {
            if (isEnemy)
            {
                Damage(laser.laserDamage);
                return;
            }
        }
    }


}
