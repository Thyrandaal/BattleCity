using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    List<Transform> EnemySpawnPoints = new List<Transform>();
    Queue<EnemyTank> EnemyTanksList = new Queue<EnemyTank>();
    int index = 0;

    void Start()
    {
        Init();
    }

    void Init() //TODO: Y passer la liste...
    {
        for(int i = 0; i< 20; ++i)
        {
            EnemyTanksList.Enqueue(new TankBadass());
        }

        foreach(var trans in GetComponentsInChildren<Transform>())
        {
            if(trans != transform)
            {
                EnemySpawnPoints.Add(trans);
            }
        }

        InvokeRepeating("SpawnNextEnemy", 3f, 3f);
    }

    void SpawnNextEnemy()
    {
        var newTank = Instantiate(GameManager.Instance.TankResources.TanksBadassPrefab, EnemySpawnPoints[index].position, Quaternion.Euler(0, 0, 180));
        newTank.GetComponent<EnemyTank>().Init();
         //          Instantiate(TankResources.EnemyTanksPrefabs[0], transform, false);
         //      var script = ;
         //  newTank.AddComponent<>;

        //    newTank.transform.position = EnemySpawnPoints[index].position;
             index = ++index % EnemySpawnPoints.Count;
    }
}
