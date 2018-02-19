using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    Up,
    Down,
    Left,
    Right,
    Idle
}

public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    GameObject bulletPrefab = null;

    [SerializeField]
    Transform bulletSpawn = null;

    Rigidbody2D rb;
    GameObject bullet;
    Stack<Direction> m_MovementKeyStack = new Stack<Direction>();

    int tankLevel = 1;

    //Collider[] hitColliders;

    //[SerializeField]
    //LayerMask maskEnemy;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1") && bullet == null)
        {
            ShootBullet();
        }
    }

    void ShootBullet()
    {
        bullet = Instantiate(bulletPrefab);

        float bulletSpeed = 0;
        if(tankLevel == 1)
        {
            bulletSpeed = Configs.PlayerStats.PLAYER_BULLET_SPEED_LVL_1;
        }

        bullet.GetComponent<Bullet>().Init(bulletSpawn.position, bulletSpawn.rotation, transform.up * bulletSpeed, this, tankLevel); // use another variable other than tanklevel for damage?
    }

    public void Move(Direction direction)
    {
        TurnPlayer(direction);

        if(direction == Direction.Idle)
        {
            rb.velocity = Vector2.zero;
        }
        else
        {
            rb.velocity = transform.up * Configs.PlayerStats.PLAYER_MOVEMENT_SPEED * Time.deltaTime;
        }
    }

    Vector2 GetBaseMovementVectorFromDirection(Direction direction)
    {
        var baseVector = Vector2.zero;

        switch (direction)
        {
            case Direction.Up:
                baseVector = Vector2.up;
                break;
            case Direction.Down:
                baseVector = -Vector2.up;
                break;
            case Direction.Left:
                baseVector = Vector2.left;
                break;
            case Direction.Right:
                baseVector = -Vector2.left;
                break;
            case Direction.Idle:
                break;
            default:
                break;
        }

        return baseVector;
    }

    void TurnPlayer(Direction direction)
    {
        switch(direction)
        {
            case Direction.Up:
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            break;
            case Direction.Down:
            {
                transform.rotation = Quaternion.Euler(0, 0, 180);
            }
            break;
            case Direction.Left:
            {
                transform.rotation = Quaternion.Euler(0, 0, 90);
            }
            break;
            case Direction.Right:
            {
                transform.rotation = Quaternion.Euler(0, 0, -90);
            }
            break;
            case Direction.Idle:
            break;
            default:
            {
                Debug.Log("Don't move");
            }
            break;
        }
    }
}