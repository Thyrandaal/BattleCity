using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyTank : MonoBehaviour
{
    [SerializeField]
    protected Transform BulletSpawnPoint;

    protected int HP;
    protected float speed;
    public abstract int PointsValue { get; }

    public abstract void Init();
    public abstract void Shoot();
    public abstract void Move();
    public abstract void RecieveDamage(int damageLevel, PlayerControl player);
}
