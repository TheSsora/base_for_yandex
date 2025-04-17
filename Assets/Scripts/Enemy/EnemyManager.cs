using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform parent;
    [SerializeField] private List<EnemyController> enemies;
    
    void Start()
    {
        Spawn();
    }
    private void Spawn()
    {
        if (Instantiate(enemies[0].gameObject, new Vector3(-1, 0, 7), Quaternion.identity, parent)
            .TryGetComponent<EnemyController>(out var enemy))
        {
            enemy.SpawnInit(player);
        }
    }
}
