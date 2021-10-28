using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour
{
    private int damage = 1;
    public bool isEnemyShot = false;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 20);
    }

    public void setDamage(int damage)
    {
        this.damage = damage;
    }

    public int getDamage()
    {
        return this.damage;
    }

}
