using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MonsterZone : MonoBehaviour
{
    [SerializeField] private List<GameObject> spawnPoints;
    [SerializeField] private List<GameObject> monsterPrefabs;
    [SerializeField] private List<GameObject> walls; // 다음 구역 차단용
    private int monsterCount = 0;
    private int killedCount = 0;
   // private StageManager stageManager;

    //public void Activate(StageManager mgr)
    //{
    //    stageManager = mgr;
    //    wall.SetActive(true); // 벽 닫기 (진입 전)
    //}

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
        //MonsterController monster;
        //for (int i = 0; i < spawnPoints.Count; i++)
        //{
        //    if (i < 4)
        //        monster = Managers.Object.Spawn<MonsterController>(spawnPoints[i].transform.position, 202002);
        //    else
        //        monster = Managers.Object.Spawn<MonsterController>(spawnPoints[i].transform.position, 202001);

        //    Debug.Log("Mosnter Pos : " + monster.transform.position);
        //    monsterCount++;
        //}
   
        Managers.Object.Spawn<MonsterController>(spawnPoints[0].transform.position, 202002);

    }

    private void OnMonsterKilled()
    {
        killedCount++;
        if (killedCount >= monsterCount)
        {
           // wall.SetActive(false); // 다음 영역 이동 가능
            //stageManager.OnZoneCleared();
        }
    }


}
