using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance { get; private set; }

    enum SpawnType { DELAY, ON_WIN , BOTH}
    enum DifficultyCondition { DELAY, ON_WIN, BOTH}

    [SerializeField] private Crawl EnemyPrefab;
    public int initialSpawnCount = 1;
    [SerializeField] private SpawnType spawnType;

    [Tooltip("This is only used if Spawn Type is set to DELAY or BOTH.")]
    [SerializeField] private float spawnDelay = 5f;

    [Tooltip("How many enemies to spawn at once.")]
    [SerializeField] private int spawnCount = 1;

    [Tooltip("Should the number of enemies reset on win?")]
    [SerializeField] private bool resetEnemyCountOnWin = true;

    public int maxDifficulty = 7;
    public int maxEnemies = 10;
    public int currentDifficulty = 1;
    public int currentEnemyCount = 0;

    private float spawnDelayTimer = 0;

    /// <summary>
    /// Initialize EnemySpawner Singleton
    /// </summary>
    private void Awake()
    {
        DontDestroyOnLoad(this);
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        SceneManager.sceneLoaded += InitializeLevel;
    }

    private void Update()
    {
        if (spawnType == SpawnType.DELAY || spawnType == SpawnType.BOTH)
        {
            spawnDelayTimer += Time.deltaTime;
            if (spawnDelayTimer >= spawnDelay)
            {
                SpawnEnemy(spawnCount);
                spawnDelayTimer = 0;
            }
        }
    }

    /// <summary>
    /// Spawns the specified number of enemies
    /// </summary>
    public void SpawnEnemy(int count)
    {
        for (int i = 0; i < count; i++)
        {
            if (currentEnemyCount >= maxEnemies) return;
            var enemy = Instantiate(EnemyPrefab);
            if (currentDifficulty > maxDifficulty) currentDifficulty = maxDifficulty;
            enemy.SetDifficulty(currentDifficulty);
            currentEnemyCount++;
        }
    }

    /// <summary>
    /// Initialize the level on each SceneLoad
    /// </summary>
    private void InitializeLevel(Scene scene, LoadSceneMode mode)
    {
        if (Instance != this) return;
        spawnDelayTimer = 0;
        var n = resetEnemyCountOnWin ? initialSpawnCount : currentEnemyCount;
        if (n == 0) n++;
        else if (spawnType == SpawnType.ON_WIN || spawnType == SpawnType.BOTH
            && !resetEnemyCountOnWin) n += spawnCount;
        currentEnemyCount = 0;
        SpawnEnemy(n);
    }
}
