using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsManager : MonoBehaviour {

    private EnemySpawner enemySpawner;
    public TextMeshProUGUI text;
    private void Start()
    {
        enemySpawner = EnemySpawner.Instance;
    }

    private void Update()
    {
        text.text = "Points: " + enemySpawner.currentEnemyCount;
    }
}
