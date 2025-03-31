using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
   
    [SerializeField] private int amountToSpawn = 4;

    private List<Transform> enemies;

    private void Start()
    {
        CreateNewEnemies();
    }

    private void CreateNewEnemies()
    {
        for (int i = 0; i < amountToSpawn; i++)
        {
            GameObject newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);

            float randomX = Random.Range(-4, 4);
            float randomZ = Random.Range(-4, 4);
            Vector3 newPos = new Vector3(randomX, 0.75f, randomZ);

            newEnemy.transform.position = newPos;

            enemies.Add(newEnemy.transform);
        }
    }

    public List<Transform> EnemyList() => enemies;


}
