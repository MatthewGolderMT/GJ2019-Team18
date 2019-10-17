using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    [SerializeField] private List<WaveData> Waves = new List<WaveData>();
    [SerializeField] private Wave CurrentWave = null;
    [SerializeField] private GameObject EnemyPrefab = null;

    public enum State { AllClear, Spawning, FinishedSpawning, Completed }
    private State _currentState = State.AllClear;
    private int _currentWaveIndex = 0;
    private List<GameObject> _enemiesGO = new List<GameObject>();
    private List<Enemy> _enemiesData = new List<Enemy>();

    private void Update()
    {
        switch (_currentState)
        {
            case State.AllClear:
            {
                if (_currentWaveIndex >= Waves.Count)
                {
                    _currentState = State.Completed;
                }
                else
                {
                    StartNextWave();
                }
                break;
            }
            case State.Spawning:
            {
                if (CurrentWave.IsFinishedSpawning)
                {
                    _currentState = State.FinishedSpawning;
                }
                break;
            }
            case State.FinishedSpawning:
            {
                if (!EnemiesAlive)
                {
                    foreach(var go in _enemiesGO)
                    {
                        UnityEngine.Object.Destroy(go);
                    }
                    _enemiesGO.Clear();
                    _enemiesData.Clear();
                    _currentState = State.AllClear;
                }
                break;
            }
            case State.Completed:
            {
                break;
            }
        }
    }

    private void StartNextWave()
    {
        CurrentWave.ResetData(Waves[_currentWaveIndex], this);
        _currentState = State.Spawning;
        _currentWaveIndex++;
    }

    public IEnumerator AddEnemy(EnemyData data, Vector3 pos, float delay)
    {
        yield return new WaitForSeconds(delay);
    
        GameObject enemyGO = Instantiate(EnemyPrefab, pos, Quaternion.identity);
        Enemy enemy = enemyGO.GetComponent<Enemy>();
        enemy.ResetData(data);

        _enemiesGO.Add(enemyGO);
        _enemiesData.Add(enemy);
    }

    public void KillEnemies()
    {
        foreach (var emeny in _enemiesData)
        {
            emeny.Kill();
        }
    }

    private bool EnemiesAlive
    {
        get { return _enemiesData.Exists(x => (!x.IsDead)); }
    }
}
