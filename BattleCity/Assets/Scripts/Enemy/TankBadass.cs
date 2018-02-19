using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBadass : EnemyTank
{
    public override int PointsValue
    {
        get
        {
            return  Configs.EnemyStats.TankBadassPointsValue;
        }
    }

   // int HP;
  //  float speed;
    float bulletSpeed;
    Direction direction;
    //Rigidbody rb;
    float ShotCooldown;

    //[SerializeField]
    //LayerMask maskPlayer;

    public override void Init()
    {
        HP = Configs.EnemyStats.TankBadassHP;
        speed = Configs.EnemyStats.TankBadassSpeed;
        bulletSpeed = Configs.EnemyStats.TankBadassBulletSpeed;
        ShotCooldown = 3f;

        //rb = GetComponent<Rigidbody>();

        InvokeRepeating("Shoot", ShotCooldown, ShotCooldown);
    }

    public override void Shoot()
    {
        GameObject bullet = Instantiate(GameManager.Instance.EnemyBulletPrefab);
        Debug.Log("Todo shoot ennemy");
 //       bullet.GetComponent<BulletCollision>().Init(BulletSpawnPoint.position, BulletSpawnPoint.rotation, transform.up * bulletSpeed);
    }

    public override void Move()
    {
        //Collider[] hitColliders = Physics.OverlapBox(transform.position, transform.localScale, Quaternion.identity, maskPlayer);
        //if(hitColliders.Length == 0)
        //{
           
        //}
        transform.position = Vector3.MoveTowards(transform.position, GameManager.Instance.player1.transform.position, speed * Time.deltaTime);
        // rb.velocity = new Vector3(speed*Time.deltaTime, 0, 0); 
    }

    void Update()
    {
        Move();
    }

    public override void RecieveDamage(int damageLevel, PlayerControl player)
    {
        Explode();
        // Give points to player
    }

    public void Explode()
    {
        Instantiate(GameManager.Instance.GenericResources.TankExplosion, transform.position, Quaternion.identity, null);
        Destroy(gameObject);
    }
}
