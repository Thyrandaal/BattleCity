using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager: MonoBehaviour
{
    #region Singleton
    public static GameManager Instance = null;
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if(Instance == null)
        {
            Instance = this;
        }     
        else if(Instance != this)
        {
            Destroy(gameObject);
        }
    }

    #endregion

    [SerializeField]
    Transform playerSpawnPoint1 = null;

    //[SerializeField]
    //Transform playerSpawnPoint2 = null;

    [SerializeField]
    List<Transform> m_EnemySpawnPoints = new List<Transform>();

    [SerializeField]
    GameObject playerPrefab = null;

    [SerializeField]
    public GameObject EnemyBulletPrefab = null;

    public PlayerControl player1 = null;
    public PlayerControl player2 = null;

    List<PlayerControl> m_PlayersList = new List<PlayerControl>();
    int m_SpawnPointIndex = 0;

    [SerializeField]
    GenericResources genericResources = null;
    public GenericResources GenericResources
    {
        get
        {
            return genericResources;
        }
    }

    [SerializeField]
    TankResources tankResources = null;
    public TankResources TankResources
    {
        get
        {
            return tankResources;
        }
    }

    public void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        Inputs.Enabled = true;
        var go = Instantiate(playerPrefab, playerSpawnPoint1.position, Quaternion.identity);
        player1 = go.GetComponent<PlayerControl>();

        StartCoroutine(SpawnEnemies());

        Destroy(playerPrefab);
    }

    public void MovePlayer(Direction direction, int playerIndex)
    {
        if(playerIndex == 1)
        {
            player1.Move(direction);
        }
        else if (playerIndex == 2)
        {
            player2.Move(direction);
        }
    }

    public void RegisterPlayer(PlayerControl player)
    {
        Debug.Assert(!m_PlayersList.Contains(player), "Players list already contains player");
        m_PlayersList.Add(player);
    }

    public void UnregisterPlayer(PlayerControl player)
    {
        Debug.Assert(m_PlayersList.Contains(player), "Players list already contains player");
        m_PlayersList.Remove(player);
    }

    private IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(1);

        while(/*Enemies List not empty... spawn*/ true)
        {
            StartCoroutine(SpawnEnemyAtPosition(m_EnemySpawnPoints[m_SpawnPointIndex].position, tankResources.TanksNormalPrefab));
            m_SpawnPointIndex = (m_SpawnPointIndex + 1) % m_EnemySpawnPoints.Count;

            yield return new WaitForSeconds(7f); // TODO: this needs to be adaptable
        }
    }

    private IEnumerator SpawnEnemyAtPosition(Vector3 spawnPosition, GameObject tankToSpawn)
    {
        UIController.Instance.RemoveEnemyTankIcon();
        var spawnAnim = Instantiate(GenericResources.SpawnAnimation, spawnPosition, Quaternion.identity);

        yield return new WaitForSeconds(1.5f);

        Destroy(spawnAnim);

        var enemy = Instantiate(tankToSpawn, spawnPosition, Quaternion.identity);
    }

    public void Stuff()
    {

    }
}
