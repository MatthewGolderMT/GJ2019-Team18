using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Wave Group Data", menuName = "Wave Group Data", order = 51)]
public class WaveGroupData : ScriptableObject
{
    public enum SpawnSide { Top, Left, Right, Bottom }

    [SerializeField] public List<EnemyData> Enemies = new List<EnemyData>();
    [SerializeField] public float SpawnDelay = 0.1f;
    [SerializeField] public float NextGroupDelay = 1.0f;
    [SerializeField] public SpawnSide Spawn = SpawnSide.Right;
}