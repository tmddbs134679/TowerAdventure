using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    [SerializeField] private Transform towerHead;
    private Transform enemy;
    public List<Transform> enemyList;
    public EnemyCreator enrmyCreator;

    [Header("Attack details")]
    [SerializeField] private float attackRange = 3;
    public float lastTimeAttacked;
    [SerializeField] private float attackCooldown;

    [Header("Bueet Details")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed = 3;

    // Update is called once per frame
    void Update()
    {
        if (enemy == null)
        {
            enemy = FindClosestEnemy();
            return;
        }
    
        if(Vector3.Distance(enemy.position,towerHead.position) < attackRange)
        {
            towerHead.LookAt(enemy);

            if (ReadyToAttack())
            {
                CreatBullet();
            }

        }
    }

    private Transform FindClosestEnemy()
    {
        float closestDistance = float.MaxValue;
        Transform closestEnemy = null;

        foreach(Transform enemy in enrmyCreator.EnemyList())
        {
            float distance = Vector3.Distance(transform.position, enemy.position);

            if(distance < closestDistance && distance < attackRange)
            {
                closestDistance = distance;
                closestEnemy = enemy;
            }
        }

        if(closestEnemy != null)
            enrmyCreator.EnemyList().Remove(closestEnemy);

        return closestEnemy;
    }

    private void CreatBullet()
    {
        GameObject newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody>().velocity = (enemy.position - towerHead.position).normalized * bulletSpeed;
    }

    private bool ReadyToAttack()
    {
        if (Time.time > lastTimeAttacked + attackCooldown)
        {
            lastTimeAttacked = Time.time;
            return true;
        }

        return false;
    }

    private void FindRandomEnemy()
    {
        if (enemyList.Count <= 0)
            return;

        int randomIdx = Random.Range(0, enrmyCreator.EnemyList().Count);
        enemy = enrmyCreator.EnemyList()[randomIdx];
        enrmyCreator.EnemyList().RemoveAt(randomIdx);

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, attackRange); 
    }
}
