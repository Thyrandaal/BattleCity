using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    LayerMask m_LayerMask = new LayerMask();

    GameObject m_BulletOwner;
    int m_DamageLevel;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject != m_BulletOwner)
        {
            var explosion = Instantiate(GameManager.Instance.GenericResources.SmallExplosion);
            explosion.transform.position = transform.position;

            var destructibleScript = col.gameObject.GetComponent<DestructibleObject>();
            var enemyTank = col.gameObject.GetComponent<EnemyTank>();

            if (destructibleScript != null)
            {
                if (col.contacts.Length != 0)
                {
                    foreach (var hit in Physics2D.BoxCastAll(col.contacts[0].point, new Vector2(0.76f, 0.10f), transform.eulerAngles.z, Vector2.zero, 0, m_LayerMask))
                    {
                        var neighborObject = hit.transform.GetComponent<DestructibleObject>();
                        if (neighborObject != null)
                        {
                            neighborObject.RecieveDamage(m_DamageLevel);
                        }
                    }
                }
            }
            else if (enemyTank != null)
            {
                // enemyTank.RecieveDamage(m_DamageLevel, m_BulletOwner);
                enemyTank.RecieveDamage(m_DamageLevel, GameManager.Instance.player1);
            }

            Destroy(gameObject);
        }
    }

    public void Init(Vector3 position, Quaternion rotation, Vector3 velocity, PlayerControl player, int damageLevel)
    {
        transform.position = position;
        transform.rotation = rotation;
        GetComponentInChildren<Rigidbody2D>().velocity = velocity;
        m_BulletOwner = player.gameObject;
        m_DamageLevel = damageLevel;
    }
}
