using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Vector2 speed;
    private Vector2 movement;
    private Rigidbody2D rigidbodyComponent;

    private int damage=1;
    public int damageShipOne;
    public int damageShipTwo;

    public Sprite spriteOne;
    public Sprite spriteTwo;
    public Vector2 speedShipOne = new Vector2(10,10);

    public Vector2 speedShipTwo = new Vector2(13, 13);

    public ParticleSystem particleSystemShipOne;
    public ParticleSystem particleSystemShipTwo;
    private ParticleSystem particles;

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        if (Parameters.SpaceCraft == 0)
        {
            spriteRenderer.sprite = spriteOne;
            speed = speedShipOne;
            damage = damageShipOne;

            particles = Instantiate(particleSystemShipOne, gameObject.transform) as ParticleSystem;
        }
        
        if (Parameters.SpaceCraft == 1)
        {
            spriteRenderer.sprite = spriteTwo;
            speed = speedShipTwo;
            damage = damageShipTwo;


            particles = Instantiate(particleSystemShipTwo, gameObject.transform) as ParticleSystem;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        movement = new Vector2(speed.x * inputX, speed.y * inputY);

        bool shoot = Input.GetButtonDown("Fire1");
        bool shootLaser = Input.GetButtonDown("Fire2");

        if (shoot)
        {
            WeaponScript weapon = GetComponent<WeaponScript>();
            if (weapon != null)
            {
                if (weapon.canAttack)
                {
                    weapon.Attack(false, damage);
                    SoundEffectsHelper.Instance.MakePlayerShotSound();
                }
            }
        }

        if (shootLaser)
        {
            GameObject laserSquare = gameObject.transform.Find("Square").gameObject;
            LaserScript laser = laserSquare.GetComponent<LaserScript>();

            if(laser != null)
            {
                laser.Attack();
            }
        }

        var dist = (transform.position - Camera.main.transform.position).z;

        var leftBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(0, 0, dist)
        ).x;

        var rightBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(1, 0, dist)
        ).x;

        var topBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(0, 0, dist)
        ).y;

        var bottomBorder = Camera.main.ViewportToWorldPoint(
          new Vector3(0, 1, dist)
        ).y;

        transform.position = new Vector3(
          Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
          Mathf.Clamp(transform.position.y, topBorder, bottomBorder),
          transform.position.z
        );

    }

    private void FixedUpdate()
    {
        if(rigidbodyComponent == null)
        {
            rigidbodyComponent = GetComponent<Rigidbody2D>();
        }

        rigidbodyComponent.velocity = movement;
    }

    void OnDestroy()
    {
        //Destroy(particles);
        GameOverScript gameover = GameObject.FindGameObjectWithTag("UI").GetComponent<GameOverScript>();
        if(gameover != null)
            gameover.ShowButtons();
    }
}
