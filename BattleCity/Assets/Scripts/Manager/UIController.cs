using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIController : MonoBehaviour
{
    #region Singleton
    public static UIController Instance = null;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    #endregion

    [SerializeField]
    GameObject m_UIEnemyTankIconsContainer = null;

    Stack<GameObject> m_EnemyTankIconsList = new Stack<GameObject>();

    void Start()
    {
        for (int i = 0; i < 20; ++i) // TODO make configurable
        {
            var icon = Instantiate(GameManager.Instance.TankResources.TankUIIcon, m_UIEnemyTankIconsContainer.transform);
            m_EnemyTankIconsList.Push(icon);
        }
    }

    public void RemoveEnemyTankIcon()
    {
        Destroy(m_EnemyTankIconsList.Pop());
    }
}
