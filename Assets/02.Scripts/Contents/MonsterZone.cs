using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class MonsterZone : MonoBehaviour
{
    [SerializeField] private List<GameObject> spawnPoints;
    [SerializeField] private List<GameObject> monsterPrefabs;
    [SerializeField] private List<GameObject> walls; // 다음 구역 차단용
    [SerializeField] private int monsterCount = 0;
    [SerializeField] private int killedCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        GetComponent<BoxCollider>().enabled = false;
        ActivateZone();
        SpawnMonsters();
    }

    private void ActivateZone()
    {
        foreach(var wall in walls)
        {
            wall.gameObject.SetActive(true);
        }
    }
    private void SpawnMonsters()
    {
        MonsterController monster;
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            if (i < 4)
                monster = Managers.Object.Spawn<MonsterController>(spawnPoints[i].transform.position, 202002);
            else
                monster = Managers.Object.Spawn<MonsterController>(spawnPoints[i].transform.position, 202001);

            Health health = monster.GetComponent<Health>();
            health.OnDie += () =>
            {
                OnMonsterKilled(); 
                health.OnDie -= OnMonsterKilled; 
            };
            monsterCount++;
        }
  

    }

    private void OnMonsterKilled()
    {
        killedCount++;
        if (killedCount >= monsterCount) //Zone Clear
        {
            UnActiveZone();
          
        }
    }

    private void UnActiveZone()
    {
        foreach (var wall in walls)
        {
            wall.gameObject.SetActive(false);
        }
    }

}
