using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    private WaveData _data = null;
    private EnemySpawnController _spawnController = null;

    public enum State { None, Spawning, FinishedSpawning }
    private State _currentState = State.None;
    private float _spawnDelay = 0.0f;
    private int _currentIteration = 0;

    public void ResetData(WaveData data, EnemySpawnController spawnController)
    {
        _data = data;
        _spawnController = spawnController;
        _currentState = State.Spawning;
        _spawnDelay = 0.0f;
        _currentIteration = 0;
    }

    public void SpawnBossMobs()
    {
        AddBossGroup();
    }

    public void Update()
    {
        switch (_currentState)
        {
            case State.None:
            {
                break;
            }
            case State.Spawning:
            {
                if (_currentIteration >= _data.WaveGroups.Count)
                {
                    _currentState = State.FinishedSpawning;
                }
                else
                {
                    _spawnDelay -= Time.deltaTime;
                    if (0.0f > _spawnDelay)
                    {
                        AddNextGroup();
                        _currentIteration++;
                    }
                }
                break;
            }
            case State.FinishedSpawning:
            {
                break;
            }
        }
    }

    private void AddNextGroup()
    {
        AddGroup(_data.WaveGroups[_currentIteration]);
    }

    private void AddBossGroup()
    {
        AddGroup(_data.BossGroup);
    }

    private void AddGroup(WaveGroupData group)
    {
        _spawnDelay = group.TotalSpawnDelay;

        Vector3 pos = Vector3.zero;

        for (int i = 0; i < group.Enemies.Count; ++i)
        {
            float rand = Random.Range(-10, 10);

            var enemy = group.Enemies[i];

            switch (group.Spawn)
            {
                case WaveGroupData.SpawnSide.Left:
                {
                    pos = new Vector3(-12, rand, 0);
                    break;
                }
                case WaveGroupData.SpawnSide.Right:
                {
                    pos = new Vector3(12, rand, 0);
                    break;
                }
                case WaveGroupData.SpawnSide.Top:
                {
                    pos = new Vector3(rand, 12, 0);
                    break;
                }
                case WaveGroupData.SpawnSide.Bottom:
                {
                    pos = new Vector3(rand, -12, 0);
                    break;
                }
            }

            float delay = group.SpawnDelay * i;
            StartCoroutine(_spawnController.AddEnemy(enemy, pos, delay));
        }
    }

    public bool IsFinishedSpawning
    {
        get { return (_currentState == State.FinishedSpawning); }
    }
}
