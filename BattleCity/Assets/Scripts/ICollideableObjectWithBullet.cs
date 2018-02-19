using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollideableObjectWithBullet
{
    int m_Health
    {
        get;
        set;
    }

    int m_DamageReduction
    {
        get;
        set;
    }

    void OnHit();
}
