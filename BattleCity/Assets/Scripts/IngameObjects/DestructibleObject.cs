using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObject : MonoBehaviour
{
    [SerializeField]
    private int m_Armor = 1;

    [SerializeField]
    private int m_Health = 1;

    public void RecieveDamage(int damage)
    {
        if (damage >= m_Armor)
        {
            --m_Health;

            if(m_Health <= 0)
            {
                DestroyObject();
            }
        }
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
