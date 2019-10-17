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
                        StartCoroutine(AddNextGroup());
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

    private IEnumerator AddNextGroup()
    {
        Vector3 pos = Vector3.zero;

        for (int i = 0; i < _data.WaveGroups[_currentIteration].Enemies.Count; i++)
        {
            float rand = 0;// Random.Range(-10, 10);

            var enemy = _data.WaveGroups[_currentIteration].Enemies[i];

            switch (_data.WaveGroups[_currentIteration].Spawn)
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
            _spawnController.AddEnemy(enemy, pos);
            yield return new WaitForSeconds(_data.WaveGroups[_currentIteration].SpawnDelay);
        }
        _spawnDelay = _data.WaveGroups[_currentIteration].NextGroupDelay;

        _currentIteration++;
    }

    public bool IsFinishedSpawning
    {
        get { return (_currentState == State.FinishedSpawning); }
    }
}
