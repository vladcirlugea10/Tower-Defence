using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(enemy))]
public class EnemyMovement : MonoBehaviour
{

    private Transform target;
    private int checkpointIndex = 0;

    private enemy enemy;

    void Start()
    {
        enemy = GetComponent<enemy>();
        target = checkpoint.checkp[0];
    }
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
            GetNextCheckpoint();

        enemy.speed = enemy.startSpeed;
    }

    void GetNextCheckpoint()
    {
        if (checkpointIndex >= checkpoint.checkp.Length - 1)
        {
            EndPath();
            return;
        }
        checkpointIndex++;
        target = checkpoint.checkp[checkpointIndex];
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);

    }
}
