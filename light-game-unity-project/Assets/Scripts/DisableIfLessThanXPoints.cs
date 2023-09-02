using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableIfLessThanXPoints : MonoBehaviour
{
    public int points = 8;
    public EnemySpawner spawner;

    private void Awake()
    {
        if (spawner.currentEnemyCount <= points)
        {
            Destroy(gameObject);
        }
    }
}
