using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveManager : MonoBehaviour
{
    public event EventHandler OnWaveNumberChanged;
    private enum State
    {
        WaitingToSpawnNextWave,
        SpawningWave,
    }
    [SerializeField] private List<Transform> enemySpawnPositionList;
    [SerializeField] private Transform nextWaveSpawnPositionTransform;
    private int waveNumber;
    private State state;
    private float nextWaveSpawnTimer;
    private float nextEnemySpawnTimer;
    private int remainingEnemySpawnAmount;
    private Vector3 spawnPosition;
    private void Start()
    {
        spawnPosition = enemySpawnPositionList[UnityEngine.Random.Range(0, enemySpawnPositionList.Count)].position;
        state = State.WaitingToSpawnNextWave;
        nextWaveSpawnPositionTransform.position = spawnPosition; 
        nextWaveSpawnTimer = 5f;
    }
    private void Update()
    {
        switch (state)
        {
            case State.WaitingToSpawnNextWave:
                nextWaveSpawnTimer -= Time.deltaTime;
                if (nextWaveSpawnTimer < 0f)
                {
                    SpawnEnemy();
                }
                break;
            case State.SpawningWave:
                if (remainingEnemySpawnAmount > 0)
                {
                    nextEnemySpawnTimer -= Time.deltaTime;
                    if (nextEnemySpawnTimer < 0f)
                    {
                        nextEnemySpawnTimer = .3f;
                        Enemy.Create(spawnPosition + UtilsClass.GetRandomDir() * UnityEngine.Random.Range(0f, 10f));
                        remainingEnemySpawnAmount--;
                    }
                }
                else
                {
                    state = State.WaitingToSpawnNextWave;
                    spawnPosition = enemySpawnPositionList[UnityEngine.Random.Range(0, enemySpawnPositionList.Count)].position;
                    nextWaveSpawnPositionTransform.position = spawnPosition;
                    nextWaveSpawnTimer = 10f;
                }
                break;
            default:
                break;
        }
        
        
    }
    private void SpawnEnemy()
    {   
        remainingEnemySpawnAmount = 5 + 3 * waveNumber;
        state = State.SpawningWave;
        waveNumber++;
        OnWaveNumberChanged?.Invoke(this, EventArgs.Empty);
    }

    public int GetWaveNumber()
    {
        return waveNumber;
    }
    public float GetNextWaveSpawnTimer()
    {
        return nextWaveSpawnTimer;
    }
    public Vector3 GetSpawnPosition()
    {
        return spawnPosition;
    }
}
